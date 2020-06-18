using System.Collections.Generic;

namespace Entities
{
    public class Feature
    {
        public int Id { get; set; }
        public int Number { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is Feature other))
                return false;
            if (ReferenceEquals(this, other))
                return true;
            return Id.Equals(other.Id) &&
                   Number.Equals(other.Number) &&
                   Name.Equals(other.Name);
        }
        public override int GetHashCode()
        {
            int hashProductName        = Name        == null ? 0 : Name.GetHashCode();
            int hashProductDescription = Description == null ? 0 : Description.GetHashCode();

            int hashProductId      = Id.GetHashCode();
            int hashProductNumber = Number.GetHashCode();

            return hashProductId ^
                   hashProductNumber ^
                   hashProductName ^
                   hashProductDescription;
        }
    }
}
