using System;
using System.ComponentModel;

namespace ModelEntities
{
    /// <summary>
    /// Связка (ключ-фича)-клиент, таблица KeyFeatureClient.
    /// </summary>
    public class ModelViewMain 
    {
        [Browsable(false)]
        public int IdClient { get; set; }
        [DisplayName("Номер ключа")]
        public string NumberKey { get; set; }
        [DisplayName("Функциональность")]
        public string Feature { get; set; }
        [DisplayName("Клиент")]
        public string Client { get; set; }
        [Browsable(false)]
        public DateTime Date { get; set; }

        private string endDate;
        [DisplayName("Окончание действия")]

        public string EndDate 
        {
            get
            {
                return endDate;
            }
            set 
            {
                if (value.IndexOf("2111") >= 0)
                {
                    endDate = "бессрочные";
                }
                else
                {
                    endDate = value;
                }
            }
        }
    }
}
