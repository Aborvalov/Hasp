using System.Collections.Generic;

namespace View
{
    public interface IEntitesView<T>
    {
        void Build(List<T> entity);
        bool Add(T entity);
        bool Update(T entity);
        bool Remove(int id);
        void MessageError(string error);

    }
}
