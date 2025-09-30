namespace GerenciadorDeCursos.Domain.Repositories.Shared
{
    public interface IUnitOfWork : IDisposable
    {
        Task CommitAsync();

        Task RollbackAsync();
    }
}