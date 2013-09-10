namespace Hubs.RSS.Tests
{
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class RssReaderTests
    {
        [TestMethod]
        public void GivenRssUrlShouldPingFeedAndReturnTrue()
        {
            var reader = new RssReader();
            var pingResult = reader.Ping(@"http://blog.nuget.org/feeds/atom.xml");
            Assert.IsTrue(pingResult);
            pingResult = reader.Ping(@"http://doesnotexist.com/");
            Assert.IsFalse(pingResult);
        }

        [TestMethod]
        public void GivenAnUrlShouldReadLastEntry()
        {
            var reader = new RssReader();
            var entry = reader.GetLastEntry(@"http://blog.nuget.org/feeds/atom.xml");
            Assert.IsFalse(string.IsNullOrEmpty(entry));
        }

        [TestMethod]
        public void GivenNuGetFeedShouldReturn40Entries()
        {
            var reader = new RssReader();
            var result = reader.GetFeedEntryCount(@"http://blog.nuget.org/feeds/atom.xml");
            Assert.AreEqual(40, result);
        }
    }
}
