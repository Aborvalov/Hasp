using Entities;
using System.ComponentModel;

namespace ModelEntities
{
    public class ModelViewFeature : Feature
    {
        public ModelViewFeature()
        { }
        public ModelViewFeature(Feature feature)
        {
            Id = feature.Id;
            Name = feature.Name;
            Number = feature.Number;
            Description = feature.Description;            
        }
        [DisplayName("№ п/п")]
        public int SerialNumber { get; set; }
        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode() => base.GetHashCode();
    }
}
