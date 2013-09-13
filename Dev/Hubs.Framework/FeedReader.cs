namespace Hubs.Framework
{
    using System.Collections.Generic;

    public interface IFeedReader
    {
        bool Ping();

        FeedEntry GetLastEntry();

        List<FeedEntry> GetEntries();
    }
}
