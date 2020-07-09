﻿namespace HASPKey
{
    partial class EditKeyFeatureView
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.bindingFeature = new System.Windows.Forms.BindingSource(this.components);
            this.dgvFeature = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCalendarColumn1 = new HASPKey.DataGridViewCalendarColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calendarColumn1 = new HASPKey.CalendarColumn();
            this.calendarColumn2 = new HASPKey.CalendarColumn();
            this.calendarColumn3 = new HASPKey.CalendarColumn();
            this.serialNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDataGridViewTextBoxColumn = new HASPKey.DataGridViewCalendarColumn();
            this.endDateDataGridViewTextBoxColumn = new HASPKey.DataGridViewCalendarColumn();
            this.selectedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.dgvHaspKey = new System.Windows.Forms.DataGridView();
            this.HeadlineFeature = new System.Windows.Forms.Label();
            this.HeadliheHaspKey = new System.Windows.Forms.Label();
            this.bindingHaspKey = new System.Windows.Forms.BindingSource(this.components);
            this.serialNumberDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.innerIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isHomeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingFeature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHaspKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingHaspKey)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(583, 86);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // bindingFeature
            // 
            this.bindingFeature.DataSource = typeof(ModelEntities.ModelViewFeatureForEditKeyFeat);
            // 
            // dgvFeature
            // 
            this.dgvFeature.AllowUserToAddRows = false;
            this.dgvFeature.AutoGenerateColumns = false;
            this.dgvFeature.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFeature.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFeature.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeature.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serialNumberDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.startDateDataGridViewTextBoxColumn,
            this.endDateDataGridViewTextBoxColumn,
            this.selectedDataGridViewCheckBoxColumn});
            this.dgvFeature.DataSource = this.bindingFeature;
            this.dgvFeature.Location = new System.Drawing.Point(5, 181);
            this.dgvFeature.Name = "dgvFeature";
            this.dgvFeature.RowHeadersVisible = false;
            this.dgvFeature.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFeature.Size = new System.Drawing.Size(756, 281);
            this.dgvFeature.TabIndex = 5;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Number";
            this.dataGridViewTextBoxColumn1.HeaderText = "Номер";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 105;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 104;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn3.HeaderText = "Описание";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 105;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn4.HeaderText = "Описание";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "StartDate";
            this.dataGridViewTextBoxColumn5.HeaderText = "Начало действие";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            // 
            // dataGridViewCalendarColumn1
            // 
            this.dataGridViewCalendarColumn1.DataPropertyName = "EndDate";
            this.dataGridViewCalendarColumn1.HeaderText = "Окончание действия";
            this.dataGridViewCalendarColumn1.Name = "dataGridViewCalendarColumn1";
            this.dataGridViewCalendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridViewCalendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "EndDate";
            this.dataGridViewTextBoxColumn6.HeaderText = "Окончание действия";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            // 
            // calendarColumn1
            // 
            this.calendarColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calendarColumn1.DataPropertyName = "SerialNumber";
            this.calendarColumn1.HeaderText = "№ п/п";
            this.calendarColumn1.Name = "calendarColumn1";
            this.calendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.calendarColumn1.Width = 65;
            // 
            // calendarColumn2
            // 
            this.calendarColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calendarColumn2.DataPropertyName = "StartDate";
            this.calendarColumn2.HeaderText = "Начало действие";
            this.calendarColumn2.Name = "calendarColumn2";
            this.calendarColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // calendarColumn3
            // 
            this.calendarColumn3.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.calendarColumn3.DataPropertyName = "EndDate";
            this.calendarColumn3.HeaderText = "Окончание действия";
            this.calendarColumn3.Name = "calendarColumn3";
            this.calendarColumn3.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.calendarColumn3.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // serialNumberDataGridViewTextBoxColumn
            // 
            this.serialNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.serialNumberDataGridViewTextBoxColumn.DataPropertyName = "SerialNumber";
            this.serialNumberDataGridViewTextBoxColumn.HeaderText = "№ п/п";
            this.serialNumberDataGridViewTextBoxColumn.Name = "serialNumberDataGridViewTextBoxColumn";
            this.serialNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.serialNumberDataGridViewTextBoxColumn.Width = 65;
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn.HeaderText = "Номер";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Описание";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startDateDataGridViewTextBoxColumn
            // 
            this.startDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.startDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate";
            this.startDateDataGridViewTextBoxColumn.HeaderText = "Начало действие";
            this.startDateDataGridViewTextBoxColumn.Name = "startDateDataGridViewTextBoxColumn";
            this.startDateDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.startDateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // endDateDataGridViewTextBoxColumn
            // 
            this.endDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.endDateDataGridViewTextBoxColumn.DataPropertyName = "EndDate";
            this.endDateDataGridViewTextBoxColumn.HeaderText = "Окончание действия";
            this.endDateDataGridViewTextBoxColumn.Name = "endDateDataGridViewTextBoxColumn";
            this.endDateDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.endDateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // selectedDataGridViewCheckBoxColumn
            // 
            this.selectedDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.selectedDataGridViewCheckBoxColumn.DataPropertyName = "Selected";
            this.selectedDataGridViewCheckBoxColumn.HeaderText = "Выбран";
            this.selectedDataGridViewCheckBoxColumn.Name = "selectedDataGridViewCheckBoxColumn";
            this.selectedDataGridViewCheckBoxColumn.Width = 70;
            // 
            // dgvHaspKey
            // 
            this.dgvHaspKey.AllowUserToAddRows = false;
            this.dgvHaspKey.AutoGenerateColumns = false;
            this.dgvHaspKey.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvHaspKey.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvHaspKey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvHaspKey.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serialNumberDataGridViewTextBoxColumn1,
            this.innerIdDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn1,
            this.typeKeyDataGridViewTextBoxColumn,
            this.isHomeDataGridViewCheckBoxColumn});
            this.dgvHaspKey.DataSource = this.bindingHaspKey;
            this.dgvHaspKey.Location = new System.Drawing.Point(5, 25);
            this.dgvHaspKey.Name = "dgvHaspKey";
            this.dgvHaspKey.ReadOnly = true;
            this.dgvHaspKey.RowHeadersVisible = false;
            this.dgvHaspKey.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvHaspKey.Size = new System.Drawing.Size(509, 137);
            this.dgvHaspKey.TabIndex = 6;
            // 
            // HeadlineFeature
            // 
            this.HeadlineFeature.AutoSize = true;
            this.HeadlineFeature.Location = new System.Drawing.Point(285, 165);
            this.HeadlineFeature.Name = "HeadlineFeature";
            this.HeadlineFeature.Size = new System.Drawing.Size(194, 13);
            this.HeadlineFeature.TabIndex = 7;
            this.HeadlineFeature.Text = "Список функциональностей у ключа";
            // 
            // HeadliheHaspKey
            // 
            this.HeadliheHaspKey.AutoSize = true;
            this.HeadliheHaspKey.Location = new System.Drawing.Point(215, 9);
            this.HeadliheHaspKey.Name = "HeadliheHaspKey";
            this.HeadliheHaspKey.Size = new System.Drawing.Size(85, 13);
            this.HeadliheHaspKey.TabIndex = 8;
            this.HeadliheHaspKey.Text = "Список ключей";
            // 
            // bindingHaspKey
            // 
            this.bindingHaspKey.DataSource = typeof(ModelEntities.ModelViewHaspKey);
            // 
            // serialNumberDataGridViewTextBoxColumn1
            // 
            this.serialNumberDataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.serialNumberDataGridViewTextBoxColumn1.DataPropertyName = "SerialNumber";
            this.serialNumberDataGridViewTextBoxColumn1.HeaderText = "№ п/п";
            this.serialNumberDataGridViewTextBoxColumn1.Name = "serialNumberDataGridViewTextBoxColumn1";
            this.serialNumberDataGridViewTextBoxColumn1.ReadOnly = true;
            this.serialNumberDataGridViewTextBoxColumn1.Width = 65;
            // 
            // innerIdDataGridViewTextBoxColumn
            // 
            this.innerIdDataGridViewTextBoxColumn.DataPropertyName = "InnerId";
            this.innerIdDataGridViewTextBoxColumn.HeaderText = "Внутренний номер";
            this.innerIdDataGridViewTextBoxColumn.Name = "innerIdDataGridViewTextBoxColumn";
            this.innerIdDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // numberDataGridViewTextBoxColumn1
            // 
            this.numberDataGridViewTextBoxColumn1.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn1.HeaderText = "Номер";
            this.numberDataGridViewTextBoxColumn1.Name = "numberDataGridViewTextBoxColumn1";
            this.numberDataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // typeKeyDataGridViewTextBoxColumn
            // 
            this.typeKeyDataGridViewTextBoxColumn.DataPropertyName = "TypeKey";
            this.typeKeyDataGridViewTextBoxColumn.HeaderText = "Тип ключа";
            this.typeKeyDataGridViewTextBoxColumn.Name = "typeKeyDataGridViewTextBoxColumn";
            this.typeKeyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // isHomeDataGridViewCheckBoxColumn
            // 
            this.isHomeDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.isHomeDataGridViewCheckBoxColumn.DataPropertyName = "IsHome";
            this.isHomeDataGridViewCheckBoxColumn.HeaderText = "В компании";
            this.isHomeDataGridViewCheckBoxColumn.Name = "isHomeDataGridViewCheckBoxColumn";
            this.isHomeDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isHomeDataGridViewCheckBoxColumn.Width = 75;
            // 
            // EditKeyFeatureView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 467);
            this.Controls.Add(this.HeadliheHaspKey);
            this.Controls.Add(this.HeadlineFeature);
            this.Controls.Add(this.dgvHaspKey);
            this.Controls.Add(this.dgvFeature);
            this.Controls.Add(this.buttonSave);
            this.Name = "EditKeyFeatureView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование отношений ключ-функциональность";
            ((System.ComponentModel.ISupportInitialize)(this.bindingFeature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvHaspKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingHaspKey)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.BindingSource bindingFeature;
        private CalendarColumn calendarColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private CalendarColumn calendarColumn2;
        private CalendarColumn calendarColumn3;
        private System.Windows.Forms.DataGridView dgvFeature;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewCalendarColumn dataGridViewCalendarColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewCalendarColumn startDateDataGridViewTextBoxColumn;
        private DataGridViewCalendarColumn endDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridView dgvHaspKey;
        private System.Windows.Forms.BindingSource bindingHaspKey;
        private System.Windows.Forms.Label HeadlineFeature;
        private System.Windows.Forms.Label HeadliheHaspKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialNumberDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn innerIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isHomeDataGridViewCheckBoxColumn;
    }
}