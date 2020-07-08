using ModelEntities;
using System;

namespace View
{
    public interface IKeyFeatureView : IEntitiesView<ModelViewKeyFeature>
    {
        DateTime StartDate { get; set; }
        DateTime EndDate { get; set; }
        ModelViewHaspKey HaspKey { get; set; }
        ModelViewFeature Feature { get; set; }
    }
}
