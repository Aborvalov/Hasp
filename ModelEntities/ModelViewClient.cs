using Entities;
using System.ComponentModel;

namespace ModelEntities
{
    public class ModelViewClient : Client
    {
        public ModelViewClient()
        { }
        public ModelViewClient(Client client)
        {
            Id = client.Id;
            Name = client.Name;
            Address = client.Address;
            Phone = client.Phone;
            ContactPerson = client.ContactPerson;
        }
        [DisplayName("№ п/п")]
        public int SerialNumber { get; set; }
        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
    }
}
