using GerenciadorDeCursos.Domain.Entities.Course;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorDeCursos.Domain.Entities.User
{
    [Table("Student")]
    public class StudentEntity(string name, string lastName, string cpf, string email)
                : UserEntity(name, lastName, cpf, email)
    {
        [Required]
        private Guid RegistrationNumber { get; } = Guid.NewGuid();

        private IList<CourseEntity> EnrolledCourses { get; } = new List<CourseEntity>();

        public void EnrollCourse(CourseEntity course) => EnrolledCourses.Add(course);

        public void UnenrollCourse(CourseEntity course) => EnrolledCourses.Remove(course);

        public IList<CourseEntity> GetEnrroledCourses() => EnrolledCourses;

        public StudentEntity() : this(string.Empty, string.Empty, string.Empty, string.Empty)
        {
        }
    }
}