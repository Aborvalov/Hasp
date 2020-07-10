using ModelEntities;
using System;
using System.Collections.Generic;

namespace Model
{
    public interface IFeatureFor__Model : IDisposable
    {
        List<ModelViewFeatureForEditKeyFeat> GetAll();
        List<ModelViewFeatureForEditKeyFeat> GetAll(int idKey);
    }
}
