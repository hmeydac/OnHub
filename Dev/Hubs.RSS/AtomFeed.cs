namespace Hubs.RSS
{
    using System;
    using System.Collections.Generic;

    using Hubs.Framework;

    public class AtomFeed : Feed
    {
        public AtomFeed(string name, Uri uri)
            : base(name, uri)
        {
            this.Entries = new List<FeedEntry>();
        }

        public IFeedReader Reader { get; set; }

        public override FeedEntry LastEntry()
        {
            return this.Reader.GetLastEntry();
        }

        public void Populate()
        {
            this.Entries.Clear();
            this.Entries.AddRange(this.Reader.GetEntries());
        }
    }
}
