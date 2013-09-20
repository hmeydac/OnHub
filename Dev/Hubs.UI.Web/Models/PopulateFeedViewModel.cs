namespace Hubs.UI.Web.Models
{
    using System.Collections.Generic;

    public class PopulateFeedViewModel
    {
        public PopulateFeedViewModel()
        {
            this.Entries = new List<FeedEntryViewModel>();
        }

        public string Url { get; set; }

        public List<FeedEntryViewModel> Entries { get; set; } 
    }
}