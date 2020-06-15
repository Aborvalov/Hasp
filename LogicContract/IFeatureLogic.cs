using Entities;
using System.Collections.Generic;

namespace LogicContract
{
    interface IFeatureLogic
    {
        Feature Save(int number, string name, string description);
        Feature Update(int id, int number, string name, string description);
        Feature GetById(int id);
        bool Remove(int id);
        List<Feature> GetAll();
    }
}
