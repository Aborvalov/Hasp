using ModelEntities;
using Presenter;
using View;

namespace HASPKey
{
    public partial class SelectedDataBaseView : DevExpress.XtraEditors.XtraForm, ISelectedDataBaseView
    {
        private readonly IPresenterView presenterRefernce;
        public SelectedDataBaseView()
        {
            InitializeComponent();
            presenterRefernce = new PresenterSelectedDataBase(this);
        }

        public void BindItem(TypeDateBase dateBase)
        {
            switch (dateBase)
            {
                case TypeDateBase.Test:
                    radioButtonTestDataBase.Checked = true;
                    break;
                case TypeDateBase.Work:
                    radioButtonWorkDataBase.Checked = true;
                    break;
                default:
                    {
                        radioButtonTestDataBase.Checked = false;
                        radioButtonWorkDataBase.Checked = false;
                        break;
                    }
            }
        }
    }
}
