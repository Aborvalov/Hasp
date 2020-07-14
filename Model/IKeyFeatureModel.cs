using ModelEntities;
using System;
using System.Collections.Generic;

namespace Model
{
    public interface IKeyFeatureModel_ : IDisposable
    {
        List<ModelViewKeyFeature> GetAll();
        ModelViewKeyFeature GetById(int id);
    }
}
