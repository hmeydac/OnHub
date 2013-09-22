namespace Hubs.Persistance.Tests
{
    using System.Linq;
    using System.Transactions;

    using Hubs.RSS;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AtomFeedPersistanceTests : TransactionalUnitTest
    {
        private HubsContext context;

        public override void SetUp()
        {
            this.context = new HubsContext();
        }

        [TestMethod]
        public void AddAtomFeedShouldWork()
        {
            Assert.AreEqual(0, this.context.Feeds.Count());
            var feed = new AtomFeed("http://fake.com") { Owner = "Me" };
            this.context.Feeds.Add(feed);
            this.context.SaveChanges();
            Assert.AreEqual(1, this.context.Feeds.Count());
        }
    }
}
