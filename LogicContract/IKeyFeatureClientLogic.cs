using Entities;
using System.Collections.Generic;

namespace LogicContract
{
    public interface IKeyFeatureClientLogic
    {
        bool Save(KeyFeatureClient keyFeatureClient);
        bool Update(KeyFeatureClient keyFeatureClient);
        KeyFeatureClient GetById(int id);
        List<KeyFeatureClient> GetAll();
        bool Remove(int id);
    }
}
