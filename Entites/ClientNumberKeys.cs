using System;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    public class ClientNumberKeys
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public override bool Equals(object obj)
        {
            if (!(obj is ClientNumberKeys other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Id.Equals(other.Id) &&
                   Name.Equals(other.Name);
        }
        public override int GetHashCode()
        {
            int hashProductIdClient = Id.GetHashCode();
            int hashProductName = Name == null ? 0 : Name.GetHashCode();

            return hashProductIdClient ^
                   hashProductName;
        }
    }
}