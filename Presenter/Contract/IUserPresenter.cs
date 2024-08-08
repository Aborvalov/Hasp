using Entities;
using ModelEntities;
using System;
using System.Collections.Generic;

namespace Presenter
{
    public interface IUserPresenter : IEntitiesPresenter<ModelViewUser>
    {
        void Edit(List<ModelViewUser> item);
        int GetByLoginAndPassword(string login, string password);
    }
}
