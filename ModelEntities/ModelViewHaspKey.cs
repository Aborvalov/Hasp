using Entities;
using System.ComponentModel;

namespace ModelEntities
{
    public class ModelViewHaspKey
    {
        public HaspKey haspKey { get; private set; }
        public ModelViewHaspKey()
        { }
        public ModelViewHaspKey(HaspKey haspKey) : this()
        {
            this.haspKey = haspKey;
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

        private int id;        
        [Browsable(false)]
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                haspKey.Id = value;
            }
        }


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
        [DisplayName("В компании")]
        public bool IsHome { get; set; }



        //public override bool Equals(object obj) => base.Equals(obj);
        //public override int GetHashCode() => base.GetHashCode();
    }
}
