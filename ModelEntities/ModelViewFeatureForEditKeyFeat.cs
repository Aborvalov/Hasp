using Entities;
using System.ComponentModel;
using System;
using System.Runtime.CompilerServices;

namespace ModelEntities
{
    public class ModelViewFeatureForEditKeyFeat : INotifyPropertyChanged
    {
        public ModelViewFeatureForEditKeyFeat()
        { }
        public ModelViewFeatureForEditKeyFeat(Feature feature) : this()
        {
            Id = feature.Id;
            Name = feature.Name;
            Number = feature.Number;
            Description = feature.Description;
        }
        [Browsable(false)]
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
        [Browsable(false)]
        public int IdKey { get; set; }




        private DateTime? startDate;
        [DisplayName("Начало действие")]
        public DateTime? StartDate
        {
            get { return startDate; }
            set
            {
                startDate = value;
                OnPropertyChanged();
            }
        }
        private DateTime? endDate;
        [DisplayName("Окончание действия")]
        public DateTime? EndDate
        {
            get { return endDate; }
            set
            {
                endDate = value;
                OnPropertyChanged();
            }
        }
        private bool selected;
        [DisplayName("Выбран")]
        public bool Selected
        {
            get { return selected; }
            set
            {
                selected = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
            =>PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));

        public override bool Equals(object obj) => Feature.Equals(obj);
        public override int GetHashCode() => Feature.GetHashCode();
    }
}
