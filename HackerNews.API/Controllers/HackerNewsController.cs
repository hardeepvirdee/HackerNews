using HackerNews.Model;
using Microsoft.AspNetCore.Mvc;

namespace HackerNews.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class HackerNewsController : ControllerBase
    {
        [HttpGet(Name = "Get")]
        public async Task<IEnumerable<NewsItem>> Get(int count = 200)
        {
            HackerNewsService service = new();
            return await service.GetBestStories(count);
        }
    }
}
