using Entities;
using System.ComponentModel;

namespace ModelEntities
{
    public class ModelViewFeature
    {
        public ModelViewFeature()
        { }
        public ModelViewFeature(Feature feature) : this()
        {
            Id = feature.Id;
            Name = feature.Name;
            Number = feature.Number;
            Description = feature.Description;            
        }
        public Feature Feature { get; private set; } = new Feature();
        [DisplayName("№ п/п")]
        public int SerialNumber { get; set; }        
        [Browsable(false)]
        public int Id
        {
            get { return Feature.Id; }
            set { Feature.Id = value; }
        }
        [DisplayName("Номер")]
        public int Number
        {
            get { return Feature.Number; }
            set { Feature.Number = value; }
        }
        [DisplayName("Наименование")]
        public string Name
        {
            get { return Feature.Name; }
            set { Feature.Name = value; }
        }
        [DisplayName("Описание")]
        public string Description
        {
            get { return Feature.Description; }
            set { Feature.Description = value; }
        }

        public override bool Equals(object obj) => Feature.Equals(obj);
        public override int GetHashCode() => Feature.GetHashCode();
    }
}
