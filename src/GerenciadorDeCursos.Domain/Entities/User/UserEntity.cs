using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace GerenciadorDeCursos.Domain.Entities.User
{
    [Table("User")]
    public class UserEntity
    {
        [Key]
        public Guid Id { get; init; }

        [Required]
        public string Name { get; init; }

        [Required]
        public string LastName { get; init; }

        [Required]
        public string CPF { get; init; }

        [Required]
        public string Email { get; init; }

        [Required]
        public string Username { get; init; }

        [Required]
        public string Password { get; init; }

        public UserEntity()
        { }

        public UserEntity(
            string name,
            string lastName,
            string cpf,
            string email)
        {
            Id = Guid.NewGuid();
            Name = name;
            LastName = lastName;
            CPF = cpf;
            Email = email;
            Username = GenerateUsername();
            Password = GeneratePassword();
        }

        private string GenerateUsername() => $"{Name}_{LastName}".Replace(" ", "_");

        private static string GeneratePassword() => throw new NotImplementedException();
    }
}