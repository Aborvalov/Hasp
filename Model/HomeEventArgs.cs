using System;

namespace Model
{
    public class HomeEventArgs : EventArgs
    {
        public Home Home { get; set; }
        public HomeEventArgs(Home home)
        {
            this.Home = home;
        }
    }
}
