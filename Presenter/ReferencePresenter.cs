using Model;
using ViewContract;

namespace Presenter
{
    public class ReferencePresenter : IViewPresenter
    {
        private readonly IBindItemView<string> referenceView;
        private readonly IItemModel<string> referenceModel;
        
        public ReferencePresenter(IBindItemView<string> reference)
        {
            this.referenceView = reference ?? throw new System.ArgumentNullException(nameof(reference));

            this.referenceModel = new ReferenceModel();
            Display();
        }
        
        public void Display() => referenceView.BindItem(referenceModel.GetItem());
    }
}
