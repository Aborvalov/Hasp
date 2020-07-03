using System;
using DevExpress.Xpo;
using Entities;

namespace ModelEntities
{

    public class ModelViewKeyFeatureClient : KeyFeatureClient
    {
        public ModelViewKeyFeatureClient()
        { }
        public ModelViewKeyFeatureClient(KeyFeatureClient keyFeatureClient) : this()
        {
            Id = keyFeatureClient.Id;
            IdClient = keyFeatureClient.IdClient;
            IdKeyFeature = keyFeatureClient.IdKeyFeature;
            Initiator = keyFeatureClient.Initiator;
            Note = keyFeatureClient.Note;
        }
        [DisplayName("№ п/п")]
        public int SerialNumber { get; set; }
        [DisplayName("Номер ключа")]
        public string NumberKey { get; set; }
        [DisplayName("Функциональность")]
        public string Feature { get; set; }
        [DisplayName("Клиент")]
        public string Client { get; set; }
    }

}