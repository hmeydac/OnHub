using System.Collections.Generic;

namespace OnHub.Web.Models
{
    public class HubViewModel
    {
        public string Name { get; set; }

        public List<FeedViewModel> Feeds { get; set; } 
    }
}