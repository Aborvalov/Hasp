using System;
using System.ComponentModel;

namespace ModelEntities
{
    /// <summary>
    /// Связка (ключ-фича)-клиент, таблица KeyFeatureClient.
    /// </summary>
    public class ModelViewMain
    {
        [DisplayName("Номер ключа")]
        public string NumberKey { get; set; }
        [DisplayName("Функциональность")]
        public string Feature { get; set; }
        [DisplayName("Клиент")]
        public string Client { get; set; }
        [DisplayName("Окончание действия")]
        public DateTime EndDate { get; set; }
    }
}
