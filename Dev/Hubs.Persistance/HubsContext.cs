namespace Hubs.Persistance
{
    using System.Data.Entity;

    using Hubs.Framework;
    using Hubs.RSS;

    public class HubsContext : DbContext
    {
        public DbSet<Feed> Feeds { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Feed>().Map<AtomFeed>(x => x.MapInheritedProperties());
        }
    }
}
