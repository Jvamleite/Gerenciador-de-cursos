using GerenciadorDeCursos.Domain.Entities.Course;
using GerenciadorDeCursos.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeCursos.Repositories.Context
{
    internal class DataContext : DbContext
    {
        public DbSet<CourseEntity> Course { get; set; }
        public DbSet<UserEntity> User { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}