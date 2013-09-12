namespace OnHub.UI.Web.Controllers
{
    using System.Web.Mvc;

    using OnHub.UI.Web.Models;

    public class HomeController : Controller
    {
        public ViewResult Index()
        {
            return this.View(new WorkspaceViewModel());
        }
    }
}
