using Entities;
using System.ComponentModel;

namespace ModelEntities
{
    public class ModelViewHaspKey : HaspKey
    {
        public ModelViewHaspKey()
        { }
        public ModelViewHaspKey(HaspKey haspKey)
        {
            Id = haspKey.Id;
            InnerId = haspKey.InnerId;
            Number = haspKey.Number;
            IsHome = haspKey.IsHome;
            TypeKey = haspKey.TypeKey;
            InnerId = haspKey.InnerId;
            Number = haspKey.Number;
        }
        /// <summary>
        /// Порядковый номер.
        /// </summary>         
        [DisplayName("№ п/п")]
        public int SerialNumber { get; set; }        
        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
    }
}
