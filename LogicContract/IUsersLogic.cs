using Entities;

namespace LogicContract
{
    public interface IUsersLogic : IEntitesLogic<User>
    {
        int GetByLoginAndPassword(string login, string password);
    }
}
