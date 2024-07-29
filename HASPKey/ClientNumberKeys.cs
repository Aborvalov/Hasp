using DevExpress.Data;
using DevExpress.XtraLayout.Customization.Templates;
using DevExpress.XtraReports.Localization;
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
        private bool sortAscending = true;

        public bool error = false;

        private const string errorStr = "Ошибка";
        private const string caption = "Удалить клиента";
        private const string messageDelete = "Вы уверены, что хотите удалить клиента?";
        private const string messageSave = "Вы уверены, что хотите сохранить клиента?";
        private const string emptyClient = "Данный клиент не найден.";
        private const string errorString = "Не заполнено поле.";

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
            bindingClientNumberKeys.DataSource = new ModelViewClientNumberKeys();
            presenterClientNumberKeys.FillInputItem(bindingClientNumberKeys.DataSource as ModelViewClientNumberKeys);
            labelFeature.Text = string.Empty;
        }

        private void ButtonAdd_Click(object sender, EventArgs e)
        {
            var bindingList = bindingClientNumberKeys.DataSource as BindingList<ModelViewClientNumberKeys>;
            
            var newItem = new ModelViewClientNumberKeys
            {
                Id = bindingList.Any() ? bindingList.Max(item => item.Id) + 1 : 0,
                NumberKeys = -1,
                NumberFeatures = -1,
                EndDate = "нет активных"
            };
            
            bindingList.Add(newItem);
            DataGridViewClientNumberKeys.DataSource = null;
            DataGridViewClientNumberKeys.DataSource = bindingList;
         
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
            presenterClientNumberKeys.Edit(bindingList.ToList());
            if (!error)
                DefaultView();
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


        private readonly Dictionary<string, Func<ModelViewClientNumberKeys, IComparable>> columnSorters = new Dictionary<string, Func<ModelViewClientNumberKeys, IComparable>>
        {
            { "nameDataGridViewTextBoxColumn", x => x.Name },
            { "numberKeysDataGridViewTextBoxColumn", x => x.NumberKeys },
            { "numberFeatureKeysDataGridViewTextBoxColumn", x => x.NumberFeatures },
            { "endDateNumberKeysDataGridViewTextBoxColumn", x =>
                {
                    if (x.EndDate == "\u221E")
                    {
                        return DateTime.MinValue;
                    }
                    else if (x.EndDate == "нет активных")
                    {
                        return DateTime.MaxValue;
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
    }
}
