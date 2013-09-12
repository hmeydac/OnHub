namespace Hubs.Framework.Tests
{
    using System.Linq;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class WorkspaceTests
    {
        private Workspace workspace;

        [TestInitialize]
        public void SetUp()
        {
            this.workspace = new Workspace();
        }

        [TestMethod]
        public void WorkspaceFactoryShouldCreateNewInstances()
        {
            Assert.AreNotEqual(Workspace.Create(), Workspace.Create());
        }

        [TestMethod]
        public void WorkspaceShouldStartWithAnEmptyHubsCollection()
        {
            Assert.AreEqual(0, this.workspace.Hubs.Count);
        }

        [TestMethod]
        public void CreateHubShouldAddNewHubToWorkspace()
        {
            this.workspace.CreateHub("A Hub");
            Assert.AreEqual(1, this.workspace.Hubs.Count);
            Assert.AreEqual("A Hub", this.workspace.Hubs.First().Name);
        }

        [TestMethod]
        public void RemoveHubShouldRemoveItFromWorkspace()
        {
            this.workspace.CreateHub("A Hub");
            Assert.AreEqual(1, this.workspace.Hubs.Count);
            this.workspace.RemoveHub(0);
            Assert.AreEqual(0, this.workspace.Hubs.Count);
        }
    }
}
