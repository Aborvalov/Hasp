using Entities;
using System;

namespace DalContract
{
    public interface IContractUserDAO : IContractEntitesDAO<User>
    {
        LevelAccess? GetByLoginAndPassword(string login, string password);
    }
}
