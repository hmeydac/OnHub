namespace Hubs.Persistance.Tests
{
    using System.Data.Entity;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class AssemblyInitializer
    {
        [AssemblyInitialize]
        public static void Init(TestContext testContext)
        {
            // Ensure database is created before any test is run
            Database.SetInitializer(new HubsContextInitializer<HubsContext>());
            var context = new HubsContext();
            context.Database.Initialize(force: false);
        }

        [AssemblyCleanup]
        public static void Cleanup()
        {
            // Remove database after all tests ran
            var context = new HubsContext();
            context.Database.Delete();
        }
    }
}
