using GerenciadorDeCursos.Domain.Entities.User;
using GerenciadorDeCursos.Domain.Repositories;

namespace GerenciadorDeCursos.Infrastructure.Repositories.Interfaces
{
    public interface ITeacherRepository : IRepository<TeacherEntity>
    {
        Task<TeacherEntity> GetTeacherByName(string name);
    }
}