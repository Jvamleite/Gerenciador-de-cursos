using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace GerenciadorDeCursos.Repositories.Context
{
    public class DataContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        public DataContext CreateDbContext(string[] args)
        {
            DbContextOptionsBuilder<DataContext> optionsBuilder = new();
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=GerenciadorDeCursos;Integrated Security=true");

            return new DataContext(optionsBuilder.Options);
        }
    }
}