﻿using ModelEntities;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using View;

namespace HASPKey
{
    public partial class EditKeyFeatureView : DevExpress.XtraEditors.XtraForm, IKeyFeatureView
    {
        public event Action DataUpdated;
        public string NumberHaspKey { get; set; }
        private IPresenterKeyFeature presenterEntities;

        private const string error = "Ошибка";
        private const string errorString = "Неправильно заполнена дата, окончание действия меньше начала.";
        private const string emptyKey = "Данный ключ не найден.";
        private const string caption = "Внести изменеия";
        private const string message = "Вы уверены, что хотите внести изменеия?";

        public EditKeyFeatureView()
        {
            InitializeComponent();
            presenterEntities = new PresenterEditKeyFeature(this);
        }
              
        public void DataChange() => DataUpdated?.Invoke();
        public void MessageError(string errorText) => MessageBox.Show(errorText, error, MessageBoxButtons.OK, MessageBoxIcon.Error);

        public void BindFeature(List<ModelViewFeatureForEditKeyFeat> feature)
        {
            bindingFeature.DataSource = feature != null ? new BindingList<ModelViewFeatureForEditKeyFeat>(feature)
                                                            : new BindingList<ModelViewFeatureForEditKeyFeat>();

            HeadlineFeature.Text = "Список функциональностей у ключа - " + NumberHaspKey;
        }
        public void BindKey(List<ModelViewHaspKey> key) 
            => bindingHaspKey.DataSource = key != null ? new BindingList<ModelViewHaspKey>(key)
                                                       : new BindingList<ModelViewHaspKey>();

        private void DgvHaspKey_CellClick(object sender, DataGridViewCellEventArgs e) => FillFeatureAtKey();

        private void DgvHaspKey_SelectionChanged(object sender, EventArgs e) => FillFeatureAtKey();

        private void FillFeatureAtKey()
        {
            if (!(dgvHaspKey.CurrentRow.DataBoundItem is ModelViewHaspKey row))
            {
                MessageError(emptyKey);
                return;
            }            
            presenterEntities.DisplayFeatureAtKey(row.Id);
        }
        
        private void ButtonSave_Click(object sender, EventArgs e)
        {
            var item = (bindingFeature.DataSource as BindingList<ModelViewFeatureForEditKeyFeat>).ToList();

            DefaultRow();

            if (MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                if (presenterEntities.CheckInputData(item))
                    presenterEntities.Edit(item);
                else
                    MessageError(errorString);
        }

        public void ErrorRow(int numberRow)
            =>dgvFeature.Rows[numberRow].DefaultCellStyle.BackColor = Color.Red;

        private void DefaultRow()
        {
            for (int i = 0; i < dgvFeature.RowCount; i++)
                DefaultRow(i);
        }
        public void DefaultRow(int numberRow)
           => dgvFeature.Rows[numberRow].DefaultCellStyle.BackColor = Color.White;

        private void DgvFeature_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            DefaultRow(e.RowIndex);
            var item = dgvFeature.CurrentRow.DataBoundItem as ModelViewFeatureForEditKeyFeat;
            presenterEntities.CheckInputData(item, e.RowIndex);

            if (item.IdKeyFeaure == 0)
                dgvFeature[6,e.RowIndex].Value = true;
        }
    }
}
