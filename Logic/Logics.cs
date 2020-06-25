using DalDB;
using Entities;

namespace Logic
{
    public class Logics
    {
        public ClientLogic CreateClient(EntitesContext db)                     => new ClientLogic(new DbClientDAO(db));
        public FeatureLogic CreateFeature(EntitesContext db)                   => new FeatureLogic(new DbFeatureDAO(db));
        public HaspKeyLogic CreateHaspKey(EntitesContext db)                   => new HaspKeyLogic(new DbHaspKeyDAO(db));
        public KeyFeatureClientLogic CreateKeyFeatureClient(EntitesContext db) => new KeyFeatureClientLogic(new DbKeyFeatureClientDAO(db));
        public KeyFeatureLogic CreateKeyFeature(EntitesContext db)             => new KeyFeatureLogic(new DbKeyFeatureDAO(db));
    }
}
