using System.Data.Entity.Infrastructure.Design;

namespace Entities
{
    public class Client
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string ContactPerson { get; set; }
        public override bool Equals(object obj)
        {
            if (!(obj is Client other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Id.Equals(other.Id) &&
                   Name.Equals(other.Name);
        }
        public override int GetHashCode()
        {
            int hashProductName          = Name == null ? 0 : Name.GetHashCode();
            int hashProductAddress       = Address == null ? 0 : Address.GetHashCode();
            int hashProductPhone         = Phone == null ? 0 : Phone.GetHashCode();
            int hashProductContactPerson = ContactPerson == null ? 0 : ContactPerson.GetHashCode();

            int hashProductId = Id.GetHashCode();

            return hashProductName ^
                   hashProductAddress ^
                   hashProductPhone ^
                   hashProductContactPerson ^
                   hashProductId;
        }
    }
}
