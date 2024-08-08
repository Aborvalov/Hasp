using Entities;
using System;

namespace DalContract
{
    public interface IContractUserDAO : IContractEntitesDAO<User>
    {
        int GetByLoginAndPassword(string login, string password);
    }
}
