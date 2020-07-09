using Entities;
using System.ComponentModel;

namespace ModelEntities
{
    public class ModelViewKeyFeatureClient
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
        public KeyFeatureClient KeyFeatureClient { get; private set; }
        [DisplayName("№ п/п")]
        public int SerialNumber { get; set; }
        [DisplayName("Номер ключа")]
        public string NumberKey { get; set; }
        [DisplayName("Функциональность")]
        public string Feature { get; set; }
        [DisplayName("Клиент")]
        public string Client { get; set; }
        [Browsable(false)]
        public int Id           
        {
            get { return KeyFeatureClient.Id; }
            set { KeyFeatureClient.Id = value; }
        }
        [Browsable(false)]
        public int IdKeyFeature
        {
            get { return KeyFeatureClient.IdKeyFeature; }
            set { KeyFeatureClient.IdKeyFeature = value; }
        }
        [Browsable(false)]
        public int IdClient
        {
            get { return KeyFeatureClient.IdClient; }
            set { KeyFeatureClient.IdClient = value; }
        }
        [DisplayName("Прочие")]
        public string Note
        {
            get { return KeyFeatureClient.Note; }
            set { KeyFeatureClient.Note = value; }
        }
        [DisplayName("Инициатор")]
        public string Initiator
        {
            get { return KeyFeatureClient.Initiator; }
            set { KeyFeatureClient .Initiator = value; }
        }

        public override int GetHashCode() => KeyFeatureClient.GetHashCode();
        public override bool Equals(object obj) => KeyFeatureClient.Equals(obj);
    }

}