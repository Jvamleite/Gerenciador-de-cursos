using GerenciadorDeCursos.Shared.Enums;
using System.Text.Json.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace GerenciadorDeCursos.Shared
{
    public class Response
    {
        public Response()
        {
        }

        public Response(object result)
            : this()
        {
            Result = result;
        }

        public Response(ResponseStatus responseStatus, string message)
            : this()
        {
            Status = responseStatus;
            Message = message;
        }

        public ResponseStatus Status { get; set; } = ResponseStatus.Ok;

        public string Message { get; set; }

        public Error[] Errors { get; set; }

        [JsonIgnore]
        public object Result { get; set; }

        [JsonIgnore]
        public bool IsSuccess => (Errors == null || Errors.Length == 0) &&
                                 Status == ResponseStatus.Ok;
    }

    public class Response<TResult> : Response
    {
        public Response()
        { }

        public Response(TResult result) : base(result)
        {
        }

        public Response(ResponseStatus responseStatus, string message) : base(responseStatus, message)
        {
        }

        public new TResult Result
        {
            get => (TResult)base.Result;
            set => base.Result = value;
        }
    }
}