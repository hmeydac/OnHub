namespace Hubs.Framework.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class FeedEntryTests
    {
        private FeedEntry feedEntry;

        [TestInitialize]
        public void SetUp()
        {
            this.feedEntry = new FeedEntry("A Title") { EntryDate = new DateTime(2013, 10, 28) };
        }

        [TestMethod]
        public void FeedEntryMustHaveTitle()
        {
            Assert.AreEqual("A Title", this.feedEntry.Title);
        }

        [TestMethod]
        public void FeedEntryCouldHaveBody()
        {
            this.feedEntry.Body = "Body Text";
            Assert.AreEqual("Body Text", this.feedEntry.Body);
        }

        [TestMethod]
        public void FeedEntryMustHaveAnEntryDate()
        {
            Assert.AreEqual(new DateTime(2013, 10, 28), this.feedEntry.EntryDate);
        }
    }
}
