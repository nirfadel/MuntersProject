using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Configuration;
using MuntersProject.Core.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MuntersProject.Core.Services
{
    public class GiphyService : IGiphyService
    {
        private readonly IMainService _mainService;
        private readonly IMemoryCache _memoryCache;
        private readonly IConfiguration _configuration;
        private string _baseUrl;
        public GiphyService(IMainService mainService, IConfiguration configuration, IMemoryCache memoryCache)
        {
            _mainService = mainService;
            _configuration = configuration;
            _memoryCache = memoryCache;
            _baseUrl = _configuration["GiphySettings:baseUrl"].ToString();
        }
        public async Task<TrengingGif> GetAllTrengingGif()
        {
            var key = _configuration["GiphySettings:key"].ToString();
            var trndingGifs = _memoryCache.Get<TrengingGif>("trendingGifs");
            if (trndingGifs is null)
            {
                var result = await _mainService.HttpRequestAsync<object, TrengingGif>($"{_baseUrl}/gifs/trending?api_key={key}", HttpMethod.Get);
                _memoryCache.Set("trendingGifs", result, TimeSpan.FromMinutes(2));
            }
            return trndingGifs;
        }

        public async Task<TrengingGif> SearchGiphys(string searchText)
        {
            var key = _configuration["GiphySettings:key"].ToString();
            return await _mainService.HttpRequestAsync<object, TrengingGif>($"{_baseUrl}/stickers/search?api_key={key}&q={searchText}", HttpMethod.Get);
        }
    }
}
