using Presenter;
using View;

namespace HASPKey
{
    public partial class ReferenceView : DevExpress.XtraEditors.XtraForm, IBindItemView<string>
    {
        private readonly IPresenterView presenterRefernce;
        public ReferenceView()
        {
            InitializeComponent();
            presenterRefernce = new PresenterReference(this);
        }

        public void BindItem(string text) 
            => labelReference.Text = text;
    }
}
