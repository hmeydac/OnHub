namespace OnHub.UI.Web.Tests.Controllers
{
    using System.Web.Mvc;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OnHub.UI.Web.App_Start;
    using OnHub.UI.Web.Controllers;
    using OnHub.UI.Web.Models;

    [TestClass]
    public class HomeControllerTests
    {
        private HomeController controller;

        [TestInitialize]
        public void SetUp()
        {
            AutoMapConfig.RegisterMaps();
            this.controller = new HomeController();
        }

        [TestMethod]
        public void IndexActionShouldReturnDefaultView()
        {
            var actual = this.controller.Index();
            Assert.IsNotNull(actual);
            Assert.IsNotNull(actual.Model);
            Assert.IsInstanceOfType(actual.Model, typeof(WorkspaceViewModel));
            Assert.IsInstanceOfType(actual, typeof(ViewResult));
        }
    }
}
