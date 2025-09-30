using GerenciadorDeCursos.Domain.Entities.Course;
using GerenciadorDeCursos.Domain.Entities.User;
using Microsoft.EntityFrameworkCore;

namespace GerenciadorDeCursos.Repositories.Context
{
    public class DataContext : DbContext
    {
        public DbSet<CourseEntity> Courses { get; set; }
        public DbSet<UserEntity> Users { get; set; }
        public DbSet<TeacherEntity> Teachers { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(DataContext).Assembly);
        }
    }
}