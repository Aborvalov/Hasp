using DalDB;
using Entities;
using LogicContract;

namespace Logic
{
    public class Logics : IFactoryLogic
    {
        public IClientLogic CreateClient(IEntitesContext db) => new ClientLogic(new DbClientDAO(db));
        public IFeatureLogic CreateFeature(IEntitesContext db) => new FeatureLogic(new DbFeatureDAO(db));
        public IHaspKeyLogic CreateHaspKey(IEntitesContext db) => new HaspKeyLogic(new DbHaspKeyDAO(db));
        public IKeyFeatureLogic CreateKeyFeature(IEntitesContext db) => new KeyFeatureLogic(new DbKeyFeatureDAO(db));
        public IKeyFeatureClientLogic CreateKeyFeatureClient(IEntitesContext db) => new KeyFeatureClientLogic(new DbKeyFeatureClientDAO(db));
        public IUsersLogic CreateUser(IEntitesContext db) => new UsersLogic(new DbUserDAO(db));
        public ILogLogic CreateLog(IEntitesContext db) => new LogLogic(new DbLogDAO(db)); 
    }
}
