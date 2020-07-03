using Entities;
using System.ComponentModel;

namespace ModelEntities
{
    public class ModelViewHaspKey
    {       
        private int id;
        private int innerId;
        private string number;
        private TypeKey typeKey;
        private bool isHome;
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
        /// <summary>
        /// Порядковый номер.
        /// </summary>         
        [DisplayName("№ п/п")]
        public int SerialNumber { get; set; }                
        [Browsable(false)]
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                HaspKey.Id = value;
            }
        }
        /// <summary>
        /// Внутренний идентификатор.
        /// </summary>
        [DisplayName("Внутренний номер")]
        public int InnerId
        {
            get { return innerId; }
            set
            {
                innerId = value;
                HaspKey.InnerId = value;
            }
        }
        [DisplayName("Номер")]
        public string Number
        {
            get { return number; }
            set
            {
                number = value;
                HaspKey.Number = value;
            }
        }
        [DisplayName("Тип ключа")]
        public TypeKey TypeKey
        {
            get { return typeKey; }
            set
            {
                typeKey = value;
                HaspKey.TypeKey = value;
            }
        }
        /// <summary>
        /// Местонахождение (у нас / клиент).
        /// </summary>
        [DisplayName("В компании")]
        public bool IsHome
        {
            get { return isHome; }
            set
            {
                isHome = value;
                HaspKey.IsHome = value;
            }
        }



        //public override bool Equals(object obj) => base.Equals(obj);
        //public override int GetHashCode() => base.GetHashCode();
    }
}
