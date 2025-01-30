using Entities;
using System.ComponentModel;

namespace ModelEntities
{
    public class ModelViewUser
    { 
        public ModelViewUser()
        { }

        public ModelViewUser(User login) : this()
        {
            Id = login.Id;
            Name = login.Name;
            Login = login.Login;
            Password = "•••••••";
            LevelAccess = login.LevelAccess;
        }

        [Browsable(false)]
        public User User { get; private set; } = new User();

        [Browsable(false)]
        public int Id
        {
            get => User.Id;
            set => User.Id = value;
        }
        [DisplayName("Имя")]
        public string Name
        {
            get => User.Name;
            set => User.Name = value;
        }
        [DisplayName("Логин")]
        public string Login
        {
            get => User.Login;
            set => User.Login = value;
        }
        [DisplayName("Пароль")]
        public string Password
        {
            get => User.Password;
            set => User.Password = value;
        }
        [DisplayName("Уровень доступа")]
        public LevelAccess? LevelAccess
        {
            get => User.LevelAccess;
            set => User.LevelAccess = value;
        }

        public override int GetHashCode() => User.GetHashCode();
        public override bool Equals(object obj) => User.Equals(obj);
    }
}
