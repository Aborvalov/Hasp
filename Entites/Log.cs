using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class Log
    {
        [Column("LogId")]
        public int LogId { get; set; }
        [Column("User")]
        public string User { get; set; }
        [Column("LoginTime")]
        public DateTime LoginTime { get; set; }
        [Column("Actions")]
        public string Actions { get; set; }
        public override bool Equals(object obj)
        {
            if (!(obj is Log other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return LogId.Equals(other.LogId) &&
                   User.Equals(other.User) &&
                   LoginTime.Equals(other.LoginTime) &&
                   Actions.Equals(other.Actions);
        }
        public override int GetHashCode()
        {
            int hashProductSessionID = LogId.GetHashCode();
            int hashProductUser = User == null ? 0 : User.GetHashCode();

            int hashProductAction = Actions == null ? 0 : Actions.GetHashCode(); ;


            return hashProductAction ^
                   hashProductSessionID ^
                   hashProductUser;
        }
    }
}
