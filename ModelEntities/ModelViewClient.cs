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
        public Client Client { get; private set; } = new Client();
        [DisplayName("№ п/п")]
        public int SerialNumber { get; set; }
        [Browsable(false)]
        public int Id
        {
            get { return Client.Id; }
            set { Client.Id = value; }
        }
        [DisplayName("Наименование")]
        public string Name
        {
            get { return Client.Name; }
            set { Client.Name = value; }
        }
        [DisplayName("Адрес")]
        public string Address
        {
            get { return Client.Address; }
            set { Client.Address = value; }
        }
        [DisplayName("Телефон")]
        public string Phone
        {
            get { return Client.Phone; }
            set { Client.Phone = value; }
        }
        [DisplayName("Контактное лицо")]
        public string ContactPerson
        {
            get { return Client.ContactPerson; }
            set { Client.ContactPerson = value; }
        }
        public override bool Equals(object obj) => Client.Equals(obj);
        public override int GetHashCode() => Client.GetHashCode();
    }
}
