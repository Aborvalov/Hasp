using Entities;
using System;

public class UserSingleton
{
    private static readonly Lazy<UserSingleton> instance = new Lazy<UserSingleton>(() => new UserSingleton());

    public static UserSingleton Instance => instance.Value;

    public int Id { get; private set; }
    public string Name { get; private set; }
    public string Login { get; private set; }
    public LevelAccess? LevelAccess { get; private set; }

    private UserSingleton() { }

    public void ClearUser()
    {
        Id = 0;
        Name = string.Empty;
        Login = string.Empty;
        LevelAccess = null;
    }

    public void SetUser(User user)
    {
        Id = user.Id;
        Name = user.Name;
        Login = user.Login;
        LevelAccess = user.LevelAccess;
    }

    public bool IsAuthenticated => Id != 0;
}
