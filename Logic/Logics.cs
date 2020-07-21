using DalDB;
using Entities;
using LogicContract;

namespace Logic
{
    public class Logics : IFactoryLogic
    {
        public IClientLogic CreateClient(IEntitesContext db) => new ClientLogic(new DbClientDAO(db));
        public IFeatureLogic CreateFeature(EntitesContext db) => new FeatureLogic(new DbFeatureDAO(db));
        public IHaspKeyLogic CreateHaspKey(EntitesContext db) => new HaspKeyLogic(new DbHaspKeyDAO(db));
        public IKeyFeatureLogic CreateKeyFeature(EntitesContext db) => new KeyFeatureLogic(new DbKeyFeatureDAO(db));
        public IKeyFeatureClientLogic CreateKeyFeatureClient(EntitesContext db) => new KeyFeatureClientLogic(new DbKeyFeatureClientDAO(db));
    }
}
