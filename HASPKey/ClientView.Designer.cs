namespace HASPKey
{
    partial class ClientView
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
            presenterClient.Dispose();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ClientView));
            this.DataGridViewClient = new System.Windows.Forms.DataGridView();
            this.bindingClient = new System.Windows.Forms.BindingSource(this.components);
            this.labelName = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelContactPerson = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.bindingItem = new System.Windows.Forms.BindingSource(this.components);
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.tbContactPerson = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonSearchByFeature = new System.Windows.Forms.Button();
            this.labelFeature = new System.Windows.Forms.Label();
            this.labelSearchInnerId = new System.Windows.Forms.Label();
            this.tbInnerIdHaspKey = new System.Windows.Forms.TextBox();
            this.Headline = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.buttonAll = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Address = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Phone = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ContactPerson = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingItem)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewClient
            // 
            this.DataGridViewClient.AllowUserToAddRows = false;
            this.DataGridViewClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewClient.AutoGenerateColumns = false;
            this.DataGridViewClient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewClient.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGridViewClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewClient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.Address,
            this.Phone,
            this.ContactPerson});
            this.DataGridViewClient.DataSource = this.bindingClient;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewClient.DefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewClient.Location = new System.Drawing.Point(14, 71);
            this.DataGridViewClient.Margin = new System.Windows.Forms.Padding(4);
            this.DataGridViewClient.Name = "DataGridViewClient";
            this.DataGridViewClient.ReadOnly = true;
            this.DataGridViewClient.RowHeadersVisible = false;
            this.DataGridViewClient.RowHeadersWidth = 51;
            this.DataGridViewClient.Size = new System.Drawing.Size(679, 549);
            this.DataGridViewClient.TabIndex = 0;
            this.DataGridViewClient.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewClient_CellClick);
            this.DataGridViewClient.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewClient_CellDoubleClick);
            this.DataGridViewClient.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridViewClient_DataBindingComplete);
            this.DataGridViewClient.SelectionChanged += new System.EventHandler(this.DataGridViewClient_SelectionChanged);
            this.DataGridViewClient.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DataGridViewClient_KeyDown);
            // 
            // bindingClient
            // 
            this.bindingClient.DataSource = typeof(ModelEntities.ModelViewClient);
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(12, 624);
            this.labelName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(93, 16);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Наименование";
            // 
            // labelAddress
            // 
            this.labelAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(204, 624);
            this.labelAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(42, 16);
            this.labelAddress.TabIndex = 2;
            this.labelAddress.Text = "Адрес";
            // 
            // labelPhone
            // 
            this.labelPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(388, 624);
            this.labelPhone.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(60, 16);
            this.labelPhone.TabIndex = 3;
            this.labelPhone.Text = "Телефон";
            // 
            // labelContactPerson
            // 
            this.labelContactPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelContactPerson.AutoSize = true;
            this.labelContactPerson.Location = new System.Drawing.Point(540, 624);
            this.labelContactPerson.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelContactPerson.Name = "labelContactPerson";
            this.labelContactPerson.Size = new System.Drawing.Size(106, 16);
            this.labelContactPerson.TabIndex = 4;
            this.labelContactPerson.Text = "Контактное лицо";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbName.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingItem, "Name", true));
            this.tbName.Location = new System.Drawing.Point(15, 644);
            this.tbName.Margin = new System.Windows.Forms.Padding(4);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(185, 23);
            this.tbName.TabIndex = 5;
            // 
            // bindingItem
            // 
            this.bindingItem.DataSource = typeof(ModelEntities.ModelViewClient);
            // 
            // tbAddress
            // 
            this.tbAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbAddress.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingItem, "Address", true));
            this.tbAddress.Location = new System.Drawing.Point(208, 644);
            this.tbAddress.Margin = new System.Windows.Forms.Padding(4);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(173, 23);
            this.tbAddress.TabIndex = 6;
            // 
            // tbPhone
            // 
            this.tbPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbPhone.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingItem, "Phone", true));
            this.tbPhone.Location = new System.Drawing.Point(388, 644);
            this.tbPhone.Margin = new System.Windows.Forms.Padding(4);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(138, 23);
            this.tbPhone.TabIndex = 7;
            // 
            // tbContactPerson
            // 
            this.tbContactPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbContactPerson.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingItem, "ContactPerson", true));
            this.tbContactPerson.Location = new System.Drawing.Point(534, 644);
            this.tbContactPerson.Margin = new System.Windows.Forms.Padding(4);
            this.tbContactPerson.Name = "tbContactPerson";
            this.tbContactPerson.Size = new System.Drawing.Size(158, 23);
            this.tbContactPerson.TabIndex = 8;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(15, 677);
            this.buttonAdd.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(88, 28);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(606, 677);
            this.buttonDelete.Margin = new System.Windows.Forms.Padding(4);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(88, 28);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Location = new System.Drawing.Point(113, 677);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(88, 28);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonSearchByFeature
            // 
            this.buttonSearchByFeature.Location = new System.Drawing.Point(15, 16);
            this.buttonSearchByFeature.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSearchByFeature.Name = "buttonSearchByFeature";
            this.buttonSearchByFeature.Size = new System.Drawing.Size(112, 28);
            this.buttonSearchByFeature.TabIndex = 12;
            this.buttonSearchByFeature.Text = "Поиск по фиче";
            this.buttonSearchByFeature.UseVisualStyleBackColor = true;
            this.buttonSearchByFeature.Click += new System.EventHandler(this.ButtonSearchByFeature_Click);
            // 
            // labelFeature
            // 
            this.labelFeature.AutoSize = true;
            this.labelFeature.Location = new System.Drawing.Point(134, 22);
            this.labelFeature.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelFeature.Name = "labelFeature";
            this.labelFeature.Size = new System.Drawing.Size(78, 16);
            this.labelFeature.TabIndex = 13;
            this.labelFeature.Text = "labelFeature";
            // 
            // labelSearchInnerId
            // 
            this.labelSearchInnerId.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelSearchInnerId.AutoSize = true;
            this.labelSearchInnerId.Location = new System.Drawing.Point(328, 0);
            this.labelSearchInnerId.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelSearchInnerId.Name = "labelSearchInnerId";
            this.labelSearchInnerId.Size = new System.Drawing.Size(225, 16);
            this.labelSearchInnerId.TabIndex = 15;
            this.labelSearchInnerId.Text = "Поиск по внутреннему номеру ключа";
            // 
            // tbInnerIdHaspKey
            // 
            this.tbInnerIdHaspKey.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.tbInnerIdHaspKey.Location = new System.Drawing.Point(331, 18);
            this.tbInnerIdHaspKey.Margin = new System.Windows.Forms.Padding(4);
            this.tbInnerIdHaspKey.Name = "tbInnerIdHaspKey";
            this.tbInnerIdHaspKey.Size = new System.Drawing.Size(116, 23);
            this.tbInnerIdHaspKey.TabIndex = 16;
            this.toolTip.SetToolTip(this.tbInnerIdHaspKey, "Введите внутренний номер ключа и нажмите \"Enter\".");
            this.tbInnerIdHaspKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbInnerIdHaspKey_KeyDown);
            this.tbInnerIdHaspKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbInnerIdHaspKey_KeyPress);
            // 
            // Headline
            // 
            this.Headline.AutoSize = true;
            this.Headline.Location = new System.Drawing.Point(18, 52);
            this.Headline.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Headline.Name = "Headline";
            this.Headline.Size = new System.Drawing.Size(106, 16);
            this.Headline.TabIndex = 17;
            this.Headline.Text = "Список клиентов";
            // 
            // buttonAll
            // 
            this.buttonAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAll.Location = new System.Drawing.Point(604, 16);
            this.buttonAll.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(88, 28);
            this.buttonAll.TabIndex = 14;
            this.buttonAll.Text = "Все";
            this.toolTip.SetToolTip(this.buttonAll, "Список всех клиентов.");
            this.buttonAll.UseVisualStyleBackColor = true;
            this.buttonAll.Click += new System.EventHandler(this.ButtonAll_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn1.DataPropertyName = "SerialNumber";
            this.dataGridViewTextBoxColumn1.HeaderText = "№ п/п";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.ToolTipText = "Наименование организации";
            this.dataGridViewTextBoxColumn1.Width = 65;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn2.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.Width = 119;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Address";
            this.dataGridViewTextBoxColumn3.HeaderText = "Адрес";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.Width = 118;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "Phone";
            this.dataGridViewTextBoxColumn4.HeaderText = "Телефон";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.Width = 119;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "ContactPerson";
            this.dataGridViewTextBoxColumn5.HeaderText = "Контактное лицо";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.Width = 118;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCancel.Location = new System.Drawing.Point(209, 677);
            this.buttonCancel.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(88, 28);
            this.buttonCancel.TabIndex = 18;
            this.buttonCancel.Text = "Отменить";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn.ToolTipText = "Наименование организации";
            // 
            // Address
            // 
            this.Address.DataPropertyName = "Address";
            this.Address.HeaderText = "Адрес";
            this.Address.MinimumWidth = 6;
            this.Address.Name = "Address";
            this.Address.ReadOnly = true;
            // 
            // Phone
            // 
            this.Phone.DataPropertyName = "Phone";
            this.Phone.HeaderText = "Телефон";
            this.Phone.MinimumWidth = 6;
            this.Phone.Name = "Phone";
            this.Phone.ReadOnly = true;
            // 
            // ContactPerson
            // 
            this.ContactPerson.DataPropertyName = "ContactPerson";
            this.ContactPerson.HeaderText = "Представитель";
            this.ContactPerson.MinimumWidth = 6;
            this.ContactPerson.Name = "ContactPerson";
            this.ContactPerson.ReadOnly = true;
            // 
            // ClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(706, 711);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.Headline);
            this.Controls.Add(this.tbInnerIdHaspKey);
            this.Controls.Add(this.labelSearchInnerId);
            this.Controls.Add(this.buttonAll);
            this.Controls.Add(this.buttonSearchByFeature);
            this.Controls.Add(this.DataGridViewClient);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonAdd);
            this.Controls.Add(this.tbContactPerson);
            this.Controls.Add(this.tbPhone);
            this.Controls.Add(this.tbAddress);
            this.Controls.Add(this.tbName);
            this.Controls.Add(this.labelContactPerson);
            this.Controls.Add(this.labelPhone);
            this.Controls.Add(this.labelAddress);
            this.Controls.Add(this.labelName);
            this.Controls.Add(this.labelFeature);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("ClientView.IconOptions.Icon")));
            this.IconOptions.ShowIcon = false;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(607, 610);
            this.Name = "ClientView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Клиенты";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingItem)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewClient;
        private System.Windows.Forms.BindingSource bindingClient;
        private System.Windows.Forms.Label labelName;
        private System.Windows.Forms.Label labelAddress;
        private System.Windows.Forms.Label labelPhone;
        private System.Windows.Forms.Label labelContactPerson;
        private System.Windows.Forms.TextBox tbName;
        private System.Windows.Forms.TextBox tbAddress;
        private System.Windows.Forms.TextBox tbPhone;
        private System.Windows.Forms.TextBox tbContactPerson;
        private System.Windows.Forms.Button buttonAdd;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Button buttonSearchByFeature;
        private System.Windows.Forms.Label labelFeature;
        private System.Windows.Forms.Label labelSearchInnerId;
        private System.Windows.Forms.TextBox tbInnerIdHaspKey;
        private System.Windows.Forms.Label Headline;
        private System.Windows.Forms.BindingSource bindingItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button buttonAll;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn Address;
        private System.Windows.Forms.DataGridViewTextBoxColumn Phone;
        private System.Windows.Forms.DataGridViewTextBoxColumn ContactPerson;
    }
}