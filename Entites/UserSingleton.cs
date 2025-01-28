using System;

namespace Entities
{
    public sealed class UserSingleton
    {
        private static readonly Lazy<UserSingleton> instance = new Lazy<UserSingleton>(() => new UserSingleton());
        private User user;

        private UserSingleton()
        {
            user = new User();
        }

        public static UserSingleton Instance => instance.Value;

        public User User
        {
            get => user;
            set
            {
                if (value != null)
                {
                    user.Id = value.Id;
                    user.Name = value.Name;
                    user.Login = value.Login;
                    user.LevelAccess = value.LevelAccess;
                }
            }
        }

        public void Reset()
        {
            user = new User();
        }
    }
}
