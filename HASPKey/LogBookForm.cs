using ModelEntities;
using Presenter;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ViewContract;

namespace HASPKey
{
    public partial class LogBookForm : DevExpress.XtraEditors.XtraForm, ILogView
    {
        public bool error = false;
        private const string errorStr = "Ошибка";

        public LogBookForm(bool search)
        {
            InitializeComponent();
            LogPresenter presenterLog = new LogPresenter(this);
        }

        public LogBookForm() : this(false)
        { }

        public void Bind(List<ModelViewLog> entity)
        => logbookBindingSource.DataSource = entity != null ? new BindingList<ModelViewLog>(entity)
                                                         : new BindingList<ModelViewLog>();

        public void MessageError(string errorText)
        {
            MessageBox.Show(errorText, errorStr, MessageBoxButtons.OK, MessageBoxIcon.Error);
            error = true;
        }
    }
}