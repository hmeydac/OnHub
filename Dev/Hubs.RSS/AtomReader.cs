namespace Hubs.RSS
{
    using System;
    using System.Linq;

    using Hubs.Framework;

    using QDFeedParser;

    public class AtomReader : IFeedReader
    {
        private HttpFeedFactory parser;

        private IFeed feed;

        public AtomReader(Uri uri)
        {
            this.Uri = uri;
        }

        protected Uri Uri { get; set; }

        protected IFeed Feed
        {
            get
            {
                return this.feed ?? (this.feed = this.Parser.CreateFeed(this.Uri));
            }
        }

        protected HttpFeedFactory Parser
        {
            get
            {
                return this.parser ?? (this.parser = new HttpFeedFactory());
            }
        }

        public FeedEntry GetLastEntry()
        {
            var item = this.Feed.Items.First();
            return new FeedEntry(item.Title) { EntryDate = item.DatePublished, Body = item.Content };
        }

        public bool Ping()
        {
            return this.Parser.PingFeed(new Uri(this.Feed.FeedUri));
        }

        public int GetFeedEntryCount()
        {
            return this.Feed.Items.Count;
        }

        public BaseFeedItem GetFirstEntry()
        {
            return this.Feed.Items.LastOrDefault();
        }
    }
}
