namespace Hubs.UI.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Hubs.RSS;
    using Hubs.UI.Web.Models;

    public class HomeController : Controller
    {
        public HomeController()
        {
            this.Reader = new AtomReader();
        }

        public IFeedReader Reader { get; set; }

        public ActionResult Index()
        {
            this.ViewBag.Title = "On Hub";
            return this.View(new PopulateFeedViewModel());
        }

        [HttpPost]
        public ActionResult Index(FeedViewModel viewModel)
        {
            var feed = new AtomFeed(viewModel.Url) { Reader = this.Reader };
            feed.PopulateEntries();
            var entriesViewModel = new PopulateFeedViewModel();
            entriesViewModel.Entries.AddRange(feed.Entries.Select(entry => new FeedEntryViewModel{ Title = entry.Title}).ToList());
            return this.View(entriesViewModel);
        }
    }
}
