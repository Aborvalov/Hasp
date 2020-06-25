using Entities;
using System;

namespace Model
{
    /// <summary>
    /// Связка (ключ-фича)-клиент, таблица KeyFeatureClient.
    /// </summary>
    public class Home : KeyFeatureClient
    {
        /// <summary>
        /// Порядковый номер.
        /// </summary>
        public int SerialNumber { get; set; }
        public string NumberKey { get; set; }
        public string Feature { get; set; }
        public string Client { get; set; }
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
