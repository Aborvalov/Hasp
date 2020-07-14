using ModelEntities;
using System;
using System.Collections.Generic;

namespace Model
{
    public interface IKeyFeatureModel : IDisposable
    {
        List<ModelViewKeyFeature> GetAll();
        ModelViewKeyFeature GetById(int id);
    }
}
