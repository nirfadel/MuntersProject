using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuntersProject.Core.Services
{
    public interface IMainService
    {
        Task<TResponse> HttpRequestAsync<TRequest, TResponse>(string url, HttpMethod httpMethod, TRequest requestBody = default, bool handleErrors = false);
    }
}
