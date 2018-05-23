using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Viewer.Services
{

    public interface IRequestService
    {
        Task<string> HttpRequest(string url);
    }    
    public class RequestService : IRequestService
    {
        private readonly HttpClient _httpClient;

        public RequestService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<string> HttpRequest(string stringUri)
        {
            return await _httpClient.GetStringAsync(new Uri(stringUri));
        }
    }
}
