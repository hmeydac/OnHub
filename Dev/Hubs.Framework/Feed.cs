namespace Hubs.Framework
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Feed
    {
        public Feed(string name, Uri uri)
        {
            if (string.IsNullOrEmpty(name))
            {
                throw new ArgumentNullException("name");
            }

            if (uri == null)
            {
                throw new ArgumentNullException("uri");
            }

            this.Name = name;
            this.Uri = uri;
            this.Entries = new List<FeedEntry>();
        }

        public string Name { get; set; }

        public Uri Uri { get; set; }

        public List<FeedEntry> Entries { get; set; }

        public virtual FeedEntry LastEntry()
        {
            return this.Entries.Last();
        }

        public virtual FeedEntry FirstEntry()
        {
            return this.Entries.FirstOrDefault();
        }
    }
}
