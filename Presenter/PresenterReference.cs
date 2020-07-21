using Model;
using View;

namespace Presenter
{
    public class PresenterReference : IPresenterView
    {
        private readonly IReferenceView referenceView;
        private readonly IItemModel<string> referenceModel;
        public PresenterReference(IReferenceView reference)
        {
            this.referenceView = reference ?? throw new System.ArgumentNullException(nameof(reference));

            this.referenceModel = new ReferenceModel();
            Display();
        }
        public void Display() => referenceView.BindItem(referenceModel.GetItem());
    }
}
