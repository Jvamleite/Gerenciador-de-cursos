using GerenciadorDeCursos.Application.Dtos.Course.Request;
using GerenciadorDeCursos.Application.Dtos.Course.Response;

namespace GerenciadorDeCursos.Application.Interfaces
{
    internal interface ICreateCourseUseCase : IUseCase<CreateCourseRequestDto, CourseResponseDto>
    {
    }
}