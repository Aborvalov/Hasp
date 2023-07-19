using System;
using DevExpress.XtraWaitForm;
using ModelEntities;
using Presenter;
using ViewContract;

namespace HASPKey
{
    public partial class SelectedDataBaseView : DevExpress.XtraEditors.XtraForm, IBindItemView<TypeDataBase>
    {
        private readonly IPresenterSelectedDataBase presenterSelectedDataBase;
        private readonly IMainView mainView;
        private readonly MainForm_2 mainForm_2;

        public SelectedDataBaseView(IMainView homeView)
        {
            InitializeComponent();
            this.mainView = homeView ?? throw new System.ArgumentNullException(nameof(homeView));            
            presenterSelectedDataBase = new PresenterSelectedDataBase(this,(IUpdateDataBaseMain)homeView);
        }

        public SelectedDataBaseView(MainForm_2 mainForm_2)
        {
            this.mainForm_2 = mainForm_2;

        }

        

        public void BindItem(TypeDataBase dateBase)
        {
            switch (dateBase)
            {
                case TypeDataBase.Test:
                    radioButtonTestDataBase.Checked = true;
                    mainView.ErrorDataBase = false;                    
                    break;
                case TypeDataBase.Work:
                    radioButtonWorkDataBase.Checked = true;
                    mainView.ErrorDataBase = false;
                    break;
                default:
                    {
                        radioButtonTestDataBase.Checked = false;
                        radioButtonWorkDataBase.Checked = false;
                        mainView.ErrorDataBase = true;
                        break;
                    }
            }
        }

        private void RadioButtonTestDataBase_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonTestDataBase.Checked && 
                presenterSelectedDataBase!= null)
                presenterSelectedDataBase.Edit(TypeDataBase.Test);
        }

        private void RadioButtonWorkDataBase_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonWorkDataBase.Checked && 
                presenterSelectedDataBase != null)
                presenterSelectedDataBase.Edit(TypeDataBase.Work);
        }
    }
}
