using ModelEntities;
using System;
using System.Collections.Generic;

namespace View
{
    /*
     * 
     * 
     * 
     * 
     * 
     */
    public interface IKeyFeatureView : IEntitiesView<ModelViewKeyFeature>
    {
        void Bind(List<ModelViewKeyFeature> entity);        
        void DataChange();       
        event Action DataUpdated;
    }
}
