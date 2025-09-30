using AutoMapper;
using GerenciadorDeCursos.Application.Dtos.Course.Request;
using GerenciadorDeCursos.Domain.Entities.Course;

namespace GerenciadorDeCursos.Domain.Model.Mapper
{
    internal class MapperDtoEntityConfigure : Profile
    {
        public MapperDtoEntityConfigure()
        {
            CreateMap<CreateCourseRequestDto, CourseEntity>
                ();
        }
    }
}