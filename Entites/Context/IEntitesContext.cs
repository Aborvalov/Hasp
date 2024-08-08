using System;
using System.Data.Entity;

namespace Entities
{
    public interface IEntitesContext : IDisposable
    {
        DbSet<Client> Clients { get; set; }
        DbSet<Feature> Features { get; set; }
        DbSet<HaspKey> HaspKeys { get; set; }
        DbSet<KeyFeature> KeyFeatures { get; set; }
        DbSet<KeyFeatureClient> KeyFeatureClients { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<Log> Logs { get; set; }
    }
}
