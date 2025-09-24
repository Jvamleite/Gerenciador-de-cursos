namespace GerenciadorDeCursos.Domain.Entities.User
{
    internal class UserEntity
    {
        public Guid Id { get; init; }
        public string Name { get; init; }
        public string LastName { get; init; }
        public string CPF { get; init; }
        public string Email { get; init; }
        public string Username { get; init; }
        public string Password { get; init; }

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