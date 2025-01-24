using Entities;
using System;

namespace DalContract
{
    public interface IContractUserDAO : IContractEntitesDAO<User>
    {
        User GetByLoginAndPassword(string login, string password);
    }
}
