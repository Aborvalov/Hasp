using ModelEntities;
using System.Collections.Generic;

namespace ViewContract
{
    public interface IClientNumberKeysView
    {
        void BindItem(ModelViewClient entity);
        void DataChange();
        void MessageError(string errorText);
        void Bind(List<ModelViewClient> modelViewClientsNumberKeys);
    }
}
