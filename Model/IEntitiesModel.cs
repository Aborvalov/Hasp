using System.Collections.Generic;

namespace Model
{
    public interface IEntitiesModel<T>
    {
        bool Add(T entity);
        bool Update(T entity);
        T GetById(int id);
        bool Remove(int id);
        List<T> GetAll();
    }
}
