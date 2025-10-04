using Microsoft.OpenApi.Models;

namespace GerenciadorDeCursos.API.Configurations
{
    public static class SwaggerConfig
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GerenciadorDeCursos.API", Version = "v1", Description = "Simulação de um portal de inscrição em cursos e cadastramento de usuários" });
            });
        }
    }
}