using Entities;
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
        private ModelViewClientNumberKeys newItem;

        private bool sortAscending = true;
        internal ModelViewFeature SearchFeature { get; set; } = null;
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
            buttonSearchByFeature.Visible = true;
            labelSearchInnerId.Visible = true;
            tbInnerIdHaspKey.Visible = true;
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

        private void ButtonSearchByFeature_Click(object sender, EventArgs e)
        {
            using (FeatureView feature = new FeatureView(true))
            {
                feature.FeatureSelected += (selectedFeature) =>
                {
                    if (selectedFeature != null)
                    {
                        presenterClientNumberKeys.GetByFeature(selectedFeature.Id);
                        labelFeature.Visible = true;
                        labelFeature.Text = selectedFeature.Name;
                        numberKeysDataGridViewTextBoxColumn.Visible = false;
                        feature.Close();
                    }
                };
                feature.ShowDialog();
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
            var bindingList = bindingClientNumberKeys.DataSource as BindingList<ModelViewClientNumberKeys>;
            
            newItem = new ModelViewClientNumberKeys
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
            numberKeysDataGridViewTextBoxColumn.Visible = true;
            var bindingList = bindingClientNumberKeys.DataSource as BindingList<ModelViewClientNumberKeys>;
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
            presenterClientNumberKeys.Display();
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
