namespace Hubs.RSS
{
    using System.Collections.Generic;

    public interface IFeedReader
    {
        IEnumerable<FeedEntry> GetEntries(string url);
    }
}