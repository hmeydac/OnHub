namespace Hubs.RSS.Tests
{
    using System;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AtomReaderTests
    {
        private AtomReader reader;

        [TestInitialize]
        public void SetUp()
        {
            this.reader = new AtomReader(new Uri(@"http://blog.nuget.org/feeds/atom.xml"));
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void GivenAtomUrlShouldPingFeedAndReturnTrue()
        {
            Assert.IsTrue(this.reader.Ping());
        }

        [TestMethod]
        [TestCategory("Integration")]
        public void GivenNuGetFeedShouldReturn40Entries()
        {
            Assert.IsTrue(this.reader.GetFeedEntryCount() > 40);
        }
    }
}
