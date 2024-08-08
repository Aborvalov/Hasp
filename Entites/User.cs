using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class User
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Login")]
        public string Login { get; set; }
        [Column("Password")]
        public string Password { get; set; }
        [Column("LevelAccess")]
        public LevelAccess LevelAccess { get; set; }
        public override bool Equals(object obj)
        {
            if (!(obj is User other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Id.Equals(other.Id) &&
                   Name.Equals(other.Name) &&
                   Login.Equals(other.Login) &&
                   Password.Equals(other.Password) &&
                   LevelAccess.Equals(other.LevelAccess);
        }
        public override int GetHashCode()
        {
            int hashProductID = Id.GetHashCode();
            int hashProductName = Name.GetHashCode();
            int hashProductLogin = Login.GetHashCode(); ;
            int hashProductIdLevelAccess = LevelAccess.GetHashCode();

            return hashProductLogin ^
                   hashProductIdLevelAccess ^
                   hashProductID ^
                   hashProductName;
        }
    }
}
