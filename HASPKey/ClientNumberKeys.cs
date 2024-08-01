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
        private ModelViewClient newItem;

        private bool sortAscending = true;
        internal ModelViewFeature SearchFeature { get; set; } = null;
        public bool error = false;
        private bool isSomethingChanged = false;

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
            buttonDelete.Visible = isVisible;
            buttonSave.Visible = isVisible;
            buttonSearchByFeature.Visible = !isVisible;
            labelSearchInnerId.Visible = !isVisible;
            tbInnerIdHaspKey.Visible = !isVisible;
            buttonCancel.Visible = isVisible;
        }

        public ClientNumberKeys(bool search)
        {
            InitializeComponent();
            presenterClientNumberKeys = new ClientNumberKeysPresenter(this); 
            SetButtonVisibility(false);
            labelFeature.Visible = false;
            buttonAll.Visible = true;
        }

        public ClientNumberKeys() : this(false)
        { }

        private void ButtonSearchByFeature_Click(object sender, EventArgs e)
        {
            using (FeatureView feature = new FeatureView(true))
            {
                feature.ShowDialog();
                if (feature.SearchFeature != null) 
                {
                    presenterClientNumberKeys.GetByFeature(feature.SearchFeature.Id);
                    labelFeature.Text = feature.SearchFeature.Name;
                }
            }
        }

        private void ButtonAll_Click(object sender, EventArgs e)
        {
            numberKeysDataGridViewTextBoxColumn.Visible = true;
            labelFeature.Visible = false;
            presenterClientNumberKeys.Display();

        }
        
        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            numberKeysDataGridViewTextBoxColumn.Visible = true;
            var bindingList = bindingClientNumberKeys.DataSource as BindingList<ModelViewClient>;
            
            newItem = new ModelViewClient
            {
                Id = -1,
                Address = null,
                Phone = null,
                ContactPerson = null,
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
            isSomethingChanged = true;
        }

        private void ButtonSave_Click(object sender, EventArgs e)
        {
            numberKeysDataGridViewTextBoxColumn.Visible = true;
            var bindingList = bindingClientNumberKeys.DataSource as BindingList<ModelViewClient>;
            error = false;
            if (MessageBox.Show(messageSave, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                presenterClientNumberKeys.Edit(bindingList.ToList());
                newItem = null;
            }
        }

        private void ButtonDelete_Click(object sender, EventArgs e)
        {
            numberKeysDataGridViewTextBoxColumn.Visible = true;
            if (!(DataGridViewClientNumberKeys.CurrentRow.DataBoundItem is ModelViewClient row))
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
            numberKeysDataGridViewTextBoxColumn.Visible = true;
            labelFeature.Visible = false;
            presenterClientNumberKeys.Display();
            SetButtonVisibility(true);
        }

        public void DataChange() => DataUpdated?.Invoke();

        public void MessageError(string errorText)
        {
            MessageBox.Show(errorText, errorStr, MessageBoxButtons.OK, MessageBoxIcon.Error);
            error = true;
        }

        public void Bind(List<ModelViewClient> entity)
        {
            bindingClientNumberKeys.DataSource = entity != null ? 
            new BindingList<ModelViewClient>(entity) : 
            new BindingList<ModelViewClient>();
            DataGridViewClientNumberKeys.DataSource = bindingClientNumberKeys;
        }

        public void BindItem(ModelViewClient entity)
        {
            bindingClientNumberKeys.DataSource = entity ?? new ModelViewClient();
            DataGridViewClientNumberKeys.DataSource = bindingClientNumberKeys;
        }


        private readonly Dictionary<string, Func<ModelViewClient, IComparable>> columnSorters = new Dictionary<string, Func<ModelViewClient, IComparable>>
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

        private void Sort(Func<ModelViewClient, IComparable> param)
        {
            var currentList = bindingClientNumberKeys.List.Cast<ModelViewClient>().ToList();
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

        private void DataGridViewClientNumberKeys_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            isSomethingChanged = true;
        }

        private void ButtonCancel_Click(object sender, EventArgs e)
        {
            if (isSomethingChanged)
            {
                presenterClientNumberKeys.Display();
                isSomethingChanged = false;
            }
            else
            {
                SetButtonVisibility(false);
            }
        }

        private void tbInnerIdHaspKey_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                int innerIdHaspKey;
                if (int.TryParse(tbInnerIdHaspKey.Text, out innerIdHaspKey))
                {
                    presenterClientNumberKeys.GetByInnerId(innerIdHaspKey);
                }
                else
                {
                    MessageError(errorString);
                }
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
