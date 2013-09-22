namespace Hubs.RSS
{
    using System.Collections.Generic;

    using Hubs.Framework;

    public interface IFeedReader
    {
        IEnumerable<FeedEntry> GetEntries(string url);
    }
}