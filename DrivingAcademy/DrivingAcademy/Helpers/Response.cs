using System.Net;

namespace DrivingAcademy.Helpers
{
    public class Response
    {
        public string Message { get; set; } = null!;
        public object Data { get; set; } = null!;
        public HttpStatusCode StatusCode { get; set; }
    }
}
