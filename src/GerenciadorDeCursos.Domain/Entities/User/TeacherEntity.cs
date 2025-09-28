using GerenciadorDeCursos.Domain.Entities.Course;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorDeCursos.Domain.Entities.User
{
    [Table("Teacher")]
    public class TeacherEntity(string name, string lastName, string cpf, string email) :
        UserEntity(name, lastName, cpf, email)
    {
        public IEnumerable<CourseEntity> Courses { get; set; } = [];

        public TeacherEntity() : this(string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }
    }
}