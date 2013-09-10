namespace Hubs.RSS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using QDFeedParser;

    public class RssReader
    {
        public string GetLastEntry(string url)
        {
            var parser = new HttpFeedFactory();
            var feed = parser.CreateFeed(new Uri(url));
            return feed.Items.Last().Content;
        }

        public bool Ping(string url)
        {
            var parser = new HttpFeedFactory();
            return parser.PingFeed(new Uri(url));
        }

        public int GetFeedEntryCount(string url)
        {
            var parser = new HttpFeedFactory();
            var feed = parser.CreateFeed(new Uri(url));
            return feed.Items.Count;
        }
    }
}
