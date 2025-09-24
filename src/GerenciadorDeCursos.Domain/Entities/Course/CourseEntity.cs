using GerenciadorDeCursos.Domain.Entities.Course.Enums;
using GerenciadorDeCursos.Domain.Entities.User;

namespace GerenciadorDeCursos.Domain.Entities.Course
{
    internal class CourseEntity
    {
        public Guid Id { get; } = Guid.NewGuid();
        public string Code { get; init; }
        public string Title { get; init; }
        public DateTime InitialDate { get; init; }
        public DateTime FinalDate { get; init; }
        public Status Status { get; set; }
        public Guid TeacherId { get; init; }
        public TeacherEntity Teacher { get; init; }
        public IList<StudentEntity> Students { get; init; } = [];
        public int Vacancies { get; set; }

        public CourseEntity(
            string title,
            DateTime initialDate,
            DateTime finalDate,
            TeacherEntity teacher,
            int vacancies
            )
        {
            Code = GenerateCode();
            Title = title;
            Teacher = teacher;
            InitialDate = initialDate;
            FinalDate = finalDate;
            Status = Status.Previsto;
            Vacancies = vacancies;
        }

        public static string GenerateCode()
            => throw new NotImplementedException();

        public void ChangeStatus()
        {
            if (CourseIsOngoing())
            {
                Status = Status.EmAndamento;
            }
            else if (CourseIsFinished())
            {
                Status = Status.Concluido;
            }
            else
            {
                Status = Status.Previsto;
            }
        }

        public void EnrollStudent(StudentEntity student)
        {
            Students.Add(student);
            Vacancies--;
        }

        private bool CourseIsOngoing() => DateTime.Now > InitialDate && DateTime.Now < FinalDate;

        private bool CourseIsFinished() => DateTime.Now > FinalDate;

        public bool NoVacancy() => Vacancies == 0;
    }
}