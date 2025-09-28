using GerenciadorDeCursos.Domain.Entities.Course;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorDeCursos.Domain.Entities
{
    [Table("Department")]
    public class DepartmentEntity
    {
        [Key]
        public Guid Id { get; init; } = Guid.NewGuid();

        [Required]
        public string Name { get; init; }

        [Required]
        public string Code { get; init; }

        public IList<CourseEntity> Courses { get; set; } = [];

        public DepartmentEntity(
            string name,
            string code)
        {
            Name = name;
            Code = code;
        }
    }
}