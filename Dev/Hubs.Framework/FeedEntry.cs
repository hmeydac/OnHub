namespace Hubs.Framework
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class FeedEntry
    {
        [Key]
        public Guid Id { get; set; }

        public string Title { get; set; }
    }
}