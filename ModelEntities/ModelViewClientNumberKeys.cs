using Entities;
using System;
using System.ComponentModel;
using System.Data;

namespace ModelEntities
{
    public class ModelViewClientNumberKeys
    {
        public ModelViewClientNumberKeys() { }
        public ModelViewClientNumberKeys(ClientNumberKeys clientNumberKeys) : this()
        {
            Id = clientNumberKeys.Id;
            Name = clientNumberKeys.Name;
        }
        [Browsable(false)]
        public ClientNumberKeys ClientNumberKeys { get; private set; } = new ClientNumberKeys();

        [Browsable(false)]
        public int Id
        {
            get => ClientNumberKeys.Id;
            set => ClientNumberKeys.Id = value;
        }

        [DisplayName("Наименование")]
        public string Name
        {
            get => ClientNumberKeys.Name;
            set => ClientNumberKeys.Name = value;
        }

        [DisplayName("Количество ключей")]
        public int NumberKeys { get; set; }

        [DisplayName("Количество функциональностей")]
        public int NumberFeatures { get; set; }

        [DisplayName("Дата окончания")]
        public string EndDate { get; set; }

        public override int GetHashCode() => ClientNumberKeys.GetHashCode();
        public override bool Equals(object obj) => ClientNumberKeys.Equals(obj);
    }
}