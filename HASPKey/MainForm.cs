﻿using DevExpress.Charts.Native;
using Presenter;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using ViewContract;
using System.Linq;


namespace HASPKey
{
    public partial class MainForm : DevExpress.XtraEditors.XtraForm, IMainView, IUpdateDataBaseMain
    {
        private IPresenterMain presenter;
        private const string errorStr = "Ошибка";
        public bool ErrorDataBase { get; set; } = false;

        public MainForm()
        {
            InitializeComponent();
            presenter = new PresenterMain(this);
            ErrorDB(); 
        }
        private void ErrorDB()
        {
            if (ErrorDataBase)
            {
                EditToolStripMenuItem.Enabled = false;
                buttonAll.Enabled = false;
                buttonSearchClient.Enabled = false;
            }
            else
            {
                EditToolStripMenuItem.Enabled = true;
                buttonAll.Enabled = true;
                buttonSearchClient.Enabled = true;
            }
        }

        public void MessageError(string errorText)
        {
            MessageBox.Show(errorText, errorStr, MessageBoxButtons.OK, MessageBoxIcon.Error);
            ErrorDB();
        }

        private void ВыходToolStripMenuItem_Click(object sender, EventArgs e)
            => this.Close();
        public void Bind(List<ModelEntities.ModelViewMain> homes)
        => bindingHome.DataSource = homes != null ? new BindingList<ModelEntities.ModelViewMain>(homes)
                                                  : new BindingList<ModelEntities.ModelViewMain>();

        private void KeyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (HaspKeyView haspKey = new HaspKeyView())
            {
                haspKey.DataUpdated += presenter.Views;
                haspKey.ShowDialog();
            }
        }

        private void FeatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (FeatureView feature = new FeatureView())
            {
                feature.DataUpdated += presenter.Views;
                feature.ShowDialog();
            }
        }

        private void ClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (ClientView client = new ClientView())
            {
                client.DataUpdated += presenter.Views;
                client.ShowDialog();
            }
        }

        private void KeyFeatureToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (KeyFeatureView keyFeatureView = new KeyFeatureView())
            {
                keyFeatureView.DataUpdated += presenter.Views;
                keyFeatureView.ShowDialog();
            }
        }

        private void DataGridViewHomeView_DataBindingComplete(object sender, System.Windows.Forms.DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in DataGridViewHomeView.Rows)
                row.HeaderCell.Value = (row.Index + 1).ToString();
        }

        private void KeyFeatureClientToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (KeyFeatureClientView keyFeatureClientView = new KeyFeatureClientView())
            {
                keyFeatureClientView.DataUpdated += presenter.Views;
                keyFeatureClientView.ShowDialog();
            }
        }

        private void Reference_Click(object sender, EventArgs e)
        {
            using (ReferenceView referenceView = new ReferenceView())
            {
                referenceView.ShowDialog();
            }
        }

        private void SelectDataBaseToolStripMenuItem_Click(object sender, EventArgs e)
        {
            using (SelectedDataBaseView selectedDataBaseView = new SelectedDataBaseView(this))
            {
                selectedDataBaseView.ShowDialog();
            }
        }

        void IUpdateDataBaseMain.UpdateDataBaseMain()
        {
            ErrorDataBase = false;
            presenter = new PresenterMain(this);
            ErrorDB();
        }

        private void ButtonSearchClient_Click(object sender, EventArgs e)
        {
            using (ClientView client = new ClientView(true))
            {
                client.ShowDialog();

                if (client.SearchIdClient != null)
                {                    
                    presenter.GetByClient(client.SearchIdClient);
                }
            }
        }

        private void ButtonAll_Click(object sender, EventArgs e)
        {
            presenter.Views();
           
        }


        private void ViewExpiredKeys_CheckedChanged(object sender, EventArgs e)
        {
           if (viewOldKeys.Checked)
           {
                presenter.ShowExpiredKeys();
           }
           else
           {
                presenter.Views();
           }
        }
                
        private void DataGridViewHomeView_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            string columnName = DataGridViewHomeView.Columns[e.ColumnIndex].Name;

            if (columnName == "endDateDataGridViewTextBoxColumn")
            {
                Sort(x => x.Date);
            }
             if (columnName == "clientDataGridViewTextBoxColumn")
            {
                Sort(x => x.Client);    
            }
            else if (columnName == "featureDataGridViewTextBoxColumn")
            {               
                Sort(x => x.Feature);
            }
            else if (columnName == "numberKeyDataGridViewTextBoxColumn")
            {
                Sort(x => x.NumberKey);
            }
            
        }

        private void Sort(Func<ModelEntities.ModelViewMain, object> param)
        {
            var currentList = bindingHome.List.Cast<ModelEntities.ModelViewMain>().ToList();
            var sortedList = currentList.OrderBy(param).ToList();

            if (currentList.SequenceEqual(sortedList))
            {
                sortedList = currentList.OrderByDescending(param).ToList();
            }

            Bind(sortedList);
        }

        private void Sort(Func<ModelEntities.ModelViewMain, object> param1, Func<ModelEntities.ModelViewMain, object> param2)
        {
            var currentList = bindingHome.List.Cast<ModelEntities.ModelViewMain>().ToList();
            var sortedList = currentList.OrderBy(param1).ThenBy(param2).ToList();


            if (currentList.SequenceEqual(sortedList))
            {
                sortedList = currentList.OrderByDescending(param1).ThenByDescending(param2).ToList();
            }

            Bind(sortedList);
        }


    }
}
