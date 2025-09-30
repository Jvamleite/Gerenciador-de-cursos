namespace GerenciadorDeCursos.Application.Dtos.Course.Request
{
    public record CreateCourseRequestDto(string Title, string TeachersName, DateTime InitialDate, DateTime FinalDate, int Vacancies, string Department);
}