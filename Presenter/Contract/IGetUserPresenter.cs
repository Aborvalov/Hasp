using Entities;
namespace Presenter
{
    public interface IGetUserPresenter
    {
        LevelAccess? GetByLoginAndPassword(string login, string password);
    }
}
