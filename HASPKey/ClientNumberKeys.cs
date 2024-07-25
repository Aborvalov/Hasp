using DevExpress.Internal;
using DevExpress.XtraEditors;
using ModelEntities;
using Presenter;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ViewContract;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace HASPKey
{
    public partial class ClientNumberKeys : DevExpress.XtraEditors.XtraForm, IClientNumberKeysView
    {
        private readonly IClientNumberKeysPresenter presenterClientNumberKeys;

        public bool error = false;

        private const string errorStr = "Ошибка";
        private const string caption = "Удалить клиента";
        private const string message = "Вы уверены, что хотите удалить клиента?";
        private const string emptyClient = "Данный клиент не найден.";

        public event Action DataUpdated;

        public ClientNumberKeys(bool search)
        {
            InitializeComponent();
            presenterClientNumberKeys = new ClientNumberKeysPresenter(this);
            labelFeature.Text = string.Empty;
        }
        public ClientNumberKeys() : this(false)
        { }


        private void ButtonSearchByFeature_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void ButtonAll_Click(object sender, EventArgs e) => presenterClientNumberKeys.Display();
        

        private void DefaultView() 
        {

            labelFeature.Text = string.Empty;
            bindingClientNumberKeys.DataSource = new ModelViewClientNumberKeys();
            presenterClientNumberKeys.FillInputItem(bindingClientNumberKeys.DataSource as ModelViewClientNumberKeys);
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        { }

        private void ButtonSave_Click(object sender, EventArgs e)
        {                     
            error = false;
            presenterClientNumberKeys.FillModel(bindingClientNumberKeys.DataSource as ModelViewClientNumberKeys);
            if (!error)
            {
                DefaultView();
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            if (!(DataGridViewClientNumberKeys.CurrentRow.DataBoundItem is ModelViewClientNumberKeys row))
            {
                MessageError(emptyClient);
                return;
            }
            if (row.Id == 0)
            {
                bindingClientNumberKeys.RemoveCurrent();
                return;
            }
            if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                presenterClientNumberKeys.Remove(row.Id);
                DefaultView();
            }
        }

        public void DataChange() => DataUpdated?.Invoke();

        public void MessageError(string errorText)
        {
            MessageBox.Show(errorText, errorStr, MessageBoxButtons.OK, MessageBoxIcon.Error);
            error = true;
        }

        public void Bind(List<ModelViewClientNumberKeys> entity) =>
            bindingClientNumberKeys.DataSource = entity != null ? 
            new BindingList<ModelViewClientNumberKeys>(entity) : 
            new BindingList<ModelViewClientNumberKeys>();

        public void BindItem(ModelViewClientNumberKeys entity)
           => bindingClientNumberKeys.DataSource = entity ?? new ModelViewClientNumberKeys();

/*        private void DataGridViewClientNumberKeys_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DataGridViewClientNumberKeys.Rows)
                row.HeaderCell.Value = (row.Index + 1).ToString();
        }*/
    }
}
