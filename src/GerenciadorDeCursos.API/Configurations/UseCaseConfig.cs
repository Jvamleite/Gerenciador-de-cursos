using GerenciadorDeCursos.Application.Interfaces;
using GerenciadorDeCursos.Application.UseCases;

namespace GerenciadorDeCursos.Configurations
{
    public static class UseCaseConfig
    {
        public static void ConfigureUseCases(this IServiceCollection services)
        {
            //Course
            services.AddScoped<ICreateCourseUseCase, CreateCourseUseCase>();
        }
    }
}