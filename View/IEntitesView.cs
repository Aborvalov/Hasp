using System;
using System.Collections.Generic;

namespace View
{
    public interface IEntitesView<T>
    {
        void Build(List<T> entity);
        void Add(T entity);
        void Update(T entity);
        void Remove(int id);
        void MessageError(string error);

        event Action DateUpdate;
    }
}
