using ModelEntities;

namespace View
{
    public interface IFeatureView : IEntitiesView<ModelViewFeature>
    {
        //string Number { get; set; }
        //string NameFeature { get; set; }
        //string Description { get; set; }

        void BindItem(ModelViewFeature entity);


    }
}
