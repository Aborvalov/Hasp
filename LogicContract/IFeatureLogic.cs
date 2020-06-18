using Entities;
using System.Collections.Generic;

namespace LogicContract
{
    public interface IFeatureLogic
    {
        bool Save(Feature feature);
        bool Update(Feature feature);
        Feature GetById(int id);
        bool Remove(int id);
        List<Feature> GetAll();
    }
}
