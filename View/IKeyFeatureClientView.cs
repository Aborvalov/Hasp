using ModelEntities;
using System;
using System.Collections.Generic;

namespace ViewContract
{
    public interface IKeyFeatureClientView
    {
        void DataChange();
        event Action DataUpdated;
        void MessageError(string errorText);
        void BindClient(List<ModelViewClient> client);
        void BindKey(List<ModelViewKeyFeatureClient> keyClient);
        string NameClient { get; set; }
        void ErrorRow(int numberRow);
    }
}
