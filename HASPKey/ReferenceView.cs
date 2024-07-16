using Presenter;
using ViewContract;

namespace HASPKey
{
    public partial class ReferenceView : DevExpress.XtraEditors.XtraForm, IBindItemView<string>
    {
        private readonly IViewPresenter presenterRefernce;
        public ReferenceView()
        {
            InitializeComponent();
            presenterRefernce = new ReferencePresenter(this);
        }
        public void BindItem(string text) 
            => labelReference.Text = text;
    }
}
