using GerenciadorDeCursos.Repositories.Context;
using Microsoft.EntityFrameworkCore.Storage;

namespace GerenciadorDeCursos.Domain.Repositories.Shared
{
    public class UnitOfWork(DataContext context) : IUnitOfWork
    {
        private readonly DataContext _context = context;
        private IDbContextTransaction? _transaction;

        public async Task CommitAsync()
        {
            try
            {
                _transaction ??= await _context.Database.BeginTransactionAsync();

                await _context.SaveChangesAsync();
                await _transaction.CommitAsync();
            }
            catch
            {
                await RollbackAsync();
                throw;
            }
            finally
            {
                await DisposeTransactionAsync();
            }
        }

        public async Task RollbackAsync()
        {
            if (_transaction != null)
            {
                await _transaction.RollbackAsync();
                await DisposeTransactionAsync();
            }
        }

        private async Task DisposeTransactionAsync()
        {
            if (_transaction != null)
            {
                await _transaction.DisposeAsync();
                _transaction = null;
            }
        }

        protected virtual void Dispose(bool disposing)
        {
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}