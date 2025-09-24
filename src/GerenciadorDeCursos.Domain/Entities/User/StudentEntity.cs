using GerenciadorDeCursos.Domain.Entities.Course;

namespace GerenciadorDeCursos.Domain.Entities.User
{
    internal class StudentEntity(string name, string lastName, string cpf, string email) :
        UserEntity(name, lastName, cpf, email)
    {
        private Guid RegistrationNumber { get; } = Guid.NewGuid();

        private IList<CourseEntity> EnrroledCourses { get; } = [];

        public void EnrollCourse(CourseEntity course) => EnrroledCourses.Add(course);

        public void UnenrollCourse(CourseEntity course) => EnrroledCourses.Remove(course);

        public IList<CourseEntity> GetEnrroledCourses() => EnrroledCourses;
    }
}