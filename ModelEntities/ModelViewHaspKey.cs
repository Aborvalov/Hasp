using Entities;
using System.ComponentModel;

namespace ModelEntities
{
    public class ModelViewHaspKey
    {
        public ModelViewHaspKey()
        { }
        public ModelViewHaspKey(HaspKey haspKey) : this()
        {
            Id = haspKey.Id;
            InnerId = haspKey.InnerId;
            Number = haspKey.Number;
            IsHome = haspKey.IsHome;
            TypeKey = haspKey.TypeKey;
        }
        [Browsable(false)]
        public HaspKey HaspKey { get; private set; } = new HaspKey();        
        [DisplayName("№ п/п")]
        public int SerialNumber { get; set; }
        [Browsable(false)]
        public int Id
        {
            get { return HaspKey.Id; }
            set { HaspKey.Id = value; }
        }
        /// <summary>
        /// Внутренний идентификатор.
        /// </summary>
        [DisplayName("Внутренний номер")]
        public int InnerId
        {
            get { return HaspKey.InnerId; }
            set { HaspKey.InnerId = value; }
        }
        [DisplayName("Номер")]
        public string Number
        {
            get { return HaspKey.Number; }
            set { HaspKey.Number = value; }
        }
        [DisplayName("Тип ключа")]
        public TypeKey TypeKey
        {
            get { return HaspKey.TypeKey; }
            set { HaspKey.TypeKey = value;}
        }
        /// <summary>
        /// Местонахождение (у нас / клиент).
        /// </summary>
        [DisplayName("В компании")]
        public bool IsHome
        {
            get { return HaspKey.IsHome; }
            set {HaspKey.IsHome = value; }
        }
        public override int GetHashCode() => HaspKey.GetHashCode();
        public override bool Equals(object obj) => HaspKey.Equals(obj);
    }
}
