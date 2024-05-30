using System.Net;

namespace be_ecom_shop.DTOs
{
    public class ResponseDto
    {
        public object Result { get; set; }
        public bool Success { get; set; }
        public HttpStatusCode StatusCode { get; set; }  
        public string Message { get; set; }
    }
}
