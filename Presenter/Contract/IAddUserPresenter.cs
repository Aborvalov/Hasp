using Entities;
using ModelEntities;
using System.Collections.Generic;

namespace Presenter.Contract
{
    public interface IAddUserPresenter : IEntitiesPresenter<ModelViewUser>
    {
        void Edit(List<ModelViewUser> item);
        LevelAccess? GetByLoginAndPassword(string login, string password);
    }
}
