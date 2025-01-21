﻿using Entities;
using ModelEntities;
using System.Collections.Generic;

namespace ViewContract
{
    public interface ILogView
    {
        void DataChange();
        void MessageError(string errorText);
        void Bind(Log check);
        void Bind(List<ModelViewLog> entity);
        void BindItem(ModelViewLog entity);
    }
}
