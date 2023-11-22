using System.Text.Json.Serialization;

namespace HackerNews.Model
{
    /// <summary>
    /// The public facing format of the news item
    /// </summary>
    public class NewsItem
    {
        public string Title { get; set; } 
        public string Uri { get; set; }
        public string PostedBy { get; set; }

        [JsonConverter(typeof(DateTimeJsonConverter))]
        public DateTime Time { get; set; }

        public int Score { get; set; }
        public int CommentCount { get; set; }
    }
}
