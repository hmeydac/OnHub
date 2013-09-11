namespace Hubs.Framework.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class HubTests
    {
        private Hub hub;

        private Feed feed;

        private Feed anotherFeed;

        [TestInitialize]
        public void SetUp()
        {
            this.hub = new Hub("A Name");
            this.CreateMockFeed();
        }

        [TestMethod]
        public void HubMustHaveAName()
        {
            Assert.AreEqual("A Name", this.hub.Name);
        }

        [TestMethod]
        public void AddAFeedToHubShouldIncludeNewFeed()
        {
            this.hub.AddFeed(this.feed);
            Assert.AreEqual(this.feed, this.hub.Feeds.FirstOrDefault());
            Assert.AreEqual(1, this.hub.FeedsCount);
        }

        [TestMethod]
        public void RemoveAFeedFromHubShouldRemoveIt()
        {
            this.hub.AddFeed(this.feed);
            this.hub.Remove(0);
            Assert.AreEqual(0, this.hub.FeedsCount);
            Assert.IsNull(this.hub.Feeds.FirstOrDefault());
        }

        [TestMethod]
        public void GetEntriesShouldListEntriesFromAllFeeds()
        {
            this.hub.AddFeed(this.feed);
            this.hub.AddFeed(this.anotherFeed);
            CollectionAssert.IsSubsetOf(this.feed.Entries, this.hub.Entries);
            CollectionAssert.IsSubsetOf(this.anotherFeed.Entries, this.hub.Entries);
            var previousDate = DateTime.MaxValue;
            foreach (var entry in this.hub.Entries)
            {
                Assert.IsTrue(entry.EntryDate <= previousDate, "The list of entries should be ordered by Entry Date descending.");
                previousDate = entry.EntryDate;
            }
        }

        private void CreateMockFeed()
        {
            this.feed = new Feed("A Feed", new Uri("http://test/"));
            this.feed.Entries = new List<FeedEntry>
                                    {
                                        new FeedEntry("Title 1") { EntryDate = new DateTime(2012, 01, 01) },
                                        new FeedEntry("Title 2") { EntryDate = new DateTime(2013, 02, 13) },
                                        new FeedEntry("Title 3") { EntryDate = new DateTime(2014, 03, 21) },
                                        new FeedEntry("Title 4") { EntryDate = new DateTime(2011, 04, 03) },
                                    };

            this.anotherFeed = new Feed("Another Feed", new Uri("http://anothertest/"));
            this.anotherFeed.Entries = new List<FeedEntry>
                                           {
                                               new FeedEntry("Another Title 1") { EntryDate = new DateTime(2013, 01, 11) },
                                               new FeedEntry("Another Title 2") { EntryDate = new DateTime(2013, 02, 11) },
                                               new FeedEntry("Another Title 3") { EntryDate = new DateTime(2013, 03, 11) },
                                               new FeedEntry("Another Title 4") { EntryDate = new DateTime(2013, 04, 20) },
                                           };
        }
    }
}
