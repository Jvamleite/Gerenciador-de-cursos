using AutoMapper;
using GerenciadorDeCursos.Application.Dtos.Course.Request;
using GerenciadorDeCursos.Application.Dtos.Course.Response;
using GerenciadorDeCursos.Domain.Entities.Course;

namespace GerenciadorDeCursos.Domain.Model.Mapper
{
    internal class MapperDtoEntityConfigure : Profile
    {
        public MapperDtoEntityConfigure()
        {
            CreateMap<CreateCourseRequestDto, CourseEntity>();

            CreateMap<CourseEntity, CourseResponseDto>()
                .ForMember(dest => dest.Teacher, opt => opt.MapFrom(src => src.Teacher.Name))
                .ForMember(dest => dest.Department, opt => opt.MapFrom(src => src.Department.Code));
        }
    }
}