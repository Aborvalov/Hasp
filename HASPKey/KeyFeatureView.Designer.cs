namespace HASPKey
{
    partial class KeyFeatureView
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
            presenterEntities.Dispose();
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            this.buttonSave = new System.Windows.Forms.Button();
            this.bindingFeature = new System.Windows.Forms.BindingSource(this.components);
            this.DataGridViewFeature = new System.Windows.Forms.DataGridView();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDataGridViewTextBoxColumn = new HASPKey.DataGridViewCalendarColumn();
            this.endDateDataGridViewTextBoxColumn = new HASPKey.DataGridViewCalendarColumn();
            this.selectedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.DataGridViewHaspKey = new System.Windows.Forms.DataGridView();
            this.innerIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingHaspKey = new System.Windows.Forms.BindingSource(this.components);
            this.HeadlineFeature = new System.Windows.Forms.Label();
            this.HeadliheHaspKey = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewCalendarColumn1 = new HASPKey.DataGridViewCalendarColumn();
            this.dataGridViewCalendarColumn2 = new HASPKey.DataGridViewCalendarColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.calendarColumn1 = new HASPKey.CalendarColumn();
            this.calendarColumn2 = new HASPKey.CalendarColumn();
            this.calendarColumn3 = new HASPKey.CalendarColumn();
            ((System.ComponentModel.ISupportInitialize)(this.bindingFeature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewFeature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewHaspKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingHaspKey)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Location = new System.Drawing.Point(5, 468);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // bindingFeature
            // 
            this.bindingFeature.DataSource = typeof(ModelEntities.ModelViewKeyFeature);
            // 
            // DataGridViewFeature
            // 
            this.DataGridViewFeature.AllowUserToAddRows = false;
            this.DataGridViewFeature.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewFeature.AutoGenerateColumns = false;
            this.DataGridViewFeature.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewFeature.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGridViewFeature.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewFeature.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn,
            this.startDateDataGridViewTextBoxColumn,
            this.endDateDataGridViewTextBoxColumn,
            this.selectedDataGridViewCheckBoxColumn});
            this.DataGridViewFeature.DataSource = this.bindingFeature;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewFeature.DefaultCellStyle = dataGridViewCellStyle3;
            this.DataGridViewFeature.Location = new System.Drawing.Point(5, 309);
            this.DataGridViewFeature.Name = "DataGridViewFeature";
            this.DataGridViewFeature.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewFeature.Size = new System.Drawing.Size(756, 153);
            this.DataGridViewFeature.TabIndex = 5;
            this.DataGridViewFeature.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewFeature_CellEndEdit);
            this.DataGridViewFeature.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridViewFeature_DataBindingComplete);
            this.DataGridViewFeature.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridViewFeature_KeyDown);
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
            this.startDateDataGridViewTextBoxColumn.Width = 110;
            // 
            // endDateDataGridViewTextBoxColumn
            // 
            this.endDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.endDateDataGridViewTextBoxColumn.DataPropertyName = "EndDate";
            this.endDateDataGridViewTextBoxColumn.HeaderText = "Окончание действия";
            this.endDateDataGridViewTextBoxColumn.Name = "endDateDataGridViewTextBoxColumn";
            this.endDateDataGridViewTextBoxColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.endDateDataGridViewTextBoxColumn.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.endDateDataGridViewTextBoxColumn.Width = 110;
            // 
            // selectedDataGridViewCheckBoxColumn
            // 
            this.selectedDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.selectedDataGridViewCheckBoxColumn.DataPropertyName = "Selected";
            this.selectedDataGridViewCheckBoxColumn.HeaderText = "Выбран";
            this.selectedDataGridViewCheckBoxColumn.Name = "selectedDataGridViewCheckBoxColumn";
            this.selectedDataGridViewCheckBoxColumn.Width = 70;
            // 
            // DataGridViewHaspKey
            // 
            this.DataGridViewHaspKey.AllowUserToAddRows = false;
            this.DataGridViewHaspKey.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewHaspKey.AutoGenerateColumns = false;
            this.DataGridViewHaspKey.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewHaspKey.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGridViewHaspKey.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewHaspKey.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.innerIdDataGridViewTextBoxColumn,
            this.numberDataGridViewTextBoxColumn1,
            this.typeKeyDataGridViewTextBoxColumn});
            this.DataGridViewHaspKey.DataSource = this.bindingHaspKey;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewHaspKey.DefaultCellStyle = dataGridViewCellStyle4;
            this.DataGridViewHaspKey.Location = new System.Drawing.Point(5, 25);
            this.DataGridViewHaspKey.Name = "DataGridViewHaspKey";
            this.DataGridViewHaspKey.ReadOnly = true;
            this.DataGridViewHaspKey.RowTemplate.DefaultCellStyle.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewHaspKey.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridViewHaspKey.Size = new System.Drawing.Size(756, 261);
            this.DataGridViewHaspKey.TabIndex = 6;
            this.DataGridViewHaspKey.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewHaspKey_CellClick);
            this.DataGridViewHaspKey.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridViewHaspKey_DataBindingComplete);
            this.DataGridViewHaspKey.SelectionChanged += new System.EventHandler(this.DataGridViewHaspKey_SelectionChanged);
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
            // bindingHaspKey
            // 
            this.bindingHaspKey.DataSource = typeof(ModelEntities.ModelViewHaspKey);
            // 
            // HeadlineFeature
            // 
            this.HeadlineFeature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.HeadlineFeature.AutoSize = true;
            this.HeadlineFeature.Location = new System.Drawing.Point(12, 293);
            this.HeadlineFeature.Name = "HeadlineFeature";
            this.HeadlineFeature.Size = new System.Drawing.Size(269, 13);
            this.HeadlineFeature.TabIndex = 7;
            this.HeadlineFeature.Text = "Список действующих функциональностей у ключа";
            // 
            // HeadliheHaspKey
            // 
            this.HeadliheHaspKey.AutoSize = true;
            this.HeadliheHaspKey.Location = new System.Drawing.Point(12, 9);
            this.HeadliheHaspKey.Name = "HeadliheHaspKey";
            this.HeadliheHaspKey.Size = new System.Drawing.Size(85, 13);
            this.HeadliheHaspKey.TabIndex = 8;
            this.HeadliheHaspKey.Text = "Список ключей";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Number";
            this.dataGridViewTextBoxColumn1.HeaderText = "Номер";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 105;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 104;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn3.HeaderText = "Описание";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 105;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Description";
            this.dataGridViewTextBoxColumn4.HeaderText = "Описание";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 139;
            // 
            // dataGridViewCalendarColumn1
            // 
            this.dataGridViewCalendarColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewCalendarColumn1.DataPropertyName = "StartDate";
            this.dataGridViewCalendarColumn1.HeaderText = "Начало действие";
            this.dataGridViewCalendarColumn1.Name = "dataGridViewCalendarColumn1";
            this.dataGridViewCalendarColumn1.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCalendarColumn1.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewCalendarColumn2
            // 
            this.dataGridViewCalendarColumn2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewCalendarColumn2.DataPropertyName = "EndDate";
            this.dataGridViewCalendarColumn2.HeaderText = "Окончание действия";
            this.dataGridViewCalendarColumn2.Name = "dataGridViewCalendarColumn2";
            this.dataGridViewCalendarColumn2.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridViewCalendarColumn2.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn5.DataPropertyName = "StartDate";
            this.dataGridViewTextBoxColumn5.HeaderText = "Начало действие";
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 65;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "EndDate";
            this.dataGridViewTextBoxColumn6.HeaderText = "Окончание действия";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.Width = 122;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Number";
            this.dataGridViewTextBoxColumn7.HeaderText = "Номер";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.Width = 122;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "TypeKey";
            this.dataGridViewTextBoxColumn8.HeaderText = "Тип ключа";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.Width = 122;
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
            // KeyFeatureView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(764, 495);
            this.Controls.Add(this.HeadliheHaspKey);
            this.Controls.Add(this.HeadlineFeature);
            this.Controls.Add(this.DataGridViewHaspKey);
            this.Controls.Add(this.DataGridViewFeature);
            this.Controls.Add(this.buttonSave);
            this.Name = "KeyFeatureView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование отношений ключ-функциональность";
            this.Load += new System.EventHandler(this.EditKeyFeatureView_Load);
            ((System.ComponentModel.ISupportInitialize)(this.bindingFeature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewFeature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewHaspKey)).EndInit();
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
        private System.Windows.Forms.DataGridView DataGridViewFeature;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private DataGridViewCalendarColumn dataGridViewCalendarColumn1;
        private System.Windows.Forms.DataGridView DataGridViewHaspKey;
        private System.Windows.Forms.BindingSource bindingHaspKey;
        private System.Windows.Forms.Label HeadlineFeature;
        private System.Windows.Forms.Label HeadliheHaspKey;
        private DataGridViewCalendarColumn dataGridViewCalendarColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private DataGridViewCalendarColumn startDateDataGridViewTextBoxColumn;
        private DataGridViewCalendarColumn endDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn innerIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeKeyDataGridViewTextBoxColumn;
    }
}