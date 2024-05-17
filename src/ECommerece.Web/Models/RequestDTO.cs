using static ECommerece.Web.Utility.SD;

namespace ECommerece.Web.Models
{
    public class RequestDTO
    {
        public ApiType APIType { get; set; } = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
        public ContentType contentType { get; set; } = ContentType.Json;
    }
}
