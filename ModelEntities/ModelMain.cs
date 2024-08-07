using System;
using System.ComponentModel;

namespace ModelEntities
{
    public class ModelMain
    {
        [Browsable(false)]
        public int IdClient { get; set; }

        [DisplayName("Номер ключа")]
        public string NumberKey { get; set; }

        [DisplayName("Функциональность")]
        public string Feature { get; set; }

        [DisplayName("Клиент")]
        public string Client { get; set; }

        [DisplayName("Окончание действия")]
        public DateTime EndDate { get; set;}

        [Browsable(false)]
        public int Name { get; set; }
    }
}