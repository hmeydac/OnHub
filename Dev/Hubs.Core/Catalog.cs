namespace Hubs.Core
{
    using System.Collections.Generic;
    using System.Linq;

    using Hubs.Framework;
    using Hubs.Persistance;

    public class Catalog
    {
        private readonly HubsContext context = new HubsContext();

        public Catalog(string owner)
        {
            this.Owner = owner;
        }

        protected string Owner { get; set; }

        public IEnumerable<Feed> GetFeeds()
        {
            return this.context.Feeds.Where(feed => feed.Owner.ToLower().Equals(this.Owner.ToLower())).ToList();
        }

        public Feed AddFeed(Feed feed)
        {
            feed.Owner = this.Owner;
            this.context.Feeds.Add(feed);
            this.context.SaveChanges();
            return feed;
        }
    }
}
