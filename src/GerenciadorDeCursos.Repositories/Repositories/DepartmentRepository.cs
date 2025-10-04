using GerenciadorDeCursos.Domain.Entities;
using GerenciadorDeCursos.Domain.Repositories;
using GerenciadorDeCursos.Repositories.Context;

namespace GerenciadorDeCursos.Infrastructure.Repositories.Repositories
{
    internal class DepartmentRepository(
        DataContext context) : IDepartmentRepository
    {
        private DataContext _context = context;

        public Task<DepartmentEntity> AddAsync(DepartmentEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<DepartmentEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<DepartmentEntity> GetByCodeAsync(string code)
        {
            return await Task.FromResult(_context.Departments.FirstOrDefault(d => d.Code == code)));
        }

        public Task<DepartmentEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(DepartmentEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}