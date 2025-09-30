using GerenciadorDeCursos.Shared;

namespace GerenciadorDeCursos.Application.Interfaces
{
    public interface IUseCase<TRequest, TResponse>
    {
        public Task<Response<TResponse>> Execute(TRequest request);
    }
}