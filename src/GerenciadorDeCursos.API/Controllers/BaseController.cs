using GerenciadorDeCursos.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace GerenciadorDeCursos.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class BaseController(IActionResultConverter actionResultConverter) : ControllerBase
    {
        public readonly IActionResultConverter _actionResultConverter = actionResultConverter;
    }
}