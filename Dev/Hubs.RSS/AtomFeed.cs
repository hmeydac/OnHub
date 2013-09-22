namespace Hubs.RSS
{
    using System;
    using System.Collections.Generic;

    using Hubs.Framework;

    public class AtomFeed : Feed
    {
        private readonly string url;

        private readonly List<FeedEntry> entries;

        public AtomFeed()
        {
            this.Id = Guid.NewGuid();
        }

        public AtomFeed(string url)
        {
            this.Id = Guid.NewGuid();
            this.Locator = url;
            this.entries = new List<FeedEntry>();
        }

        public List<FeedEntry> Entries
        {
            get
            {
                return this.entries;
            }
        }

        public IFeedReader Reader { get; set; }

        public void PopulateEntries()
        {
            this.entries.Clear();
            this.entries.AddRange(this.Reader.GetEntries(this.Locator));
        }

        public bool Ping()
        {
            return true;
        }
    }
}
