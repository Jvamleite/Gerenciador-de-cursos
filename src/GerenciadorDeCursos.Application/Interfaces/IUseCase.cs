using GerenciadorDeCursos.Shared;

namespace GerenciadorDeCursos.Application.Interfaces
{
    internal interface IUseCase<TRequest, TResponse>
    {
        public Task<Response<TResponse>> Execute(TRequest request);
    }
}