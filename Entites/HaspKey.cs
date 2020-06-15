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

        public bool Equals(HaspKey other)
        {
            if (ReferenceEquals(other, null))
                return false;
            if (ReferenceEquals(this, other))
                return true;

            return Id.Equals(other.Id) && InnerId.Equals(other.InnerId);
        }
        public override int GetHashCode()
        {
            int hashProductNumber = Number == null ? 0 : Number.GetHashCode();

            int hashProductTypeKey = TypeKey.GetHashCode();
            int hashProductId      = Id.GetHashCode();
            int hashProductInnerId = InnerId.GetHashCode();

            return hashProductNumber ^ 
                   hashProductId ^
                   hashProductInnerId ^ 
                   hashProductTypeKey;
        }
    }
}
