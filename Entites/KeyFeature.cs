using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities
{
    public class KeyFeature
    {
        public int Id { get; set; }
        public int IdHaspKey { get; set; }
        public int IdFeature { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is KeyFeature other))
                return false;

            if (ReferenceEquals(other, null))
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
