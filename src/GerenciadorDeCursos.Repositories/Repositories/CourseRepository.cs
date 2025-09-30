using GerenciadorDeCursos.Domain.Entities.Course;
using GerenciadorDeCursos.Infrastructure.Repositories.Interfaces;
using GerenciadorDeCursos.Repositories.Context;

namespace GerenciadorDeCursos.Infrastructure.Repositories.Repositories
{
    public class CourseRepository(
        DataContext context) : ICourseRepository
    {
        public async Task<CourseEntity> AddAsync(CourseEntity entity)
        {
            return (await context.Courses.AddAsync(entity)).Entity;
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

        public async Task<CourseEntity> GetCourseByTitleAsync(string title)
        {
            return await Task.FromResult(context.Courses.FirstOrDefault(c => c.Title == title));
        }

        public Task UpdateAsync(CourseEntity entity)
        {
            throw new NotImplementedException();
        }
    }
}