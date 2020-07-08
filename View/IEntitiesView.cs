using System;
using System.Collections.Generic;

namespace View
{
    public interface IEntitiesView<T>
    {
        void Bind(List<T> entity);
        void DataChange();
        void MessageError(string error);
        event Action DateUpdate;
    }
}
