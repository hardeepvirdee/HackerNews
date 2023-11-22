using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HackerNews.Model
{
    /// <summary>
    /// Represents the Hacker News source news item
    /// </summary>
    public class HackerNewsItem
    {
        public int Id { get; set; }
        public string Deleted { get; set; }
        public string Type { get; set; }
        public string By { get; set; }
        public int Descendants { get; set; } // for stories or polls the total comment count
        public string Text { get; set; }
        public string Dead { get; set; }
        public int Parent { get; set; }
        public int[] Kids { get; set; }
        public int Score { get; set; }
        public long Time { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        public int Poll { get; set; }
        public int[] Parts {get; set; }
    }
}
