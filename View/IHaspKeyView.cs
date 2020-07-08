using Entities;
using ModelEntities;

namespace View
{
    public interface IHaspKeyView : IEntitiesView<ModelViewHaspKey>
    {
        string InnerNumber { get; set; }
        string Number { get; set; }
        TypeKey TypeKey { get; set; }
        bool IsHome { get; set; }
    }
}
