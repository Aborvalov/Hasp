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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvKeyFeture = new System.Windows.Forms.DataGridView();
            this.serialNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.featureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.startDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingKeyFeature = new System.Windows.Forms.BindingSource(this.components);
            this.button1Delete = new System.Windows.Forms.Button();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonSelectFeature = new System.Windows.Forms.Button();
            this.labelSelectFeature = new System.Windows.Forms.Label();
            this.buttonSelectKey = new System.Windows.Forms.Button();
            this.labelSelectKey = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeyFeture)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingKeyFeature)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvKeyFeture
            // 
            this.dgvKeyFeture.AllowUserToAddRows = false;
            this.dgvKeyFeture.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvKeyFeture.AutoGenerateColumns = false;
            this.dgvKeyFeture.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvKeyFeture.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvKeyFeture.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvKeyFeture.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serialNumberDataGridViewTextBoxColumn,
            this.numberKeyDataGridViewTextBoxColumn,
            this.featureDataGridViewTextBoxColumn,
            this.typeKeyDataGridViewTextBoxColumn,
            this.startDateDataGridViewTextBoxColumn,
            this.endDateDataGridViewTextBoxColumn});
            this.dgvKeyFeture.DataSource = this.bindingKeyFeature;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvKeyFeture.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvKeyFeture.Location = new System.Drawing.Point(12, 1);
            this.dgvKeyFeture.Name = "dgvKeyFeture";
            this.dgvKeyFeture.ReadOnly = true;
            this.dgvKeyFeture.RowHeadersVisible = false;
            this.dgvKeyFeture.Size = new System.Drawing.Size(604, 450);
            this.dgvKeyFeture.TabIndex = 0;
            this.dgvKeyFeture.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvKeyFeture_CellClick);
            this.dgvKeyFeture.SelectionChanged += new System.EventHandler(this.DgvKeyFeture_SelectionChanged);
            this.dgvKeyFeture.DoubleClick += new System.EventHandler(this.DgvKeyFeture_DoubleClick);
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
            // numberKeyDataGridViewTextBoxColumn
            // 
            this.numberKeyDataGridViewTextBoxColumn.DataPropertyName = "NumberKey";
            this.numberKeyDataGridViewTextBoxColumn.HeaderText = "Номер ключа";
            this.numberKeyDataGridViewTextBoxColumn.Name = "numberKeyDataGridViewTextBoxColumn";
            this.numberKeyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // featureDataGridViewTextBoxColumn
            // 
            this.featureDataGridViewTextBoxColumn.DataPropertyName = "Feature";
            this.featureDataGridViewTextBoxColumn.HeaderText = "Функциональность";
            this.featureDataGridViewTextBoxColumn.Name = "featureDataGridViewTextBoxColumn";
            this.featureDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // typeKeyDataGridViewTextBoxColumn
            // 
            this.typeKeyDataGridViewTextBoxColumn.DataPropertyName = "TypeKey";
            this.typeKeyDataGridViewTextBoxColumn.HeaderText = "Тип ключа";
            this.typeKeyDataGridViewTextBoxColumn.Name = "typeKeyDataGridViewTextBoxColumn";
            this.typeKeyDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // startDateDataGridViewTextBoxColumn
            // 
            this.startDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.startDateDataGridViewTextBoxColumn.DataPropertyName = "StartDate";
            this.startDateDataGridViewTextBoxColumn.HeaderText = "Начало действия";
            this.startDateDataGridViewTextBoxColumn.Name = "startDateDataGridViewTextBoxColumn";
            this.startDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.startDateDataGridViewTextBoxColumn.Width = 80;
            // 
            // endDateDataGridViewTextBoxColumn
            // 
            this.endDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.endDateDataGridViewTextBoxColumn.DataPropertyName = "EndDate";
            this.endDateDataGridViewTextBoxColumn.HeaderText = "Окончание действия";
            this.endDateDataGridViewTextBoxColumn.Name = "endDateDataGridViewTextBoxColumn";
            this.endDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.endDateDataGridViewTextBoxColumn.Width = 80;
            // 
            // bindingKeyFeature
            // 
            this.bindingKeyFeature.DataSource = typeof(ModelEntities.ModelViewKeyFeature);
            // 
            // button1Delete
            // 
            this.button1Delete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1Delete.Location = new System.Drawing.Point(541, 509);
            this.button1Delete.Name = "button1Delete";
            this.button1Delete.Size = new System.Drawing.Size(75, 23);
            this.button1Delete.TabIndex = 1;
            this.button1Delete.Text = "Удалить";
            this.button1Delete.UseVisualStyleBackColor = true;
            this.button1Delete.Click += new System.EventHandler(this.Button1Delete_Click);
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpEndDate.Location = new System.Drawing.Point(393, 470);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(138, 21);
            this.dtpEndDate.TabIndex = 2;
            // 
            // labelEndDate
            // 
            this.labelEndDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(390, 454);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(141, 13);
            this.labelEndDate.TabIndex = 3;
            this.labelEndDate.Text = "Дата окончания действия";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.dtpStartDate.Location = new System.Drawing.Point(249, 470);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(138, 21);
            this.dtpStartDate.TabIndex = 4;
            this.dtpStartDate.ValueChanged += new System.EventHandler(this.DtpStartDate_ValueChanged);
            // 
            // labelStartDate
            // 
            this.labelStartDate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(246, 457);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(123, 13);
            this.labelStartDate.TabIndex = 5;
            this.labelStartDate.Text = "Дата начала действия";
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(10, 509);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 6;
            this.buttonAdd.Text = "Довавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Location = new System.Drawing.Point(94, 509);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 7;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonSelectFeature
            // 
            this.buttonSelectFeature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSelectFeature.Location = new System.Drawing.Point(122, 468);
            this.buttonSelectFeature.Name = "buttonSelectFeature";
            this.buttonSelectFeature.Size = new System.Drawing.Size(109, 23);
            this.buttonSelectFeature.TabIndex = 8;
            this.buttonSelectFeature.Text = "Выбрать функц...";
            this.buttonSelectFeature.UseVisualStyleBackColor = true;
            this.buttonSelectFeature.Click += new System.EventHandler(this.ButtonSelectFeature_Click);
            // 
            // labelSelectFeature
            // 
            this.labelSelectFeature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSelectFeature.AutoSize = true;
            this.labelSelectFeature.Location = new System.Drawing.Point(123, 492);
            this.labelSelectFeature.Name = "labelSelectFeature";
            this.labelSelectFeature.Size = new System.Drawing.Size(96, 13);
            this.labelSelectFeature.TabIndex = 9;
            this.labelSelectFeature.Text = "labelSelectFeature";
            // 
            // buttonSelectKey
            // 
            this.buttonSelectKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSelectKey.Location = new System.Drawing.Point(12, 468);
            this.buttonSelectKey.Name = "buttonSelectKey";
            this.buttonSelectKey.Size = new System.Drawing.Size(104, 23);
            this.buttonSelectKey.TabIndex = 10;
            this.buttonSelectKey.Text = "Выбрать ключ";
            this.buttonSelectKey.UseVisualStyleBackColor = true;
            this.buttonSelectKey.Click += new System.EventHandler(this.ButtonSelectKey_Click);
            // 
            // labelSelectKey
            // 
            this.labelSelectKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelSelectKey.AutoSize = true;
            this.labelSelectKey.Location = new System.Drawing.Point(12, 492);
            this.labelSelectKey.Name = "labelSelectKey";
            this.labelSelectKey.Size = new System.Drawing.Size(76, 13);
            this.labelSelectKey.TabIndex = 11;
            this.labelSelectKey.Text = "labelSelectKey";
            // 
            // KeyFeatureView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(628, 535);
            this.Controls.Add(this.dgvKeyFeture);
            this.Controls.Add(this.labelSelectKey);
            this.Controls.Add(this.buttonSelectKey);
            this.Controls.Add(this.labelSelectFeature);
            this.Controls.Add(this.buttonSelectFeature);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.dtpStartDate);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.dtpEndDate);
            this.Controls.Add(this.button1Delete);
            this.Name = "KeyFeatureView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Связь ключ-функциональность";
            ((System.ComponentModel.ISupportInitialize)(this.dgvKeyFeture)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingKeyFeature)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingKeyFeature;
        private System.Windows.Forms.DataGridView dgvKeyFeture;
        private System.Windows.Forms.Button button1Delete;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn featureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn startDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonSelectFeature;
        private System.Windows.Forms.Label labelSelectFeature;
        private System.Windows.Forms.Button buttonSelectKey;
        private System.Windows.Forms.Label labelSelectKey;
    }
}