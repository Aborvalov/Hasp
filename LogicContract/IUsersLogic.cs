using Entities;

namespace LogicContract
{
    public interface IUsersLogic : IEntitesLogic<User>
    {
        LevelAccess GetByLoginAndPassword(string login, string password);
    }
}
