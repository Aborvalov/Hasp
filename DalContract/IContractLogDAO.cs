using Entities;
using System.Collections.Generic;

namespace DalContract
{
    public interface IContractLogDAO
    {
        List<Log> GetAll();
    }
}
