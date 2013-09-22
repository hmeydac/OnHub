namespace Hubs.Framework
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class Feed
    {
        [Key, Column(Order = 0)]
        public string Owner { get; set; }

        [Key, Column(Order = 1)]
        public string Locator { get; set; }
    }
}
