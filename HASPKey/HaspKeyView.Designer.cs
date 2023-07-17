namespace HASPKey
{
    partial class HaspKeyView
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
            presenterHaspKey.Dispose();

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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HaspKeyView));
            this.DataGridViewHaspKey = new System.Windows.Forms.DataGridView();
            this.innerIdDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.isHomeDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.bindingHaspKey = new System.Windows.Forms.BindingSource(this.components);
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.panelFiltr = new System.Windows.Forms.Panel();
            this.radioButtonPastDue = new System.Windows.Forms.RadioButton();
            this.radioButtonAll = new System.Windows.Forms.RadioButton();
            this.radioButtonActive = new System.Windows.Forms.RadioButton();
            this.LInnerNumber = new System.Windows.Forms.Label();
            this.tbInnerNumber = new System.Windows.Forms.TextBox();
            this.bindingItem = new System.Windows.Forms.BindingSource(this.components);
            this.tbNumber = new System.Windows.Forms.TextBox();
            this.labelNumber = new System.Windows.Forms.Label();
            this.labelType = new System.Windows.Forms.Label();
            this.comboBoxTypeKey = new System.Windows.Forms.ComboBox();
            this.checkBoxIsHome = new System.Windows.Forms.CheckBox();
            this.buttonSearchByClient = new System.Windows.Forms.Button();
            this.labelClient = new System.Windows.Forms.Label();
            this.Headline = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewHaspKey)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingHaspKey)).BeginInit();
            this.panelFiltr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingItem)).BeginInit();
            this.SuspendLayout();
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
            this.numberDataGridViewTextBoxColumn,
            this.typeKeyDataGridViewTextBoxColumn,
            this.isHomeDataGridViewCheckBoxColumn});
            this.DataGridViewHaspKey.DataSource = this.bindingHaspKey;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewHaspKey.DefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewHaspKey.EnableHeadersVisualStyles = false;
            this.DataGridViewHaspKey.Location = new System.Drawing.Point(14, 70);
            this.DataGridViewHaspKey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataGridViewHaspKey.Name = "DataGridViewHaspKey";
            this.DataGridViewHaspKey.ReadOnly = true;
            this.DataGridViewHaspKey.RowHeadersVisible = false;
            this.DataGridViewHaspKey.RowHeadersWidth = 51;
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.Black;
            this.DataGridViewHaspKey.RowsDefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridViewHaspKey.Size = new System.Drawing.Size(491, 570);
            this.DataGridViewHaspKey.TabIndex = 0;
            this.DataGridViewHaspKey.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewHaspKey_CellClick);
            this.DataGridViewHaspKey.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridViewHaspKey_DataBindingComplete);
            this.DataGridViewHaspKey.SelectionChanged += new System.EventHandler(this.DataGridViewHaspKey_SelectionChanged);
            this.DataGridViewHaspKey.DoubleClick += new System.EventHandler(this.DataGridViewHaspKey_DoubleClick);
            this.DataGridViewHaspKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridViewHaspKey_KeyDown);
            // 
            // innerIdDataGridViewTextBoxColumn
            // 
            this.innerIdDataGridViewTextBoxColumn.DataPropertyName = "InnerId";
            this.innerIdDataGridViewTextBoxColumn.FillWeight = 83.75635F;
            this.innerIdDataGridViewTextBoxColumn.HeaderText = "Внутренний номер";
            this.innerIdDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.innerIdDataGridViewTextBoxColumn.Name = "innerIdDataGridViewTextBoxColumn";
            this.innerIdDataGridViewTextBoxColumn.ReadOnly = true;
            this.innerIdDataGridViewTextBoxColumn.ToolTipText = "Внутренний номер ключа";
            // 
            // numberDataGridViewTextBoxColumn
            // 
            this.numberDataGridViewTextBoxColumn.DataPropertyName = "Number";
            this.numberDataGridViewTextBoxColumn.FillWeight = 83.75635F;
            this.numberDataGridViewTextBoxColumn.HeaderText = "Номер";
            this.numberDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.numberDataGridViewTextBoxColumn.Name = "numberDataGridViewTextBoxColumn";
            this.numberDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberDataGridViewTextBoxColumn.ToolTipText = "Номер ключа на корпусе";
            // 
            // typeKeyDataGridViewTextBoxColumn
            // 
            this.typeKeyDataGridViewTextBoxColumn.DataPropertyName = "TypeKey";
            this.typeKeyDataGridViewTextBoxColumn.FillWeight = 83.75635F;
            this.typeKeyDataGridViewTextBoxColumn.HeaderText = "Тип ключа";
            this.typeKeyDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.typeKeyDataGridViewTextBoxColumn.Name = "typeKeyDataGridViewTextBoxColumn";
            this.typeKeyDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeKeyDataGridViewTextBoxColumn.ToolTipText = "Тиа ключа";
            // 
            // isHomeDataGridViewCheckBoxColumn
            // 
            this.isHomeDataGridViewCheckBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.isHomeDataGridViewCheckBoxColumn.DataPropertyName = "IsHome";
            this.isHomeDataGridViewCheckBoxColumn.FillWeight = 83.75635F;
            this.isHomeDataGridViewCheckBoxColumn.HeaderText = "В компании";
            this.isHomeDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.isHomeDataGridViewCheckBoxColumn.Name = "isHomeDataGridViewCheckBoxColumn";
            this.isHomeDataGridViewCheckBoxColumn.ReadOnly = true;
            this.isHomeDataGridViewCheckBoxColumn.ToolTipText = "Нахождение ключа";
            this.isHomeDataGridViewCheckBoxColumn.Width = 80;
            // 
            // bindingHaspKey
            // 
            this.bindingHaspKey.DataSource = typeof(ModelEntities.ModelViewHaspKey);
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(14, 695);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(88, 28);
            this.buttonAdd.TabIndex = 4;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Location = new System.Drawing.Point(108, 695);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(88, 28);
            this.buttonSave.TabIndex = 5;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(418, 695);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(88, 28);
            this.buttonDelete.TabIndex = 6;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // panelFiltr
            // 
            this.panelFiltr.Controls.Add(this.radioButtonPastDue);
            this.panelFiltr.Controls.Add(this.radioButtonAll);
            this.panelFiltr.Controls.Add(this.radioButtonActive);
            this.panelFiltr.Location = new System.Drawing.Point(14, 15);
            this.panelFiltr.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.panelFiltr.Name = "panelFiltr";
            this.panelFiltr.Size = new System.Drawing.Size(288, 33);
            this.panelFiltr.TabIndex = 7;
            // 
            // radioButtonPastDue
            // 
            this.radioButtonPastDue.AutoSize = true;
            this.radioButtonPastDue.Location = new System.Drawing.Point(155, 4);
            this.radioButtonPastDue.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonPastDue.Name = "radioButtonPastDue";
            this.radioButtonPastDue.Size = new System.Drawing.Size(114, 20);
            this.radioButtonPastDue.TabIndex = 9;
            this.radioButtonPastDue.Text = "Просроченные";
            this.radioButtonPastDue.UseVisualStyleBackColor = true;
            this.radioButtonPastDue.CheckedChanged += new System.EventHandler(this.RadioButtonPastDue_CheckedChanged);
            // 
            // radioButtonAll
            // 
            this.radioButtonAll.AutoSize = true;
            this.radioButtonAll.Checked = true;
            this.radioButtonAll.Location = new System.Drawing.Point(4, 4);
            this.radioButtonAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonAll.Name = "radioButtonAll";
            this.radioButtonAll.Size = new System.Drawing.Size(48, 20);
            this.radioButtonAll.TabIndex = 8;
            this.radioButtonAll.TabStop = true;
            this.radioButtonAll.Text = "Все";
            this.radioButtonAll.UseVisualStyleBackColor = true;
            this.radioButtonAll.CheckedChanged += new System.EventHandler(this.RadioButtonAll_CheckedChanged);
            // 
            // radioButtonActive
            // 
            this.radioButtonActive.AutoSize = true;
            this.radioButtonActive.Location = new System.Drawing.Point(59, 4);
            this.radioButtonActive.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButtonActive.Name = "radioButtonActive";
            this.radioButtonActive.Size = new System.Drawing.Size(85, 20);
            this.radioButtonActive.TabIndex = 8;
            this.radioButtonActive.Text = "Активные";
            this.radioButtonActive.UseVisualStyleBackColor = true;
            this.radioButtonActive.CheckedChanged += new System.EventHandler(this.RadioButtonActive_CheckedChanged);
            // 
            // LInnerNumber
            // 
            this.LInnerNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.LInnerNumber.AutoSize = true;
            this.LInnerNumber.Location = new System.Drawing.Point(12, 644);
            this.LInnerNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.LInnerNumber.Name = "LInnerNumber";
            this.LInnerNumber.Size = new System.Drawing.Size(115, 16);
            this.LInnerNumber.TabIndex = 8;
            this.LInnerNumber.Text = "Внутренний номер";
            // 
            // tbInnerNumber
            // 
            this.tbInnerNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbInnerNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingItem, "InnerId", true));
            this.tbInnerNumber.Location = new System.Drawing.Point(14, 663);
            this.tbInnerNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbInnerNumber.Name = "tbInnerNumber";
            this.tbInnerNumber.Size = new System.Drawing.Size(114, 23);
            this.tbInnerNumber.TabIndex = 9;
            this.tbInnerNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbInnerNumber_KeyPress);
            // 
            // bindingItem
            // 
            this.bindingItem.DataSource = typeof(ModelEntities.ModelViewHaspKey);
            // 
            // tbNumber
            // 
            this.tbNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbNumber.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingItem, "Number", true));
            this.tbNumber.Location = new System.Drawing.Point(133, 663);
            this.tbNumber.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbNumber.Name = "tbNumber";
            this.tbNumber.Size = new System.Drawing.Size(116, 23);
            this.tbNumber.TabIndex = 10;
            // 
            // labelNumber
            // 
            this.labelNumber.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelNumber.AutoSize = true;
            this.labelNumber.Location = new System.Drawing.Point(131, 644);
            this.labelNumber.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelNumber.Name = "labelNumber";
            this.labelNumber.Size = new System.Drawing.Size(44, 16);
            this.labelNumber.TabIndex = 11;
            this.labelNumber.Text = "Номер";
            // 
            // labelType
            // 
            this.labelType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelType.AutoSize = true;
            this.labelType.Location = new System.Drawing.Point(251, 644);
            this.labelType.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(70, 16);
            this.labelType.TabIndex = 12;
            this.labelType.Text = "Тип ключа";
            // 
            // comboBoxTypeKey
            // 
            this.comboBoxTypeKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.comboBoxTypeKey.BackColor = System.Drawing.SystemColors.Window;
            this.comboBoxTypeKey.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingItem, "TypeKey", true));
            this.comboBoxTypeKey.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTypeKey.FormattingEnabled = true;
            this.comboBoxTypeKey.Location = new System.Drawing.Point(254, 663);
            this.comboBoxTypeKey.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.comboBoxTypeKey.Name = "comboBoxTypeKey";
            this.comboBoxTypeKey.Size = new System.Drawing.Size(140, 24);
            this.comboBoxTypeKey.TabIndex = 13;
            // 
            // checkBoxIsHome
            // 
            this.checkBoxIsHome.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkBoxIsHome.AutoSize = true;
            this.checkBoxIsHome.DataBindings.Add(new System.Windows.Forms.Binding("CheckState", this.bindingItem, "IsHome", true));
            this.checkBoxIsHome.Location = new System.Drawing.Point(402, 667);
            this.checkBoxIsHome.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.checkBoxIsHome.Name = "checkBoxIsHome";
            this.checkBoxIsHome.Size = new System.Drawing.Size(96, 20);
            this.checkBoxIsHome.TabIndex = 14;
            this.checkBoxIsHome.Text = "В компании";
            this.checkBoxIsHome.UseVisualStyleBackColor = true;
            // 
            // buttonSearchByClient
            // 
            this.buttonSearchByClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearchByClient.Location = new System.Drawing.Point(380, 11);
            this.buttonSearchByClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSearchByClient.Name = "buttonSearchByClient";
            this.buttonSearchByClient.Size = new System.Drawing.Size(127, 28);
            this.buttonSearchByClient.TabIndex = 15;
            this.buttonSearchByClient.Text = "Поиск по клиенту";
            this.buttonSearchByClient.UseVisualStyleBackColor = true;
            this.buttonSearchByClient.Click += new System.EventHandler(this.ButtonSearchByClient_Click);
            // 
            // labelClient
            // 
            this.labelClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelClient.AutoSize = true;
            this.labelClient.BackColor = System.Drawing.Color.Transparent;
            this.labelClient.Location = new System.Drawing.Point(506, 38);
            this.labelClient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelClient.Name = "labelClient";
            this.labelClient.Size = new System.Drawing.Size(39, 16);
            this.labelClient.TabIndex = 16;
            this.labelClient.Text = "Client";
            this.labelClient.TextAlign = System.Drawing.ContentAlignment.TopRight;
            // 
            // Headline
            // 
            this.Headline.AutoSize = true;
            this.Headline.Location = new System.Drawing.Point(14, 52);
            this.Headline.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Headline.Name = "Headline";
            this.Headline.Size = new System.Drawing.Size(132, 16);
            this.Headline.TabIndex = 17;
            this.Headline.Text = "Список HASP-ключей";
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "InnerId";
            this.dataGridViewTextBoxColumn1.FillWeight = 83.75635F;
            this.dataGridViewTextBoxColumn1.HeaderText = "Внутренний номер";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ToolTipText = "Внутренний номер ключа";
            this.dataGridViewTextBoxColumn1.Width = 99;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Number";
            this.dataGridViewTextBoxColumn2.FillWeight = 83.75635F;
            this.dataGridViewTextBoxColumn2.HeaderText = "Номер";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ToolTipText = "Номер ключа";
            this.dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "TypeKey";
            this.dataGridViewTextBoxColumn3.FillWeight = 83.75635F;
            this.dataGridViewTextBoxColumn3.HeaderText = "Тип ключа";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ToolTipText = "Тиа ключа";
            this.dataGridViewTextBoxColumn3.Width = 99;
            // 
            // HaspKeyView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(519, 729);
            this.Controls.Add(this.Headline);
            this.Controls.Add(this.buttonSearchByClient);
            this.Controls.Add(this.DataGridViewHaspKey);
            this.Controls.Add(this.checkBoxIsHome);
            this.Controls.Add(this.comboBoxTypeKey);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.labelNumber);
            this.Controls.Add(this.tbNumber);
            this.Controls.Add(this.tbInnerNumber);
            this.Controls.Add(this.LInnerNumber);
            this.Controls.Add(this.panelFiltr);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.labelClient);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("HaspKeyView.IconOptions.Icon")));
            this.IconOptions.ShowIcon = false;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(447, 624);
            this.Name = "HaspKeyView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hasp-ключ";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewHaspKey)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingHaspKey)).EndInit();
            this.panelFiltr.ResumeLayout(false);
            this.panelFiltr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewHaspKey;
        private System.Windows.Forms.BindingSource bindingHaspKey;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Panel panelFiltr;
        private System.Windows.Forms.RadioButton radioButtonPastDue;
        private System.Windows.Forms.RadioButton radioButtonAll;
        private System.Windows.Forms.RadioButton radioButtonActive;        
        private System.Windows.Forms.Label LInnerNumber;
        private System.Windows.Forms.TextBox tbInnerNumber;
        private System.Windows.Forms.TextBox tbNumber;
        private System.Windows.Forms.Label labelNumber;
        private System.Windows.Forms.Label labelType;
        private System.Windows.Forms.ComboBox comboBoxTypeKey;
        private System.Windows.Forms.CheckBox checkBoxIsHome;
        private System.Windows.Forms.Button buttonSearchByClient;
        private System.Windows.Forms.Label labelClient;
        private System.Windows.Forms.Label Headline;
        private System.Windows.Forms.BindingSource bindingItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn innerIdDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn isHomeDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
    }
}