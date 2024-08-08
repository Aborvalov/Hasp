using Entities;
using System;
using System.ComponentModel;

namespace ModelEntities
{
    public class ModelViewLog
    {
        public ModelViewLog()
        { }

        public ModelViewLog(Log log) : this()
        {
            Id = log.LogId;
            User = log.User;
            LoginTime = log.LoginTime;
            Actions = log.Actions;
        }

        [Browsable(false)]
        public Log log { get; private set; } = new Log();

        [Browsable(false)]
        public int Id
        {
            get => log.LogId;
            set => log.LogId = value;
        }
        [DisplayName("Имя")]
        public string User
        {
            get => log.User;
            set => log.User = value;
        }
        [DisplayName("Время")]
        public DateTime LoginTime
        {
            get => log.LoginTime;
            set => log.LoginTime = value;
        }
        [DisplayName("Действия")]
        public string Actions
        {
            get => log.Actions;
            set => log.Actions = value;
        }

        public override int GetHashCode() => log.GetHashCode();
        public override bool Equals(object obj) => log.Equals(obj);
    }
}
