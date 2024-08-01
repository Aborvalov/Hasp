using Entities;
using System.ComponentModel;

namespace ModelEntities
{
    public class ModelViewClient
    {
        public ModelViewClient()
        { }
        public ModelViewClient(Client client) :this()
        {
            Id = client.Id;
            Name = client.Name;
            Address = client.Address;
            Phone = client.Phone;
            ContactPerson = client.ContactPerson;
        }
        [Browsable(false)]
        public Client Client { get; private set; } = new Client();        
        [Browsable(false)]
        public int Id
        {
            get => Client.Id; 
            set => Client.Id = value; 
        }
        [DisplayName("Наименование")]
        public string Name
        {
            get => Client.Name;
            set => Client.Name = value;
        }
        [DisplayName("Адрес")]
        public string Address
        {
            get => Client.Address; 
            set => Client.Address = value; 
        }
        [DisplayName("Телефон")]
        public string Phone
        {
            get => Client.Phone; 
            set => Client.Phone = value;
        }
        [DisplayName("Контактное лицо")]
        public string ContactPerson
        {
            get => Client.ContactPerson;
            set => Client.ContactPerson = value; 
        }

        [DisplayName("Количество ключей")]
        public int NumberKeys { get; set; }

        [DisplayName("Количество функциональностей")]
        public int NumberFeatures { get; set; }

        [DisplayName("Дата окончания")]
        public string EndDate { get; set; }
        public override bool Equals(object obj) => Client.Equals(obj);
        public override int GetHashCode() => Client.GetHashCode();
    }
}
