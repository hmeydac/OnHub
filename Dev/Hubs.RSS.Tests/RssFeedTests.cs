namespace Hubs.RSS.Tests
{
    using System;

    using Hubs.Framework;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RssFeedTests
    {
        private RssFeed rssFeed;

        [TestInitialize]
        public void SetUp()
        {
            this.rssFeed = new RssFeed("A Name", new Uri("http://test/"));
        }

        [TestMethod]
        public void RssFeedInheritsFromFeed()
        {
            Assert.IsInstanceOfType(this.rssFeed, typeof(Feed));
        }
    }
}
