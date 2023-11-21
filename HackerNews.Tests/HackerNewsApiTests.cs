using HackerNews.Model;

namespace HackerNews.Tests
{
    public class HackerNewsApiTests
    {
        private HackerNewsService _service;

        [SetUp]
        public void Setup()
        {
            _service = new();
        }

        [Test]
        public async Task GetBestStoryIdTest()
        {
            int[] storyIds = await _service.GetBestStoryIds();
            Assert.IsTrue(storyIds.Length > 1);
        }

        [Test]
        public async Task GetStoryById()
        {
            HackerNewsItem item = await _service.GetStoryById(21233041);
            Assert.IsNotNull(item);
        }
    }
}