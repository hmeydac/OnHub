namespace OnHub.Web.Models
{
    using System.Collections.Generic;

    public class HubViewModel
    {
        public string Name { get; set; }

        public List<FeedViewModel> Feeds { get; set; } 
    }
}