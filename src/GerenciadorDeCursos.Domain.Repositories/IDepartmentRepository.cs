using GerenciadorDeCursos.Domain.Entities;

namespace GerenciadorDeCursos.Domain.Repositories
{
    public interface IDepartmentRepository : IRepository<DepartmentEntity>
    {
        Task<DepartmentEntity> GetByCodeAsync(string code);
    }
}