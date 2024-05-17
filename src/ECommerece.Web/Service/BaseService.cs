using ECommerece.Web.Models;
using ECommerece.Web.Service.IService;
using Newtonsoft.Json;
using System.Net;
using System.Text;
using static ECommerece.Web.Utility.SD;

namespace ECommerece.Web.Service
{
    public class BaseService : IBaseService
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public BaseService(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<ResponseDTO?> SendAsync(RequestDTO requestdto)
        {
            try
            {
                HttpClient client = _httpClientFactory.CreateClient("EcommereceApi");
                HttpRequestMessage message = new();
                if (requestdto.contentType == ContentType.MultipartFormData)
                {
                    message.Headers.Add("Accept", "*/*");
                }
                {
                    message.Headers.Add("Accept", "application/json");
                }
                message.RequestUri = new Uri(requestdto.Url);
                if (requestdto.Data != null)
                {
                    message.Content = new StringContent(JsonConvert.SerializeObject(requestdto.Data), Encoding.UTF8, "application/json");
                }
                HttpResponseMessage? apiresponse = null;
                switch (requestdto.APIType)
                {
                    case ApiType.POST:
                        message.Method = HttpMethod.Post;
                        break;
                    case ApiType.PUT:
                        message.Method = HttpMethod.Put;
                        break;
                    case ApiType.DELETE:
                        message.Method = HttpMethod.Delete;
                        break;
                    default:
                        message.Method = HttpMethod.Get;
                        break;

                }
                apiresponse = await client.SendAsync(message);

                switch (apiresponse.StatusCode)
                {
                    case HttpStatusCode.NotFound:
                        return new() { IsSuccess = false, Message = "Not Found" };
                    case HttpStatusCode.Forbidden:
                        return new() { IsSuccess = false, Message = "Access Denied" };
                    case HttpStatusCode.Unauthorized:
                        return new() { IsSuccess = false, Message = "Unauthorized" };
                    case HttpStatusCode.InternalServerError:
                        return new() { IsSuccess = false, Message = "Internal Server Error" };
                    default:
                        var apiContent = await apiresponse.Content.ReadAsStringAsync();
                        var apiResponseDto = JsonConvert.DeserializeObject<ResponseDTO>(apiContent);
                        return apiResponseDto;
                }
            }
            catch (Exception ex)
            {
                var dto = new ResponseDTO
                {
                    Message = ex.Message.ToString(),
                    IsSuccess = false
                };
                return dto;
            }
        }
            
        }
    }
 
