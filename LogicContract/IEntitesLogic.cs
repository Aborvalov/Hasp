using System.Collections.Generic;

namespace LogicContract
{
    public interface IEntitesLogic<T>
    {
        bool Save(T entity);
        bool Update(T entity);
        T GetById(int id);
        bool Remove(int id);
        List<T> GetAll();
    }
}
