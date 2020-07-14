using ModelEntities;
using System;
using System.Collections.Generic;

namespace View
{
    public interface IKeyFeatureView
    {
        void BindFeature(List<ModelViewFeatureForKeyFeat> feature);
        void BindKey(List<ModelViewHaspKey> key);
        string NumberHaspKey { get; set; }

        void DataChange();       
        event Action DataUpdated;

        void MessageError(string error);
        void ErrorRow(int numberRow);
        void EmptyFeatureAsKey();
    }
}
