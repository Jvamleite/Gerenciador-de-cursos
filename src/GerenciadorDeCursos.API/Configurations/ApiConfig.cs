using GerenciadorDeCursos.API.Models;
using Microsoft.Extensions.DependencyInjection;

namespace GerenciadorDeCursos.API.Configurations
{
    public static class ApiConfig
    {
        public static void ConfigureApi(this IServiceCollection services)
        {
            services.AddSingleton<IActionResultConverter, ActionResultConverter>();
        }
    }
}