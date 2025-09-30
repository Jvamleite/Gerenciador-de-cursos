using GerenciadorDeCursos.Domain.Entities.User;
using GerenciadorDeCursos.Infrastructure.Repositories.Interfaces;
using GerenciadorDeCursos.Repositories.Context;

namespace GerenciadorDeCursos.Infrastructure.Repositories.Repositories
{
    internal class TeacherRepository : ITeacherRepository
    {
        private readonly DataContext _context;

        public TeacherRepository(
            DataContext context)
        {
            _context = context;
        }

        public Task AddAsync(TeacherEntity entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TeacherEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<TeacherEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<TeacherEntity> GetTeacherByName(string name)
        {
            return await Task.FromResult(_context.Teachers.FirstOrDefault(t => t.Name == name));
        }

        public Task UpdateAsync(TeacherEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}