using GerenciadorDeCursos.Infrastructure.Repositories.Interfaces;
using GerenciadorDeCursos.Infrastructure.Repositories.Repositories;

namespace GerenciadorDeCursos.API.Configurations
{
    public static class RepositoryConfig
    {
        public static void ConfigureRepository(this IServiceCollection services)
        {
            services.AddScoped<ITeacherRepository, TeacherRepository>();
            services.AddScoped<ICourseRepository, CourseRepository>();
        }
    }
}