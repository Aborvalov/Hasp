using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace Entities
{
    public class HaspKey : IEquatable<HaspKey>
    {
        [Browsable(false)]
        public int Id { get; set; }
        /// <summary>
        /// Внутренний идентификатор.
        /// </summary>
        [DisplayName("Внутренний номер")]
        public int InnerId { get; set; }
        [DisplayName("Номер")]
        public string Number { get; set; }
        [DisplayName("Тип ключа")]
        public TypeKey TypeKey { get; set; }
        /// <summary>
        /// Местонахождение (у нас / клиент).
        /// </summary>
        [Column("Location")]
        [DisplayName("В компании")]
        public bool IsHome { get; set; }

        bool IEquatable<HaspKey>.Equals(HaspKey other) => Equals(other);
        public override int GetHashCode()
        {
            int hashProductNumber = Number == null ? 0 : Number.GetHashCode();

            int hashProductTypeKey  = TypeKey.GetHashCode();
            int hashProductId       = Id.GetHashCode();
            int hashProductInnerId  = InnerId.GetHashCode();
            int hashProductLocation = IsHome.GetHashCode();

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

            if (ReferenceEquals(this, other))
                return true;

            return Id.Equals(other.Id) &&
                   InnerId.Equals(other.InnerId) &&
                   Number.Equals(other.Number) &&
                   TypeKey.Equals(other.TypeKey) &&
                   IsHome.Equals(other.IsHome);
        }       
    }
}
