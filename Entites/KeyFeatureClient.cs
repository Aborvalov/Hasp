using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Entities
{
    [DisplayColumn("City", "PostalCode", false)]
    public class KeyFeatureClient
    {
        [Browsable(false)]
        public int Id { get; set; }
        [Browsable(false)]
        public int IdKeyFeature { get; set; }
        [Browsable(false)]
        public int IdClient { get; set; }
        [Browsable(false)]
        public string Note { get; set; }
        [Browsable(false)]
        public string Initiator { get; set; }

        public override bool Equals(object obj)
        {
            if (!(obj is KeyFeatureClient other))
                return false;

            if (ReferenceEquals(this, other))
                return true;

            return Id.Equals(other.Id) &&
                   IdKeyFeature.Equals(other.IdKeyFeature) &&
                   IdClient.Equals(other.IdClient) &&
                   Note.Equals(other.Note) &&
                   Initiator.Equals(other.Initiator);
        }
        public override int GetHashCode()
        {
            int hashProductNote      = Note == null ? 0 : Note.GetHashCode();
            int hashProductInitiator = Initiator == null ? 0 : Initiator.GetHashCode();

            int hashProductId           = Id.GetHashCode();
            int hashProductIdKeyFeature = IdKeyFeature.GetHashCode();
            int hashProductIdClient     = IdClient.GetHashCode();

            return hashProductId ^
                   hashProductIdKeyFeature ^
                   hashProductIdClient ^
                   hashProductNote ^
                   hashProductInitiator;
        }
    }
}