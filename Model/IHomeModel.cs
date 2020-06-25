using System;
using System.Collections.Generic;

namespace Model
{
    public interface IHomeModel
    {
        void UpdateHome(Home home);
        List<Home> GetAll();
        Home GetById(int Id);
        event EventHandler<HomeEventArgs> ProjectUpdated;
    }
}
