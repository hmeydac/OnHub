using System.Collections.Generic;

namespace OnHub.Web.Models
{
    public class FeedViewModel
    {
        public string Name { get; set; }

        public string Url { get; set; }

        public List<FeedEntryViewModel> Entries { get; set; }
    }
}