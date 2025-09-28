using GerenciadorDeCursos.Domain.Entities.Course.Enums;
using GerenciadorDeCursos.Domain.Entities.User;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorDeCursos.Domain.Entities.Course
{
    [Table("Courses")]
    public class CourseEntity
    {
        [Key]
        public Guid Id { get; private set; } = Guid.NewGuid();

        [Required]
        public string Code { get; init; }

        [Required]
        public string Title { get; init; }

        [Required]
        public DateTime InitialDate { get; init; }

        [Required]
        public DateTime FinalDate { get; init; }

        [Required]
        public Guid DepartmentId { get; init; }

        [ForeignKey("DepartmentId")]
        [Required]
        public DepartmentEntity Department { get; init; }

        [Required]
        public Status Status { get; set; } = Status.Previsto;

        public Guid TeacherId { get; init; }

        [ForeignKey("TeacherId")]
        public TeacherEntity Teacher { get; init; }

        public IList<StudentEntity> Students { get; init; } = [];

        [Required]
        public int Vacancies { get; set; }

        public CourseEntity()
        { }

        public CourseEntity(
            string title,
            DateTime initialDate,
            DateTime finalDate,
            TeacherEntity teacher,
            DepartmentEntity department,
            int vacancies
            )
        {
            Code = GenerateCode();
            Title = title;
            Teacher = teacher;
            Department = department;
            InitialDate = initialDate;
            FinalDate = finalDate;
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