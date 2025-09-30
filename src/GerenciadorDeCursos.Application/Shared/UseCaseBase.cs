using AutoMapper;
using GerenciadorDeCursos.Domain.Model.Exceptions;
using GerenciadorDeCursos.Domain.Repositories.Shared;
using GerenciadorDeCursos.Shared;
using GerenciadorDeCursos.Shared.Enums;

namespace GerenciadorDeCursos.Application.Shared
{
    internal abstract class UseCaseBase<TRequest, TResponse>(
        IMapper mapper,
        IUnitOfWork unitOfWork)
    {
        public readonly IMapper _mapper = mapper;
        public readonly IUnitOfWork _unitOfWork = unitOfWork;

        public async Task<Response<TResponse>> Execute(TRequest request)
        {
            Response<TResponse> response;

            try
            {
                response = await ExecutaRegraDeNegocio(request);

                await _unitOfWork.CommitAsync();
            }
            catch (BusinessException ex)
            {
                response = new Response<TResponse>(ResponseStatus.BadRequest, ex.Message);

                await _unitOfWork.RollbackAsync();
            }
            catch (Exception ex)
            {
                response = new Response<TResponse>(ResponseStatus.InternalServerError, ex.Message);

                await _unitOfWork.RollbackAsync();
            }

            return response;
        }

        protected abstract Task<Response<TResponse>> ExecutaRegraDeNegocio(TRequest request);
    }
}