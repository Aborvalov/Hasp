using System;
using System.Collections.Generic;

namespace ViewContract
{
    public interface IEntitiesView<T> : IBindItemView<T>
    {
        void Bind(List<T> entity);        
        void DataChange();
        void MessageError(string error);   
    }
}
