namespace Hubs.Persistance
{
    using System.Data.Entity;

    public class HubsContextInitializer<TContext>
        : MigrateDatabaseToLatestVersion<TContext, Migrations.Configuration<TContext>>
        where TContext : HubsContext
    {
    }
}