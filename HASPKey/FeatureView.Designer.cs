namespace HASPKey
{
    partial class FeatureView
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
            this.bindingFeature = new System.Windows.Forms.BindingSource(this.components);
            this.dgvFeature = new System.Windows.Forms.DataGridView();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.serialNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelNumber = new System.Windows.Forms.Label();
            this.labelName = new System.Windows.Forms.Label();
            this.labelDescription = new System.Windows.Forms.Label();
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbDescription = new System.Windows.Forms.TextBox();
            this.ButtonAdd = new System.Windows.Forms.Button();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.ButtonSave = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.bindingFeature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeature)).BeginInit();
            this.SuspendLayout();
            // 
            // bindingFeature
            // 
            this.bindingFeature.DataSource = typeof(ModelEntities.ModelViewFeature);
            // 
            // dgvFeature
            // 
            this.dgvFeature.AllowUserToAddRows = false;
            this.dgvFeature.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvFeature.AutoGenerateColumns = false;
            this.dgvFeature.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvFeature.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvFeature.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvFeature.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.dgvFeature.DataSource = this.bindingFeature;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvFeature.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgvFeature.Location = new System.Drawing.Point(12, 12);
            this.dgvFeature.Name = "dgvFeature";
            this.dgvFeature.ReadOnly = true;
            this.dgvFeature.RowHeadersVisible = false;
            this.dgvFeature.Size = new System.Drawing.Size(500, 320);
            this.dgvFeature.TabIndex = 0;
            this.dgvFeature.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvFeature_CellClick);
            this.dgvFeature.SelectionChanged += new System.EventHandler(this.DgvFeature_SelectionChanged);
            this.dgvFeature.DoubleClick += new System.EventHandler(this.DgvFeature_DoubleClick);
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn.FillWeight = 89.3401F;
            this.numberDataGridViewTextBoxColumn.HeaderText = "Номер";
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.FillWeight = 89.3401F;
            this.nameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            this.descriptionDataGridViewTextBoxColumn.FillWeight = 89.3401F;
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Описание";
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // serialNumberDataGridViewTextBoxColumn
            // 
            this.serialNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.serialNumberDataGridViewTextBoxColumn.DataPropertyName = "SerialNumber";
            this.serialNumberDataGridViewTextBoxColumn.FillWeight = 131.9797F;
            this.serialNumberDataGridViewTextBoxColumn.HeaderText = "№ п/п";
            this.serialNumberDataGridViewTextBoxColumn.Name = "serialNumberDataGridViewTextBoxColumn";
            this.serialNumberDataGridViewTextBoxColumn.ReadOnly = true;
            this.serialNumberDataGridViewTextBoxColumn.Width = 65;
            // 
            // labelNumber
            // 
            this.labelNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(12, 335);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(38, 13);
            this.labelNumber.TabIndex = 1;
            this.labelNumber.Text = "Номер";
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(127, 335);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(80, 13);
            this.labelName.TabIndex = 2;
            this.labelName.Text = "Наименование";
            // 
            // labelDescription
            // 
            this.labelDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(254, 335);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(56, 13);
            this.labelDescription.TabIndex = 3;
            this.labelDescription.Text = "Описание";
            // 
            // tbNumber
            // 
            this.tbNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbNumber.Location = new System.Drawing.Point(12, 351);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(114, 21);
            this.tbNumber.TabIndex = 4;
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbName.Location = new System.Drawing.Point(130, 351);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(121, 21);
            this.tbName.TabIndex = 5;
            // 
            // tbDescription
            // 
            this.tbDescription.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbDescription.Location = new System.Drawing.Point(256, 351);
            this.tbDescription.Multiline = true;
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.tbDescription.Size = new System.Drawing.Size(161, 21);
            this.tbDescription.TabIndex = 6;
            // 
            // ButtonAdd
            // 
            this.ButtonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonAdd.Location = new System.Drawing.Point(12, 377);
            this.ButtonAdd.Name = "ButtonAdd";
            this.ButtonAdd.Size = new System.Drawing.Size(75, 23);
            this.ButtonAdd.TabIndex = 7;
            this.ButtonAdd.Text = "Добавить";
            this.ButtonAdd.UseVisualStyleBackColor = true;
            this.ButtonAdd.Click += new System.EventHandler(this.BtnAdd_Click);
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDelete.Location = new System.Drawing.Point(437, 377);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(75, 23);
            this.ButtonDelete.TabIndex = 8;
            this.ButtonDelete.Text = "Удалить";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // ButtonSave
            // 
            this.ButtonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.ButtonSave.Location = new System.Drawing.Point(93, 378);
            this.ButtonSave.Name = "ButtonSave";
            this.ButtonSave.Size = new System.Drawing.Size(75, 23);
            this.ButtonSave.TabIndex = 9;
            this.ButtonSave.Text = "Сохранить";
            this.ButtonSave.UseVisualStyleBackColor = true;
            this.ButtonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // FeatureView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(524, 405);
            this.Controls.Add(this.dgvFeature);
            this.Controls.Add(this.ButtonSave);
            this.Controls.Add(this.ButtonDelete);
            this.Controls.Add(this.ButtonAdd);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.tbNumber);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelNumber);
            this.Name = "FeatureView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Функциональность";
            ((System.ComponentModel.ISupportInitialize)(this.bindingFeature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgvFeature)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingFeature;
        private System.Windows.Forms.DataGridView dgvFeature;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelDescription;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbDescription;
        private System.Windows.Forms.Button ButtonAdd;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button ButtonSave;
    }
}