using Entities;
using System;
using System.ComponentModel;

namespace ModelEntities
{
    public class ModelViewKeyFeature
    {
        public ModelViewKeyFeature()
        { }
        public ModelViewKeyFeature(Feature feature) : this()
        {
            IdFeature = feature.Id;
            Name = feature.Name;
            Number = feature.Number;
            Description = feature.Description;
        }
        [Browsable(false)]
        public Feature Feature { get; private set; } = new Feature(); 
        [Browsable(false)]
        public int IdFeature
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
        [Browsable(false)]
        public int IdKey { get; set; }
        [Browsable(false)]
        public int IdKeyFeature { get; set; }

        [DisplayName("Начало действие")]
        public DateTime? StartDate { get; set; }
        [DisplayName("Окончание действия")]
        public DateTime? EndDate { get; set; }
        [DisplayName("Выбран")]
        public bool Selected { get; set; }

        public override bool Equals(object obj) => Feature.Equals(obj);
        public override int GetHashCode() => Feature.GetHashCode();
    }
}
