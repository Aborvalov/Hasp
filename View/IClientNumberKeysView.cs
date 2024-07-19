using Entities;
using ModelEntities;
using System;
using System.Collections.Generic;

namespace ViewContract
{
    public interface IClientNumberKeysView
    {
        void BindItem(ModelViewClientNumberKeys entity);
        void DataChange();
        void MessageError(string errorText);
        void Bind(List<ModelViewClientNumberKeys> modelViewClientsNumberKeys);
    }
}
