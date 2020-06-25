using Entities;
using System;
using System.ComponentModel;

namespace Model
{
    /// <summary>
    /// Связка (ключ-фича)-клиент, таблица KeyFeatureClient.
    /// </summary>
    public class HomeView : KeyFeatureClient
    {
        /// <summary>
        /// Порядковый номер.
        /// </summary>         
        [DisplayName("№ п/п")]
        public int SerialNumber { get; set; }
        [DisplayName("Номер ключа")]
        public string NumberKey { get; set; }
        [DisplayName("Функциональность")]
        public string Feature { get; set; }
        [DisplayName("Клиент")]
        public string Client { get; set; }
        [DisplayName("Срок действия")]
        public DateTime EndDate { get; set; }

        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }
        public override int GetHashCode()
        {
            int hashProductNumberKey = NumberKey == null ? 0 : NumberKey.GetHashCode();
            int hashProductFeature = Feature == null ? 0 : Feature.GetHashCode();
            int hashProductClient = Client == null ? 0 : Client.GetHashCode();

            int hashProductSerialNumber = SerialNumber.GetHashCode();
            int hashProductEndDate = EndDate.GetHashCode();
            
            return base.GetHashCode() ^
                   hashProductNumberKey ^
                   hashProductFeature ^
                   hashProductClient ^
                   hashProductSerialNumber ^
                   hashProductEndDate;                                         
        }
    }
}
