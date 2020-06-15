using System.Collections.Generic;

namespace DalContract
{
    public interface IContractEntites<TEntites>
    {
        int Add(TEntites entity);
        bool Remove(int id);
        bool Update(TEntites entity);
        IEnumerable<TEntites> GetAll();
        TEntites GetById(int id);
    }
}
