using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Extensions.Caching.Memory;
using System.Diagnostics;

namespace HackerNews.Model
{
    public class HackerNewsService
    {
        private static readonly Mapper _mapper;
        private static readonly HttpClient _httpClient;
        private static readonly MemoryCache _memoryCache = new(new MemoryCacheOptions());
        private static TimeSpan _timeOut => TimeSpan.FromMinutes(1);

        static HackerNewsService()  
        {
            MapperConfiguration configuration = new MapperConfiguration(cfg => cfg.AddProfile(new ModelProfile()));
            configuration.AssertConfigurationIsValid();
            _mapper = new Mapper(configuration);

            _httpClient = new();
            _httpClient.BaseAddress = new Uri(Constants.HackerNewsUrl);
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(Constants.ApplicationJsonString));
        }

        public async Task<IEnumerable<NewsItem>> GetBestStories(int count = 200)
        {
            if (count > 200)
            {
                count = 200;
            }

            int[]? storyIds = await _memoryCache.GetOrCreateAsync("bestStories", entry =>
            {
                entry.AbsoluteExpirationRelativeToNow = _timeOut;
                return GetBestStoryIds();
            });

            List<NewsItem> newsItems = new();
            int counter = 0;
            foreach (int storyId in storyIds)
            {
                HackerNewsItem? hackerNewsItem = await _memoryCache.GetOrCreateAsync(storyId, entry =>
                {
                    entry.AbsoluteExpirationRelativeToNow = _timeOut;
                    return GetStoryById(storyId);
                });

                if (hackerNewsItem.Deleted == "true" || hackerNewsItem.Dead == "true")
                {
                    continue;
                }

                newsItems.Add(_mapper.Map<NewsItem>(hackerNewsItem));
                counter++;
                if (counter >= count)
                {
                    break;
                }
            }

            return newsItems;
        }

        internal async Task<int[]> GetBestStoryIds()
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"/v0/beststories.json");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<int[]>();
        }

        internal async Task<HackerNewsItem> GetStoryById(int id)
        {
            HttpResponseMessage response = await _httpClient.GetAsync($"/v0/item/{id}.json");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadAsAsync<HackerNewsItem>();
        }
    }
}
