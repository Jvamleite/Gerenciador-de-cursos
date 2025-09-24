using GerenciadorDeCursos.Domain.Entities.Course;

namespace GerenciadorDeCursos.Domain.Entities.User
{
    internal class TeacherEntity(string name, string lastName, string cpf, string email) :
        UserEntity(name, lastName, cpf, email)
    {
        public IEnumerable<CourseEntity> Courses { get; set; } = [];
    }
}