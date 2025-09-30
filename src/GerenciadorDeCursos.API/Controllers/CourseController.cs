using GerenciadorDeCursos.API.Models;
using GerenciadorDeCursos.Application.Dtos.Course.Response;
using GerenciadorDeCursos.Shared;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeCursos.Controllers
{
    public class CourseController(IActionResultConverter actionResultConverter) : BaseController(actionResultConverter)
    {
        /// <summary>
        /// Criar curso (Somente autorizado para professores administradores)
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(CourseResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateCourse([FromBody] CreateCourseRequest createCourseRequest, [FromServices] ICreateCourseUseCase _useCase)
        {
            _logger.LogWarning("Iniciando a criação de um novo curso");
            var response = await _useCase.CreateCourseAsync(createCourseRequest);

            return _actionResultConverter.Convert(response);
        }
    }
}