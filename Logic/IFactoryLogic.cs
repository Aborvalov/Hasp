using Entities;
using LogicContract;

namespace Logic
{
    public interface IFactoryLogic
    {
        IClientLogic CreateClient(IEntitesContext db);
        IFeatureLogic CreateFeature(IEntitesContext db);
        IHaspKeyLogic CreateHaspKey(IEntitesContext db);
        IKeyFeatureLogic CreateKeyFeature(IEntitesContext db);
        IKeyFeatureClientLogic CreateKeyFeatureClient(IEntitesContext db);
    }
}