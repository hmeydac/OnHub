namespace OnHub.UI.Web.Models
{
    using System.Collections.Generic;

    public class FeedViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public List<FeedEntryViewModel> Entries { get; set; }
    }
}