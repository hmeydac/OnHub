namespace OnHub.Web.Tests.Controllers
{
    using System.Web.Mvc;

    using Hubs.Framework;

    using Microsoft.VisualStudio.TestTools.UnitTesting;

    using OnHub.Web.Controllers;
    using OnHub.Web.Models;

    [TestClass]
    public class HomeControllerTest
    {
        [TestMethod]
        public void Read()
        {
            var controller = new HomeController();
            var viewModel = new SearchFeedViewModel { FeedUrl = @"http://blog.nuget.org/feeds/atom.xml" };
            var result = controller.Read(viewModel) as ViewResult;
            var model = result.Model as SearchFeedViewModel;
            Assert.IsNotNull(model);
            Assert.IsInstanceOfType(model.Feed, typeof(Feed));
            Assert.AreEqual(@"http://blog.nuget.org/feeds/atom.xml", model.FeedUrl);
        }
    }
}
