using Entities;
using System.Collections.Generic;

namespace LogicContract
{
    public interface IKeyFeatureLogic
    {
        bool Save(KeyFeature keyFeature);
        bool Update(KeyFeature keyFeature);
        KeyFeature GetById(int id);
        bool Remove(int id);
        List<KeyFeature> GetAll();
    }
}
