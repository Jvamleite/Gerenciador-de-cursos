using GerenciadorDeCursos.Domain.Entities.Course;
using GerenciadorDeCursos.Infrastructure.Repositories.Interfaces;
using GerenciadorDeCursos.Repositories.Context;

namespace GerenciadorDeCursos.Infrastructure.Repositories.Repositories
{
    internal class CourseRepository(
        DataContext context) : ICourseRepository
    {
        public async Task AddAsync(CourseEntity entity)
        {
            await context.Courses.AddAsync(entity);
        }

        public Task DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<CourseEntity>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<CourseEntity> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task UpdateAsync(CourseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}