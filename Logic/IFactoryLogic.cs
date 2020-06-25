using Entities;
using LogicContract;

namespace Logic
{
    public interface IFactoryLogic
    {
        IClientLogic CreateClient(EntitesContext db);
        IFeatureLogic CreateFeature(EntitesContext db);
        IHaspKeyLogic CreateHaspKey(EntitesContext db);
        IKeyFeatureLogic CreateKeyFeature(EntitesContext db);
        IKeyFeatureClientLogic CreateKeyFeatureClient(EntitesContext db);
    }
}