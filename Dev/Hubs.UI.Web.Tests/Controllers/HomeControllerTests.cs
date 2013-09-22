namespace Hubs.UI.Web.Tests.Controllers
{
    using System.Collections.Generic;
    using System.Web.Mvc;

    using Hubs.Framework;
    using Hubs.RSS;
    using Hubs.UI.Web.Controllers;
    using Hubs.UI.Web.Models;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using Moq;

    [TestClass]
    public class HomeControllerTests
    {
        private HomeController controller;

        private List<FeedEntry> expectedEntries;

        private Mock<IFeedReader> readerMock;

        [TestInitialize]
        public void SetUp()
        {
            this.controller = new HomeController();
            this.expectedEntries = new List<FeedEntry>
                                       {
                                           new FeedEntry { Title = "Test 1" },
                                           new FeedEntry { Title = "Test 2" },
                                           new FeedEntry { Title = "Test 3" }
                                       };

            this.readerMock = new Mock<IFeedReader>();
            this.readerMock.Setup(r => r.GetEntries(It.IsAny<string>())).Returns(this.expectedEntries);
            this.controller.Reader = this.readerMock.Object;
        }

        [TestMethod]
        public void GetIndexActionShouldSetApplicationTitle()
        {
            var result = this.controller.Index() as ViewResult;
            Assert.IsNotNull(result);
            Assert.AreEqual("On Hub", result.ViewBag.Title);
        }

        [TestMethod]
        public void PostIndexActionShouldReturnViewModelWithListOfEntries()
        {
            var viewModel = new FeedViewModel { Url = "http://mysample.com/" };
            var result = this.controller.Index(viewModel) as ViewResult;
            var model = result.Model as PopulateFeedViewModel;
            Assert.IsNotNull(result);
            Assert.IsNotNull(model);
            Assert.AreEqual(3, model.Entries.Count);
        }
    }
}
