﻿using Entities;
using System.Collections.Generic;

namespace LogicContract
{
    interface IFeatureLogic
    {
        Feature Save(Feature feature);
        Feature Update(Feature feature);
        Feature GetById(int id);
        bool Remove(int id);
        List<Feature> GetAll();
    }
}
