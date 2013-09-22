namespace Hubs.Persistance.Migrations
{
    using System.Data.Entity.Migrations;

    public class Configuration<TContext> : DbMigrationsConfiguration<TContext>
         where TContext : HubsContext
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }
    }
}
