using Model;
using ViewContract;

namespace Presenter
{
    public class PresenterReference : IPresenterView
    {
        private readonly IBindItemView<string> referenceView;
        private readonly IItemModel<string> referenceModel;
        public PresenterReference(IBindItemView<string> reference)
        {
            this.referenceView = reference ?? throw new System.ArgumentNullException(nameof(reference));

            this.referenceModel = new ReferenceModel();
            Display();
        }
        public void Display() => referenceView.BindItem(referenceModel.GetItem());
    }
}
