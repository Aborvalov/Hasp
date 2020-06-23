using System;

namespace Entities
{
    /// <summary>
    /// Связка (ключ-фича)-клиент, таблица KeyFeatureClient.
    /// </summary>
    public class HomeModel : KeyFeatureClient
    {
        public int IdKeyFeatureClient { get; set; }
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
            return base.GetHashCode();
        }
    }
}
