using GerenciadorDeCursos.Domain.Entities.Course;
using GerenciadorDeCursos.Domain.Repositories;

namespace GerenciadorDeCursos.Infrastructure.Repositories.Interfaces
{
    public interface ICourseRepository : IRepository<CourseEntity>;
}