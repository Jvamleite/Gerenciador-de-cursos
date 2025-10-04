using GerenciadorDeCursos.API.Models;
using GerenciadorDeCursos.Domain.Model.Mapper;

namespace GerenciadorDeCursos.API.Configurations
{
    public static class ApiConfig
    {
        public static void ConfigureApi(this IServiceCollection services)
        {
            services.AddSingleton<IActionResultConverter, ActionResultConverter>();
            services.AddAutoMapper(typeof(MapperDtoEntityConfigure));
        }
    }
}