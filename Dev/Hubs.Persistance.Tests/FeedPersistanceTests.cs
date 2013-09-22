namespace Hubs.Persistance.Tests
{
    using System;
    using System.Linq;

    using Hubs.Core;
    using Hubs.Framework;
    using Hubs.RSS;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FeedPersistanceTests : TransactionalUnitTest
    {
        private HubsContext context;
        
        public override void SetUp()
        {
            this.context = new HubsContext();
            this.context.Feeds.Add(new AtomFeed("http://feed1/") { Owner = "jdoe" });
            this.context.Feeds.Add(new AtomFeed("http://feed2/") { Owner = "jdoe" });
            this.context.Feeds.Add(new AtomFeed("http://feed3/") { Owner = "another" });
            this.context.SaveChanges();
        }

        [TestMethod]
        public void GetFeedsShouldReturnListOfFeeds()
        {
            var catalog = new Catalog("jdoe");
            var feeds = catalog.GetFeeds();
            Assert.AreEqual(2, feeds.Count());
            catalog = new Catalog("another");
            feeds = catalog.GetFeeds();
            Assert.AreEqual(1, feeds.Count());
        }

        [TestMethod]
        public void SaveFeedShouldCreateNewFeed()
        {
            var catalog = new Catalog("jdoe");
            var feed = catalog.AddFeed(new AtomFeed("http://mytest/"));
            Assert.IsNotNull(feed);
            Assert.AreEqual("jdoe", feed.Owner);
            Assert.AreEqual("http://mytest/", feed.Locator);
            Assert.AreEqual(3, catalog.GetFeeds().Count());
            Assert.AreEqual(4, this.context.Feeds.Count());
        }
    }
}
