using Entities;
using System.Collections.Generic;

namespace DalContract
{
    public interface IContractUserDAO : IContractEntitesDAO<User>
    {
        List<User> GetAllWithPasswords();
        LevelAccess? GetByLoginAndPassword(string login, string password);
    }
}
