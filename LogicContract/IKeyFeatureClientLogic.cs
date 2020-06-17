using Entities;
using System.Collections.Generic;

namespace LogicContract
{
    public interface IKeyFeatureClientLogic
    {
        KeyFeatureClient Save(KeyFeatureClient keyFeatureClient);
        KeyFeatureClient Update(KeyFeatureClient keyFeatureClient);
        KeyFeatureClient GetById(int id);
        List<KeyFeatureClient> GetAll();
        bool Remove(int id);
    }
}
