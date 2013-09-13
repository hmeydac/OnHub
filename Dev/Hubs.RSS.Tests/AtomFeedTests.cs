namespace Hubs.RSS.Tests
{
    using System;
    using System.Collections.Generic;

    using Hubs.Framework;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class AtomFeedTests
    {
        private AtomFeed atomFeed;

        private Mock<IFeedReader> atomReaderMock;

        [TestInitialize]
        public void SetUp()
        {
            this.atomFeed = new AtomFeed("A Title", new Uri("http://blog.nuget.org/feeds/atom.xml"));
            this.atomReaderMock = new Mock<IFeedReader>();
        }

        [TestMethod]
        public void NuGetFeedFirstEntryShouldBeIntroToBlog()
        {
            this.atomFeed.Reader = this.atomReaderMock.Object;
            this.atomReaderMock.Setup(a => a.GetLastEntry()).Returns(new FeedEntry("Test Entry"));
            var entry = this.atomFeed.LastEntry();
            Assert.AreEqual("Test Entry", entry.Title, "The returned entry should have the expected title when getting an Entry from the Reader.");
            this.atomReaderMock.VerifyAll();
        }

        [TestMethod]
        public void PopulateFeedShouldFillEntries()
        {
            var entries = new List<FeedEntry>() { new FeedEntry("Test Entry") };
            this.atomFeed.Reader = this.atomReaderMock.Object;
            this.atomReaderMock.Setup(reader => reader.GetEntries()).Returns(entries);
            Assert.AreEqual(0, this.atomFeed.Entries.Count);
            this.atomFeed.Populate();
            Assert.AreEqual(1, this.atomFeed.Entries.Count);
        }
    }
}
