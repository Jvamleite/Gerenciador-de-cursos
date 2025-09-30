using GerenciadorDeCursos.API.Models;
using GerenciadorDeCursos.Application.Dtos.Course.Request;
using GerenciadorDeCursos.Application.Dtos.Course.Response;
using GerenciadorDeCursos.Application.Interfaces;
using GerenciadorDeCursos.Shared;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeCursos.Controllers
{
    public class CourseController(IActionResultConverter actionResultConverter)
        : BaseController(actionResultConverter)
    {
        /// <summary>
        /// Criar curso
        /// </summary>
        /// <returns></returns>
        [ProducesResponseType(typeof(CourseResponseDto), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(Response), StatusCodes.Status400BadRequest)]
        [HttpPost]
        public async Task<IActionResult> CreateCourse(
            [FromBody] CreateCourseRequestDto createCourseRequest,
            [FromServices] ICreateCourseUseCase _useCase)
        {
            Response<CourseResponseDto> response = await _useCase.Execute(createCourseRequest);

            return _actionResultConverter.Convert(response);
        }
    }
}