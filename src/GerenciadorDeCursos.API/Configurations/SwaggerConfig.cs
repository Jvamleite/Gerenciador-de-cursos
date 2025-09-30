using Microsoft.OpenApi.Models;
using System.Reflection;

namespace GerenciadorDeCursos.API.Configurations
{
    public static class SwaggerConfig
    {
        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "GerenciadorDeCursos.API", Version = "v1", Description = "Simulação de um portal de inscrição em cursos e cadastramento de usuários" });

                string xmlFilename = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                c.IncludeXmlComments(Path.Combine(AppContext.BaseDirectory, xmlFilename));
            });
        }
    }
}