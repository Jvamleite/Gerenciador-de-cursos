using GerenciadorDeCursos.Domain.Entities.Course.Enums;

namespace GerenciadorDeCursos.Application.Dtos.Course.Response
{
    public record CourseResponseDto(string Code, string Title, string Teacher, DateTime InitialDate, DateTime FinalDate, Status Status, int Vacancies, string Department);
}