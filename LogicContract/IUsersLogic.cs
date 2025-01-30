using Entities;
using System.Collections.Generic;

namespace LogicContract
{
    public interface IUsersLogic : IEntitesLogic<User>
    {
        LevelAccess? GetByLoginAndPassword(string login, string password);
        List<User> GetAllWithPasswords();
    }
}
