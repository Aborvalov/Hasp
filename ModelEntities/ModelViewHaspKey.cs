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
        
        [Browsable(false)]
        public int Id
        {
            get { return HaspKey.Id; }
            set { HaspKey.Id = value; }
        }

        [DisplayName("Внутренний номер")]
        public int InnerId
        {
            get => HaspKey.InnerId; 
            set => HaspKey.InnerId = value;
        }

        [DisplayName("Номер")]
        public string Number
        {
            get => HaspKey.Number; 
            set => HaspKey.Number = value;
        }

        [DisplayName("Тип ключа")]
        public TypeKey TypeKey
        {
            get => HaspKey.TypeKey; 
            set => HaspKey.TypeKey = value;
        }

        [DisplayName("В компании")]
        public bool IsHome
        {
            get => HaspKey.IsHome; 
            set => HaspKey.IsHome = value; 
        }

        public override int GetHashCode() => HaspKey.GetHashCode();
        public override bool Equals(object obj) => HaspKey.Equals(obj);
    }
}
