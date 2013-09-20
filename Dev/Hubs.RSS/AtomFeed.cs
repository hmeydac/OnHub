namespace Hubs.RSS
{
    using System.Collections.Generic;

    public class AtomFeed
    {
        private readonly string url;

        private readonly List<FeedEntry> entries;

        public AtomFeed(string url)
        {
            this.url = url;
            this.entries = new List<FeedEntry>();
        }

        public string Url
        {
            get
            {
                return this.url;
            }
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
            this.entries.AddRange(this.Reader.GetEntries(this.Url));
        }

        public bool Ping()
        {
            return true;
        }
    }
}
