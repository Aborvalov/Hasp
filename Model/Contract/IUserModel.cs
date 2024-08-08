using ModelEntities;
using System;
using System.Collections.Generic;

namespace Model
{
    public interface IUserModel : IEntitiesModel<ModelViewUser>
    {
        int GetByLoginAndPassword(string login, string password);
        bool Add(IEnumerable<ModelViewUser> keyClient, out string error);
        bool Update(IEnumerable<ModelViewUser> keyClient, out string error);
        bool Remove(IEnumerable<ModelViewUser> idKeyClient, out string error);
    }
}
