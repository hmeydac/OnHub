namespace Hubs.Framework
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public abstract class Feed
    {
        [Key]
        public Guid Id { get; set; }

        public string Locator { get; set; }

        public string Owner { get; set; }
    }
}
