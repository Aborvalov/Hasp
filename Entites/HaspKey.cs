using System;

namespace Entities
{
    public class HaspKey : IEquatable<HaspKey>
    {
        public int Id { get; set; }
        /// <summary>
        /// Внутренний идентификатор.
        /// </summary>
        public int InnerId { get; set; }
        public string Number { get; set; }
        public TypeKey TypeKey { get; set; }
        /// <summary>
        /// Местонахождение (у нас / клиент).
        /// </summary>
        public bool Location { get; set; }

        bool IEquatable<HaspKey>.Equals(HaspKey other) => Equals(other);
        public override int GetHashCode()
        {
            int hashProductNumber = Number == null ? 0 : Number.GetHashCode();

            int hashProductTypeKey  = TypeKey.GetHashCode();
            int hashProductId       = Id.GetHashCode();
            int hashProductInnerId  = InnerId.GetHashCode();
            int hashProductLocation = Location.GetHashCode();

            return hashProductNumber ^ 
                   hashProductId ^
                   hashProductInnerId ^ 
                   hashProductTypeKey ^
                   hashProductLocation;
        }
        public override bool Equals(object obj)
        {
            if (!(obj is HaspKey other))
                return false;

            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Id.Equals(other.Id) &&
                   InnerId.Equals(other.InnerId) &&
                   Number.Equals(other.Number) &&
                   TypeKey.Equals(other.TypeKey) &&
                   Location.Equals(other.Location);
        }       
    }
}
