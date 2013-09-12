namespace OnHub.UI.Web.App_Start
{
    using AutoMapper;

    using Hubs.Framework;

    using OnHub.UI.Web.Models;

    public class AutoMapConfig
    {
        public static void RegisterMaps()
        {
            Mapper.CreateMap<Workspace, WorkspaceViewModel>();
            Mapper.CreateMap<Hub, HubViewModel>();
            Mapper.CreateMap<Feed, FeedViewModel>();
            Mapper.CreateMap<FeedEntry, FeedEntryViewModel>();
        }
    }
}