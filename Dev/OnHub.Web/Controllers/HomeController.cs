namespace OnHub.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using Hubs.Framework;

    using OnHub.Web.Models;

    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Modify this template to jump-start your ASP.NET MVC application.";

            return this.View(new SearchFeedViewModel());
        }

        [HttpPost]
        public ActionResult Read(SearchFeedViewModel feedViewModel)
        {
            var feed = new Feed("My Feed", new Uri(feedViewModel.FeedUrl));
            feedViewModel.Feed = feed;
            return this.View("Index", feedViewModel);
        }
    }
}
