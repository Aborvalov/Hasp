using Entities;
using System.Collections.Generic;

namespace LogicContract
{
    public interface IKeyFeatureLogic
    {
        KeyFeature Save(KeyFeature keyFeature);
        KeyFeature Update(KeyFeature keyFeature);
        KeyFeature GetById(int id);
        bool Remove(int id);
        List<KeyFeature> GetAll();
    }
}
