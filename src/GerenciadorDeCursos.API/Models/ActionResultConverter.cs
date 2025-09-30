using GerenciadorDeCursos.Shared;
using GerenciadorDeCursos.Shared.Enums;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace GerenciadorDeCursos.API.Models
{
    public interface IActionResultConverter
    {
        IActionResult Convert<T>(Response<T> response, bool noContentIfSuccess = false);
    }

    public class ActionResultConverter : IActionResultConverter
    {
        public IActionResult Convert<T>(Response<T> response, bool noContentIfSuccess = false)
        {
            if (response == null)
            {
                return BuildResponse(new[] { new Response("ActionResultConverter Error") }, ResponseStatus.InternalServerError);
            }

            if (response.IsSuccess)
            {
                if (noContentIfSuccess)
                {
                    return new NoContentResult();
                }
                else
                {
                    return BuildResponse(response, response.Status);
                }
            }
            else
            {
                return BuildResponse(response, response.Status);
            }
        }

        private static ObjectResult BuildResponse(object data, ResponseStatus status)
        {
            HttpStatusCode httpStatus = GetHttpStatusCode(status);

            return new ObjectResult(data)
            {
                StatusCode = (int)httpStatus
            };
        }

        private static HttpStatusCode GetHttpStatusCode(ResponseStatus status)
        {
            return status switch
            {
                ResponseStatus.BadRequest => HttpStatusCode.BadRequest,
                ResponseStatus.Forbidden => HttpStatusCode.Forbidden,
                ResponseStatus.NotFound => HttpStatusCode.NotFound,
                ResponseStatus.Ok => HttpStatusCode.OK,
                ResponseStatus.Created => HttpStatusCode.Created,
                _ => HttpStatusCode.InternalServerError,
            };
        }
    }
}