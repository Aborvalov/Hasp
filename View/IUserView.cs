using Entities;
using ModelEntities;
using System.Collections.Generic;

namespace ViewContract
{
    public interface IUserView
    {
        void DataChange();
        void MessageError(string errorText);
        void Bind(List<ModelViewUser> entity);
        void BindItem(ModelViewUser entity);
    }
}
