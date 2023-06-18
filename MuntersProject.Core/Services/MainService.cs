using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace MuntersProject.Core.Services
{
    public class MainService : IMainService
    {
        public async Task<TResponse> HttpRequestAsync<TRequest, TResponse>(string url, HttpMethod httpMethod,
            TRequest requestBody = default, bool handleErrors = false)
        {
            using (var client = new HttpClient())
            {
                var request = new HttpRequestMessage
                {
                    Method = httpMethod,
                    RequestUri = new Uri(url)
                };
                if (requestBody != null)
                {
                    var json = JsonSerializer.Serialize(requestBody);
                    request.Content = new StringContent(json, Encoding.UTF8, "application/json");
                }
                var response = await client.SendAsync(request);
                if (handleErrors && !response.IsSuccessStatusCode)
                {
                    throw new HttpRequestException($"HTTP request failed with status code {response.StatusCode}");
                }
                var responseJson = await response.Content.ReadAsStringAsync();
                var responseData = JsonSerializer.Deserialize<TResponse>(responseJson);
                return responseData;
            }
        }
    }
}
