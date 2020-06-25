using System;

namespace Model
{
    public class HomeEventArgs : EventArgs
    {
        public HomeView Home { get; set; }
        public HomeEventArgs(HomeView home)
        {
            this.Home = home;
        }
    }
}
