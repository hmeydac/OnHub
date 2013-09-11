namespace Hubs.Framework
{
    public interface IFeedReader
    {
        bool Ping();

        FeedEntry GetLastEntry();
    }
}
