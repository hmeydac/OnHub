namespace Hubs.Framework
{
    using System;

    public class FeedEntry
    {
        public FeedEntry(string title)
        {
            this.Title = title;
        }

        public string Title { get; set; }

        public DateTime EntryDate { get; set; }

        public string Body { get; set; }

        public override string ToString()
        {
            return string.Format("Entry: {0}", this.Title);
        }
    }
}
