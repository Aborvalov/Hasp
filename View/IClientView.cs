using ModelEntities;

namespace View
{
    public interface IClientView : IEntitiesView<ModelViewClient>
    {
        string NameClient { get; set; }
        string Address { get; set; }
        string Phone { get; set; }
        string ContactPerson { get; set; }
    }
}
