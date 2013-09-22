namespace Hubs.RSS
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Hubs.Framework;

    using QDFeedParser;

    public class AtomReader : IFeedReader
    {
        public IEnumerable<FeedEntry> GetEntries(string url)
        {
            var factory = new HttpFeedFactory();
            var feed = factory.CreateFeed(new Uri(url));
            return feed.Items.Select(feedItem => new FeedEntry { Title = feedItem.Title }).ToList();
        }
    }
}
