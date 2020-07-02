using System;
using System.ComponentModel;

namespace Entities
{
    public class KeyFeature
    {
        [Browsable(false)]
        public int Id { get; set; }
        [Browsable(false)]
        public int IdHaspKey { get; set; }
        [Browsable(false)]
        public int IdFeature { get; set; }
        [DisplayName("Начало действия")]
        public DateTime StartDate { get; set; }
        [DisplayName("Окончание действия")]
        public DateTime EndDate { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is KeyFeature other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Id.Equals(other.Id) &&
                   IdHaspKey.Equals(other.IdHaspKey) &&
                   IdFeature.Equals(other.IdFeature) &&
                   StartDate.Equals(other.StartDate) &&
                   EndDate.Equals(other.EndDate);

        }
        public override int GetHashCode()
        {
            int hashProductId = Id.GetHashCode();
            int hashProductIdHaspKey = IdHaspKey.GetHashCode();
            int hashProductIdFeature = IdFeature.GetHashCode();
            int hashProductStartDate = StartDate.GetHashCode();
            int hashProductEndDate = EndDate.GetHashCode();

            return hashProductId ^
                   hashProductIdHaspKey ^
                   hashProductIdFeature ^
                   hashProductStartDate ^
                   hashProductEndDate;
        }
    }
}
