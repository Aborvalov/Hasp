using System;
using System.Collections.Generic;

namespace Model
{
    public interface IHomeModel
    {
        void UpdateHome(HomeView home);
        List<HomeView> GetAll();
        HomeView GetById(int Id);
    }
}
