namespace Hubs.Framework
{
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

    public class Hub
    {
        public Hub(string name)
        {
            this.Name = name;
            this.Feeds = new List<Feed>();
        }

        public string Name { get; set; }

        public List<Feed> Feeds { get; private set; }

        public int FeedsCount
        {
            get
            {
                return this.Feeds.Count;
            }
        }

        public List<FeedEntry> Entries
        {
            get
            {
                var entries = new List<FeedEntry>();
                this.Feeds.ForEach(e => entries.AddRange(e.Entries));
                return entries.OrderByDescending(e => e.EntryDate).ToList();
            }
        }

        public void AddFeed(Feed feed)
        {
            this.Feeds.Add(feed);
        }

        public void Remove(int index)
        {
            this.Feeds.RemoveAt(index);
        }
    }
}
