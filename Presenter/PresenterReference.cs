using Model;
using View;

namespace Presenter
{
    public class PresenterReference : IPresenterRefernce
    {
        private readonly IReferenceView referenceView;
        private readonly IReferenceModel referenceModel;
        public PresenterReference(IReferenceView reference)
        {
            this.referenceView = reference ?? throw new System.ArgumentNullException(nameof(reference));

            this.referenceModel = new ReferenceModel();
            Display();
        }
        public void Display() => referenceView.BindItem(referenceModel.GetText());
    }
}
