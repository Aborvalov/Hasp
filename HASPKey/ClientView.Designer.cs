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
            this.dgvClient = new System.Windows.Forms.DataGridView();
            this.labelName = new System.Windows.Forms.Label();
            this.labelAddress = new System.Windows.Forms.Label();
            this.labelPhone = new System.Windows.Forms.Label();
            this.labelContactPerson = new System.Windows.Forms.Label();
            this.tbName = new System.Windows.Forms.TextBox();
            this.tbAddress = new System.Windows.Forms.TextBox();
            this.tbPhone = new System.Windows.Forms.TextBox();
            this.tbContactPerson = new System.Windows.Forms.TextBox();
            this.buttonAdd = new System.Windows.Forms.Button();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.buttonSearchByFeature = new System.Windows.Forms.Button();
            this.labelFeature = new System.Windows.Forms.Label();
            this.buttonAll = new System.Windows.Forms.Button();
            this.labelSearchInnerId = new System.Windows.Forms.Label();
            this.tbInnerIdHaspKey = new System.Windows.Forms.TextBox();
            this.serialNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactPersonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingClient = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingClient)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvClient
            // 
            this.dgvClient.AllowUserToAddRows = false;
            this.dgvClient.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvClient.AutoGenerateColumns = false;
            this.dgvClient.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvClient.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvClient.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvClient.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.serialNumberDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.addressDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn,
            this.contactPersonDataGridViewTextBoxColumn});
            this.dgvClient.DataSource = this.bindingClient;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvClient.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvClient.Location = new System.Drawing.Point(12, 47);
            this.dgvClient.Name = "dgvClient";
            this.dgvClient.ReadOnly = true;
            this.dgvClient.RowHeadersVisible = false;
            this.dgvClient.Size = new System.Drawing.Size(582, 457);
            this.dgvClient.TabIndex = 0;
            this.dgvClient.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DgvClient_CellDoubleClick);
            // 
            // labelName
            // 
            this.labelName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelName.AutoSize = true;
            this.labelName.Location = new System.Drawing.Point(10, 507);
            this.labelName.Name = "labelName";
            this.labelName.Size = new System.Drawing.Size(80, 13);
            this.labelName.TabIndex = 1;
            this.labelName.Text = "Наименование";
            // 
            // labelAddress
            // 
            this.labelAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelAddress.AutoSize = true;
            this.labelAddress.Location = new System.Drawing.Point(175, 507);
            this.labelAddress.Name = "labelAddress";
            this.labelAddress.Size = new System.Drawing.Size(38, 13);
            this.labelAddress.TabIndex = 2;
            this.labelAddress.Text = "Адрес";
            // 
            // labelPhone
            // 
            this.labelPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelPhone.AutoSize = true;
            this.labelPhone.Location = new System.Drawing.Point(333, 507);
            this.labelPhone.Name = "labelPhone";
            this.labelPhone.Size = new System.Drawing.Size(51, 13);
            this.labelPhone.TabIndex = 3;
            this.labelPhone.Text = "Телефон";
            // 
            // labelContactPerson
            // 
            this.labelContactPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.labelContactPerson.AutoSize = true;
            this.labelContactPerson.Location = new System.Drawing.Point(463, 507);
            this.labelContactPerson.Name = "labelContactPerson";
            this.labelContactPerson.Size = new System.Drawing.Size(95, 13);
            this.labelContactPerson.TabIndex = 4;
            this.labelContactPerson.Text = "Контактное лицо";
            // 
            // tbName
            // 
            this.tbName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbName.Location = new System.Drawing.Point(13, 523);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(159, 21);
            this.tbName.TabIndex = 5;
            // 
            // tbAddress
            // 
            this.tbAddress.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbAddress.Location = new System.Drawing.Point(178, 523);
            this.tbAddress.Name = "tbAddress";
            this.tbAddress.Size = new System.Drawing.Size(149, 21);
            this.tbAddress.TabIndex = 6;
            // 
            // tbPhone
            // 
            this.tbPhone.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbPhone.Location = new System.Drawing.Point(333, 523);
            this.tbPhone.Name = "tbPhone";
            this.tbPhone.Size = new System.Drawing.Size(119, 21);
            this.tbPhone.TabIndex = 7;
            // 
            // tbContactPerson
            // 
            this.tbContactPerson.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tbContactPerson.Location = new System.Drawing.Point(458, 523);
            this.tbContactPerson.Name = "tbContactPerson";
            this.tbContactPerson.Size = new System.Drawing.Size(136, 21);
            this.tbContactPerson.TabIndex = 8;
            // 
            // buttonAdd
            // 
            this.buttonAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonAdd.Location = new System.Drawing.Point(12, 550);
            this.buttonAdd.Name = "buttonAdd";
            this.buttonAdd.Size = new System.Drawing.Size(75, 23);
            this.buttonAdd.TabIndex = 9;
            this.buttonAdd.Text = "Добавить";
            this.buttonAdd.UseVisualStyleBackColor = true;
            this.buttonAdd.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // buttonDelete
            // 
            this.buttonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonDelete.Location = new System.Drawing.Point(518, 550);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(75, 23);
            this.buttonDelete.TabIndex = 10;
            this.buttonDelete.Text = "Удалить";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.ButtonDelete_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSave.Location = new System.Drawing.Point(97, 550);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 11;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // buttonSearchByFeature
            // 
            this.buttonSearchByFeature.Location = new System.Drawing.Point(13, 18);
            this.buttonSearchByFeature.Name = "buttonSearchByFeature";
            this.buttonSearchByFeature.Size = new System.Drawing.Size(96, 23);
            this.buttonSearchByFeature.TabIndex = 12;
            this.buttonSearchByFeature.Text = "Поиск по фиче";
            this.buttonSearchByFeature.UseVisualStyleBackColor = true;
            this.buttonSearchByFeature.Click += new System.EventHandler(this.ButtonSearchByFeature_Click);
            // 
            // labelFeature
            // 
            this.labelFeature.AutoSize = true;
            this.labelFeature.Location = new System.Drawing.Point(9, 0);
            this.labelFeature.Name = "labelFeature";
            this.labelFeature.Size = new System.Drawing.Size(67, 13);
            this.labelFeature.TabIndex = 13;
            this.labelFeature.Text = "labelFeature";
            // 
            // buttonAll
            // 
            this.buttonAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAll.Location = new System.Drawing.Point(518, 18);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(75, 23);
            this.buttonAll.TabIndex = 14;
            this.buttonAll.Text = "Все";
            this.buttonAll.UseVisualStyleBackColor = true;
            this.buttonAll.Click += new System.EventHandler(this.ButtonAll_Click);
            // 
            // labelSearchInnerId
            // 
            this.labelSearchInnerId.AutoSize = true;
            this.labelSearchInnerId.Location = new System.Drawing.Point(151, -1);
            this.labelSearchInnerId.Name = "labelSearchInnerId";
            this.labelSearchInnerId.Size = new System.Drawing.Size(196, 13);
            this.labelSearchInnerId.TabIndex = 15;
            this.labelSearchInnerId.Text = "Поиск по внутреннему номеру ключа";
            // 
            // tbInnerIdHaspKey
            // 
            this.tbInnerIdHaspKey.Location = new System.Drawing.Point(154, 19);
            this.tbInnerIdHaspKey.Name = "tbInnerIdHaspKey";
            this.tbInnerIdHaspKey.Size = new System.Drawing.Size(100, 21);
            this.tbInnerIdHaspKey.TabIndex = 16;
            this.tbInnerIdHaspKey.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TbInnerIdHaspKey_KeyDown);
            this.tbInnerIdHaspKey.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TbInnerIdHaspKey_KeyPress);
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
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Наименование";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Адрес";
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "Телефон";
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            this.phoneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // contactPersonDataGridViewTextBoxColumn
            // 
            this.contactPersonDataGridViewTextBoxColumn.DataPropertyName = "ContactPerson";
            this.contactPersonDataGridViewTextBoxColumn.HeaderText = "Контактное лицо";
            this.contactPersonDataGridViewTextBoxColumn.Name = "contactPersonDataGridViewTextBoxColumn";
            this.contactPersonDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bindingClient
            // 
            this.bindingClient.DataSource = typeof(ModelEntities.ModelViewClient);
            // 
            // ClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 578);
            this.Controls.Add(this.tbInnerIdHaspKey);
            this.Controls.Add(this.labelSearchInnerId);
            this.Controls.Add(this.buttonAll);
            this.Controls.Add(this.labelFeature);
            this.Controls.Add(this.buttonSearchByFeature);
            this.Controls.Add(this.dgvClient);
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
            this.Name = "ClientView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "ClientView";
            ((System.ComponentModel.ISupportInitialize)(this.dgvClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvClient;
        private System.Windows.Forms.BindingSource bindingClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn serialNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactPersonDataGridViewTextBoxColumn;
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
        private System.Windows.Forms.Button buttonAll;
        private System.Windows.Forms.Label labelSearchInnerId;
        private System.Windows.Forms.TextBox tbInnerIdHaspKey;
    }
}