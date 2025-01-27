namespace Entities
{
    public class LevelAccessSingleton
    {
        private static LevelAccessSingleton _instance;
        private static readonly object _lock = new object();

        public LevelAccess? CurrentLevelAccess { get; private set; }

        private LevelAccessSingleton()
        {
            CurrentLevelAccess = null;
        }

        public static LevelAccessSingleton Instance
        {
            get
            {
                lock (_lock)
                {
                    if (_instance == null)
                    {
                        _instance = new LevelAccessSingleton();
                    }
                    return _instance;
                }
            }
        }

        public void SetLevelAccess(LevelAccess levelAccess)
        {
            CurrentLevelAccess = levelAccess;
        }
    }
}