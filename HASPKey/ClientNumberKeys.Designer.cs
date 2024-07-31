﻿namespace HASPKey
{
    partial class ClientNumberKeys
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridViewClientNumberKeys = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberKeysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberFeatureKeysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDateNumberKeysDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingClientNumberKeys = new System.Windows.Forms.BindingSource(this.components);
            this.labelFeature = new System.Windows.Forms.Label();
            this.labelSearchInnerId = new System.Windows.Forms.Label();
            this.tbInnerIdHaspKey = new System.Windows.Forms.TextBox();
            this.buttonAll = new System.Windows.Forms.Button();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonEdit = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonSearchByFeature = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewClientNumberKeys)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingClientNumberKeys)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewClientNumberKeys
            // 
            this.DataGridViewClientNumberKeys.AllowUserToAddRows = false;
            this.DataGridViewClientNumberKeys.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewClientNumberKeys.AutoGenerateColumns = false;
            this.DataGridViewClientNumberKeys.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewClientNumberKeys.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGridViewClientNumberKeys.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewClientNumberKeys.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.numberKeysDataGridViewTextBoxColumn,
            this.numberFeatureKeysDataGridViewTextBoxColumn,
            this.endDateNumberKeysDataGridViewTextBoxColumn});
            this.DataGridViewClientNumberKeys.DataSource = this.bindingClientNumberKeys;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewClientNumberKeys.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridViewClientNumberKeys.Location = new System.Drawing.Point(14, 70);
            this.DataGridViewClientNumberKeys.Margin = new System.Windows.Forms.Padding(4);
            this.DataGridViewClientNumberKeys.MinimumSize = new System.Drawing.Size(756, 516);
            this.DataGridViewClientNumberKeys.Name = "DataGridViewClientNumberKeys";
            this.DataGridViewClientNumberKeys.RowHeadersVisible = false;
            this.DataGridViewClientNumberKeys.RowHeadersWidth = 51;
            this.DataGridViewClientNumberKeys.Size = new System.Drawing.Size(756, 516);
            this.DataGridViewClientNumberKeys.TabIndex = 14;
            this.DataGridViewClientNumberKeys.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.DataGridViewClientNumberKeys_ColumnHeaderMouseClick);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // numberKeysDataGridViewTextBoxColumn
            // 
            this.numberKeysDataGridViewTextBoxColumn.DataPropertyName = "NumberKeys";
            this.numberKeysDataGridViewTextBoxColumn.HeaderText = "Количество ключей";
            this.numberKeysDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.numberKeysDataGridViewTextBoxColumn.Name = "numberKeysDataGridViewTextBoxColumn";
            this.numberKeysDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberKeysDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // numberFeatureKeysDataGridViewTextBoxColumn
            // 
            this.numberFeatureKeysDataGridViewTextBoxColumn.DataPropertyName = "NumberFeatures";
            this.numberFeatureKeysDataGridViewTextBoxColumn.HeaderText = "Количество функциональностей";
            this.numberFeatureKeysDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.numberFeatureKeysDataGridViewTextBoxColumn.Name = "numberFeatureKeysDataGridViewTextBoxColumn";
            this.numberFeatureKeysDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberFeatureKeysDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // endDateNumberKeysDataGridViewTextBoxColumn
            // 
            this.endDateNumberKeysDataGridViewTextBoxColumn.DataPropertyName = "EndDate";
            this.endDateNumberKeysDataGridViewTextBoxColumn.HeaderText = "Дата окончания";
            this.endDateNumberKeysDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.endDateNumberKeysDataGridViewTextBoxColumn.Name = "endDateNumberKeysDataGridViewTextBoxColumn";
            this.endDateNumberKeysDataGridViewTextBoxColumn.ReadOnly = true;
            this.endDateNumberKeysDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            // 
            // bindingClientNumberKeys
            // 
            this.bindingClientNumberKeys.DataSource = typeof(ModelEntities.ModelViewFeature);
            // 
            // labelFeature
            // 
            this.labelFeature.AutoSize = true;
            this.labelFeature.Location = new System.Drawing.Point(133, 21);
            this.labelFeature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFeature.Name = "labelFeature";
            this.labelFeature.Size = new System.Drawing.Size(78, 16);
            this.labelFeature.TabIndex = 15;
            this.labelFeature.Text = "labelFeature";
            // 
            // labelSearchInnerId
            // 
            this.labelSearchInnerId.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelSearchInnerId.AutoSize = true;
            this.labelSearchInnerId.Location = new System.Drawing.Point(324, -2);
            this.labelSearchInnerId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSearchInnerId.Name = "labelSearchInnerId";
            this.labelSearchInnerId.Size = new System.Drawing.Size(225, 16);
            this.labelSearchInnerId.TabIndex = 16;
            this.labelSearchInnerId.Text = "Поиск по внутреннему номеру ключа";
            // 
            // tbInnerIdHaspKey
            // 
            this.tbInnerIdHaspKey.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbInnerIdHaspKey.Location = new System.Drawing.Point(376, 18);
            this.tbInnerIdHaspKey.Margin = new System.Windows.Forms.Padding(4);
            this.tbInnerIdHaspKey.Name = "tbInnerIdHaspKey";
            this.tbInnerIdHaspKey.Size = new System.Drawing.Size(116, 23);
            this.tbInnerIdHaspKey.TabIndex = 17;
            this.tbInnerIdHaspKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tbInnerIdHaspKey_KeyDown);
            this.tbInnerIdHaspKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.tbInnerIdHaspKey_KeyPress);
            // 
            // buttonAll
            // 
            this.buttonAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAll.Location = new System.Drawing.Point(666, 13);
            this.buttonAll.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(88, 28);
            this.buttonAll.TabIndex = 18;
            this.buttonAll.Text = "Все";
            this.buttonAll.UseVisualStyleBackColor = true;
            this.buttonAll.Click += new System.EventHandler(this.ButtonAll_Click);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(133, 606);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(88, 28);
            this.buttonAdd.TabIndex = 19;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Location = new System.Drawing.Point(229, 606);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(88, 28);
            this.buttonSave.TabIndex = 20;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(681, 606);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(88, 28);
            this.buttonDelete.TabIndex = 21;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn1.Width = 251;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Количество ключей";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn2.Width = 251;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn3.HeaderText = "Срок действия";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn3.Width = 251;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "EndDate";
            this.dataGridViewTextBoxColumn4.HeaderText = "Дата окончания";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.dataGridViewTextBoxColumn4.Width = 188;
            // 
            // buttonEdit
            // 
            this.buttonEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonEdit.Location = new System.Drawing.Point(13, 606);
            this.buttonEdit.Margin = new System.Windows.Forms.Padding(4);
            this.buttonEdit.Name = "buttonEdit";
            this.buttonEdit.Size = new System.Drawing.Size(112, 28);
            this.buttonEdit.TabIndex = 22;
            this.buttonEdit.Text = "Редактировать";
            this.buttonEdit.UseVisualStyleBackColor = true;
            this.buttonEdit.Click += new System.EventHandler(this.ButtonEdit_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.Location = new System.Drawing.Point(325, 606);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(88, 28);
            this.buttonCancel.TabIndex = 23;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // buttonSearchByFeature
            // 
            this.buttonSearchByFeature.Location = new System.Drawing.Point(13, 13);
            this.buttonSearchByFeature.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSearchByFeature.Name = "buttonSearchByFeature";
            this.buttonSearchByFeature.Size = new System.Drawing.Size(112, 28);
            this.buttonSearchByFeature.TabIndex = 24;
            this.buttonSearchByFeature.Text = "Поиск по фиче";
            this.buttonSearchByFeature.UseVisualStyleBackColor = true;
            this.buttonSearchByFeature.Click += new System.EventHandler(this.ButtonSearchByFeature_Click);
            // 
            // ClientNumberKeys
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(782, 647);
            this.Controls.Add(this.buttonSearchByFeature);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonEdit);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.buttonAll);
            this.Controls.Add(this.tbInnerIdHaspKey);
            this.Controls.Add(this.labelSearchInnerId);
            this.Controls.Add(this.labelFeature);
            this.Controls.Add(this.DataGridViewClientNumberKeys);
            this.IconOptions.ShowIcon = false;
            this.MinimumSize = new System.Drawing.Size(784, 687);
            this.Name = "ClientNumberKeys";
            this.Text = "Клиенты";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewClientNumberKeys)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingClientNumberKeys)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataGridView DataGridViewClientNumberKeys;
        private System.Windows.Forms.Label labelFeature;
        private System.Windows.Forms.Label labelSearchInnerId;
        private System.Windows.Forms.TextBox tbInnerIdHaspKey;
        private System.Windows.Forms.Button buttonAll;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.BindingSource bindingClientNumberKeys;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberKeysDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberFeatureKeysDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDateNumberKeysDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button buttonEdit;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonSearchByFeature;
    }
}