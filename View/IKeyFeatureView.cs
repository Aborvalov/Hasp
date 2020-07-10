using ModelEntities;
using System;
using System.Collections.Generic;

namespace View
{
    public interface IKeyFeatureView
    {
        List<ModelViewKeyFeature> KeyFeatyre { get; set; }
        void BindFeature(List<ModelViewFeatureForEditKeyFeat> feature);
        void BindKey(List<ModelViewHaspKey> key);

        void DataChange();       
        event Action DataUpdated;

        void MessageError(string error);
    }
}
