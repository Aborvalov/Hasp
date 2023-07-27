using Entities;
using System.ComponentModel;

namespace ModelEntities
{
    public class ModelViewFeature2
    {
        public ModelViewFeature2()
        { }
        public ModelViewFeature2(Feature feature) : this()
        {
            Id = feature.Id;
            Name = feature.Name;
            Number = feature.Number;
            Description = feature.Description;
        }
        [Browsable(false)]
        public Feature Feature { get; private set; } = new Feature();
        [Browsable(false)]
        public int Id
        {
            get => Feature.Id;
            set => Feature.Id = value;
        }
        [DisplayName("Номер")]
        public int Number
        {
            get => Feature.Number;
            set => Feature.Number = value;
        }
        [DisplayName("Наименование")]
        public string Name
        {
            get => Feature.Name;
            set => Feature.Name = value;
        }
        [DisplayName("Описание")]
        public string Description
        {
            get => Feature.Description;
            set => Feature.Description = value;
        }

        public override bool Equals(object obj) => Feature.Equals(obj);
        public override int GetHashCode() => Feature.GetHashCode();
    }
}
