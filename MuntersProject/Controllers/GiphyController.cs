using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MuntersProject.Core.Services;

namespace MuntersProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GiphyController : ControllerBase
    {
        private readonly IGiphyService _giphyService;

        public GiphyController(IGiphyService giphyService)
        {
            _giphyService = giphyService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var giphys = await _giphyService.GetAllTrengingGif();
            return Ok(giphys);
        }
        [HttpGet]
        [Route("search/{search}")]
        public async Task<IActionResult> SearchGiphys(string search)
        {
            var giphys = await _giphyService.SearchGiphys(search);
            return Ok(giphys);
        }

    }
}
