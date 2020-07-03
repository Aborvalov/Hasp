using System;
using System.Collections.Generic;

namespace View
{
    public interface IEntitiesView<T>
    {
        void Bind(List<T> entity);
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
        void MessageError(string error);

        event Action DateUpdate;
    }
}
