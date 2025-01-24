using Entities;

namespace LogicContract
{
    public interface IUsersLogic : IEntitesLogic<User>
    {
        User GetByLoginAndPassword(string login, string password);
    }
}
