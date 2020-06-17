using System.Data.Common;
using System.Data.Entity;
namespace Entities
{
    public class EntitesContext : DbContext
    {
        public EntitesContext()
        { }
        public EntitesContext(string conStr) : base(conStr)
        { }
      


        public DbSet<Client> Clients { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<HaspKey> HaspKeys { get; set; }
        public DbSet<KeyFeature> KeyFeatures { get; set; }
        public DbSet<KeyFeatureClient> KeyFeatureClients { get; set; }
    }
}
