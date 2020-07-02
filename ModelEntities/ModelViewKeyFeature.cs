using Entities;
using System.ComponentModel;

namespace ModelEntities
{
    public class ModelViewKeyFeature : KeyFeature
    {
        public ModelViewKeyFeature()
        { }
        public ModelViewKeyFeature(KeyFeature keyFeat) : this()
        {            
            Id = keyFeat.Id;
            IdFeature = keyFeat.IdFeature;
            IdHaspKey = keyFeat.IdHaspKey;
            StartDate = keyFeat.StartDate;
            EndDate = keyFeat.EndDate;
        }

        [DisplayName("№ п/п")]
        public int SerialNumber { get; set; }
        [DisplayName("Номер ключа")]
        public string NumberKey { get; set; }
        [DisplayName("Функциональность")]
        public string Feature { get; set; }
        [DisplayName("Тип ключа")]
        public TypeKey TypeKey { get; set; }

        public override bool Equals(object obj) => base.Equals(obj);
        public override int GetHashCode()
        {
            int hashProductNumberKey = NumberKey == null ? 0 : NumberKey.GetHashCode();
            int hashProductFeature = Feature == null ? 0 : Feature.GetHashCode();

            int hashProductTypeKey = TypeKey.GetHashCode();
            int hashProductSerialNumber = SerialNumber.GetHashCode();

            return base.GetHashCode() ^
                   hashProductNumberKey ^
                   hashProductFeature ^
                   hashProductTypeKey ^
                   hashProductSerialNumber;
        }
    }
}
