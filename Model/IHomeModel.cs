using ModelEntities;
using System.Collections.Generic;

namespace Model
{
    public interface IHomeModel
    {
        void UpdateHome(Home home);
        List<Home> GetAll();
        Home GetById(int Id);
    }
}
