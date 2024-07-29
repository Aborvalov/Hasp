using DevExpress.Data;
using DevExpress.XtraLayout.Customization.Templates;
using DevExpress.XtraReports.Localization;
using Logic;
using Model;
using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using ViewContract;

namespace HASPKey
{
    public partial class ClientNumberKeys : DevExpress.XtraEditors.XtraForm, IClientNumberKeysView
    {
        private readonly IClientNumberKeysPresenter presenterClientNumberKeys;
        private readonly IPresenterReference presenterClient;
        private readonly IClientNumberKeysModel clientNumberKeysModel;
        private readonly IClientNumberKeysView entitiesclnkView;

        private bool sortAscending = true;

        public bool error = false;

        private const string errorStr = "Ошибка";
        private const string caption = "Удалить клиента";
        private const string messageDelete = "Вы уверены, что хотите удалить клиента?";
        private const string messageSave = "Вы уверены, что хотите сохранить клиента?";
        private const string emptyClient = "Данный клиент не найден.";
        private const string errorString = "Не заполнено поле.";

        public event Action DataUpdated;

        private void SetButtonVisibility(bool isVisible)
        {
            buttonAdd.Visible = isVisible;
            buttonAll.Visible = isVisible;
            buttonDelete.Visible = isVisible;
            buttonSave.Visible = isVisible;
            buttonSearchByFeature.Visible = isVisible;
            labelSearchInnerId.Visible = isVisible;
            tbInnerIdHaspKey.Visible = isVisible;
            buttonCancel.Visible = isVisible;
        }

        public ClientNumberKeys(bool search)
        {
            InitializeComponent();
            presenterClientNumberKeys = new ClientNumberKeysPresenter(this); 
            SetButtonVisibility(false);
            labelFeature.Visible = false;
        }
        public ClientNumberKeys() : this(false)
        { }

        private void DefaultView()
        {
            bindingClientNumberKeys.DataSource = new ModelViewClient();
            presenterClient.FillInputItem(bindingClientNumberKeys.DataSource as ModelViewClient);
;
        }
        private void ButtonSearchByFeature_Click(object sender, EventArgs e)
        {
            DefaultView();
            using (FeatureView feature = new FeatureView(true))
            {
                feature.ShowDialog();

                if (feature.SearchFeature != null)
                {
                    presenterClient.GetByFeature(feature.SearchFeature);
                    labelFeature.Text = feature.SearchFeature.Name;
                }
            }
        }

        private void ButtonAll_Click(object sender, EventArgs e) =>
            presenterClientNumberKeys.Display();
        
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var bindingList = bindingClientNumberKeys.DataSource as BindingList<ModelViewClientNumberKeys>;
            
            var newItem = new ModelViewClientNumberKeys
            {
                Id = -1,
                NumberKeys = 0,
                NumberFeatures = 0,
                EndDate = "нет активных"
            };
            
            bindingList.Add(newItem);
            DataGridViewClientNumberKeys.Refresh();
         
            int rowIndex = bindingList.IndexOf(newItem);
            if (rowIndex >= 0)
            {
                DataGridViewClientNumberKeys.CurrentCell = DataGridViewClientNumberKeys.Rows[rowIndex].Cells[0];
                DataGridViewClientNumberKeys.BeginEdit(true);
            }
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            var bindingList = bindingClientNumberKeys.DataSource as BindingList<ModelViewClientNumberKeys>;
            error = false;
            if (MessageBox.Show(messageSave, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
            presenterClientNumberKeys.Edit(bindingList.ToList());
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
            if (MessageBox.Show(messageDelete, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                presenterClientNumberKeys.Remove(row.Id);
            }
        }

        private void ButtonEdit_Click(object sender, EventArgs e)
        {
            SetButtonVisibility(true);
        }

        public void DataChange() => DataUpdated?.Invoke();

        public void MessageError(string errorText)
        {
            MessageBox.Show(errorText, errorStr, MessageBoxButtons.OK, MessageBoxIcon.Error);
            error = true;
        }

        public void Bind(List<ModelViewClientNumberKeys> entity)
        {
            bindingClientNumberKeys.DataSource = entity != null ? 
            new BindingList<ModelViewClientNumberKeys>(entity) : 
            new BindingList<ModelViewClientNumberKeys>();
            DataGridViewClientNumberKeys.DataSource = bindingClientNumberKeys;
        }

        public void BindItem(ModelViewClientNumberKeys entity)
        {
            bindingClientNumberKeys.DataSource = entity ?? new ModelViewClientNumberKeys();
            DataGridViewClientNumberKeys.DataSource = bindingClientNumberKeys;
        }


        private readonly Dictionary<string, Func<ModelViewClientNumberKeys, IComparable>> columnSorters = new Dictionary<string, Func<ModelViewClientNumberKeys, IComparable>>
        {
            { "nameDataGridViewTextBoxColumn", x => x.Name },
            { "numberKeysDataGridViewTextBoxColumn", x => x.NumberKeys },
            { "numberFeatureKeysDataGridViewTextBoxColumn", x => x.NumberFeatures },
            { "endDateNumberKeysDataGridViewTextBoxColumn", x =>
                {
                    if (x.EndDate == "\u221E")
                    {
                        return DateTime.MaxValue;
                    }
                    else if (x.EndDate == "нет активных")
                    {
                        return DateTime.MinValue;
                    }
                    else
                    {
                        return DateTime.Parse(x.EndDate);
                    }
                }
            }
        };

        private void Sort(Func<ModelViewClientNumberKeys, IComparable> param)
        {
            var currentList = bindingClientNumberKeys.List.Cast<ModelViewClientNumberKeys>().ToList();
            var sortedList = sortAscending ? currentList.OrderBy(param).ToList() : currentList.OrderByDescending(param).ToList();
            sortAscending = !sortAscending; 
            Bind(sortedList);
        }

        private void DataGridViewClientNumberKeys_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = DataGridViewClientNumberKeys.Columns[e.ColumnIndex].Name;

            if (columnSorters.ContainsKey(columnName))
            {
                Sort(columnSorters[columnName]);
            }
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            SetButtonVisibility(false);
        }

        private void tbInnerIdHaspKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                var tmp = int.Parse(tbInnerIdHaspKey.Text);
                presenterClient.GetByNumberKey(int.Parse(tbInnerIdHaspKey.Text));
            }
        }

        private void tbInnerIdHaspKey_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
    }
}
