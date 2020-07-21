using Entities;
using System;
using System.ComponentModel;

namespace ModelEntities
{
    public class ModelViewKeyFeatureClient
    {
        public ModelViewKeyFeatureClient()
        {
            this.Note = string.Empty;
            this.Initiator = string.Empty;
        }
        public ModelViewKeyFeatureClient(KeyFeatureClient keyFeatureClient) : this()
        {
            Id = keyFeatureClient.Id;
            IdClient = keyFeatureClient.IdClient;
            IdKeyFeature = keyFeatureClient.IdKeyFeature;
            Initiator = keyFeatureClient.Initiator;
            Note = keyFeatureClient.Note;
        }
        [Browsable(false)]
        public KeyFeatureClient KeyFeatureClient { get; private set; }
            = new KeyFeatureClient();
        [DisplayName("Номер ключа")]
        public string NumberKey { get; set; }
        [DisplayName("Тип ключа")]
        public TypeKey? TypeKey { get; set; } = null;
        [DisplayName("Функциональность")]
        public string Feature { get; set; }
        [Browsable(false)]
        public string Client { get; set; }
        [Browsable(false)]
        public int Id           
        {
            get => KeyFeatureClient.Id; 
            set => KeyFeatureClient.Id = value;
        }
        [Browsable(false)]
        public int IdKeyFeature
        {
            get => KeyFeatureClient.IdKeyFeature; 
            set => KeyFeatureClient.IdKeyFeature = value;
        }
        [Browsable(false)]
        public int IdClient
        {
            get => KeyFeatureClient.IdClient; 
            set => KeyFeatureClient.IdClient = value;
        }
        [DisplayName("Прочие")]
        public string Note
        {
            get => KeyFeatureClient.Note; 
            set => KeyFeatureClient.Note = value ?? string.Empty;
        }
        [DisplayName("Инициатор")]
        public string Initiator
        {
            get => KeyFeatureClient.Initiator;
            set => KeyFeatureClient.Initiator = value ?? string.Empty;
        }
        [DisplayName("Окончание действия")]
        public DateTime? EndDate { get; set; }
        [DisplayName("У клиента")]
        public bool Selected { get; set; }

        public override int GetHashCode() => KeyFeatureClient.GetHashCode();
        public override bool Equals(object obj) => KeyFeatureClient.Equals(obj);
    }
}