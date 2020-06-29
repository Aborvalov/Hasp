using System.ComponentModel;

namespace ModelEntities
{
    public class ModelViewHaspKey : Entities.HaspKey
    {
        public ModelViewHaspKey()
        { }
        public ModelViewHaspKey(Entities.HaspKey haspKey)
        {
            Id = haspKey.Id;
            InnerId = haspKey.InnerId;
            Number = haspKey.Number;
            IsHome = haspKey.IsHome;
            TypeKey = haspKey.TypeKey;
            ViewNumber = haspKey.InnerId.ToString() + " - \"" + haspKey.Number + "\"";
        }
        /// <summary>
        /// Порядковый номер.
        /// </summary>         
        [DisplayName("№ п/п")]
        public int SerialNumber { get; set; }
        [DisplayName("Номер")]
        public string ViewNumber { get; set; }
        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
    }
}
