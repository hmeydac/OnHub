namespace Hubs.Framework.Tests
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FeedTests
    {
        private Feed feed;

        private List<FeedEntry> entries;

        [TestInitialize]
        public void SetUp()
        {
            this.feed = new Feed("A Name", new Uri("http://test/"));
            this.entries = new List<FeedEntry>
                               {
                                   new FeedEntry("Title 1"),
                                   new FeedEntry("Title 2"),
                                   new FeedEntry("Title 3")
                               };

            this.feed.Entries = new List<FeedEntry>(this.entries);
        }

        [TestMethod]
        public void FeedMustHaveANameAndAnUri()
        {
            Assert.AreEqual("A Name", this.feed.Name);
            Assert.AreEqual(new Uri("http://test/"), this.feed.Uri);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException), "Name is required and an exception must be thrown")]
        public void FeedWithoutNameShouldThrowException()
        {
            new Feed(null, null);
        }

        [TestMethod]
        public void GetLastEntryShouldReturnLastEntry()
        {
            Assert.AreEqual(this.entries.Last(), this.feed.LastEntry());
        }

        [TestMethod]
        public void GetFirstEntryShouldReturnFirstEntry()
        {
            Assert.AreEqual(this.entries.First(), this.feed.FirstEntry());
        }

        [TestMethod]
        public void GetEntriesShouldListEntries()
        {
            CollectionAssert.AreEquivalent(this.entries, this.feed.Entries);
        }
    }
}
