namespace Hubs.RSS.Tests
{
    using System.Collections.Generic;

    using Hubs.Framework;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class AtomFeedTests
    {
        private AtomFeed feed;

        private List<FeedEntry> expectedEntries;

        private Mock<IFeedReader> readerMock;

        [TestInitialize]
        public void SetUp()
        {
            this.feed = new AtomFeed("http://myfeed.xml/");
            this.expectedEntries = new List<FeedEntry>
                                       {
                                           new FeedEntry { Title = "Test 1" },
                                           new FeedEntry { Title = "Test 2" },
                                           new FeedEntry { Title = "Test 3" }
                                       };

            this.readerMock = new Mock<IFeedReader>();
            this.readerMock.Setup(r => r.GetEntries(It.IsAny<string>())).Returns(this.expectedEntries);
            this.feed.Reader = this.readerMock.Object;
        }

        [TestMethod]
        public void AtomFeedShouldHaveAnUrl()
        {
            Assert.AreEqual("http://myfeed.xml/", this.feed.Locator);
        }

        [TestMethod]
        public void PingAtomFeedShouldReturnTrue()
        {
            Assert.IsTrue(this.feed.Ping());
        }

        [TestMethod]
        public void AtomFeedShouldHaveAReader()
        {
            Assert.AreEqual(this.readerMock.Object, this.feed.Reader);
        }

        [TestMethod]
        public void AtomFeedEntriesShouldBeEmpty()
        {
            Assert.AreEqual(0, this.feed.Entries.Count);
        }

        [TestMethod]
        public void AtomFeedEntriesShouldReturnListOfEntries()
        {
            this.feed.PopulateEntries();
            Assert.AreEqual(3, this.feed.Entries.Count);
            CollectionAssert.AreEqual(this.expectedEntries, this.feed.Entries);
        }
    }
}
