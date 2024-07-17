﻿namespace HASPKey
{
    partial class KeyFeatureClientView
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.DataGridViewClient = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.addressDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phoneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.contactPersonDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingClient = new System.Windows.Forms.BindingSource(this.components);
            this.DataGridViewKeyFeature = new System.Windows.Forms.DataGridView();
            this.selectedDataGridViewCheckBoxColumn = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.numberKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.typeKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.featureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.initiatorDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.noteDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingKeyFeatureClient = new System.Windows.Forms.BindingSource(this.components);
            this.HeaderlineClient = new System.Windows.Forms.Label();
            this.HeaderlineKey = new System.Windows.Forms.Label();
            this.buttonSave = new System.Windows.Forms.Button();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingClient)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewKeyFeature)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingKeyFeatureClient)).BeginInit();
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
            this.nameDataGridViewTextBoxColumn1,
            this.addressDataGridViewTextBoxColumn,
            this.phoneDataGridViewTextBoxColumn,
            this.contactPersonDataGridViewTextBoxColumn});
            this.DataGridViewClient.DataSource = this.bindingClient;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewClient.DefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewClient.Location = new System.Drawing.Point(14, 21);
            this.DataGridViewClient.Margin = new System.Windows.Forms.Padding(4);
            this.DataGridViewClient.Name = "DataGridViewClient";
            this.DataGridViewClient.ReadOnly = true;
            this.DataGridViewClient.RowHeadersVisible = false;
            this.DataGridViewClient.RowHeadersWidth = 51;
            this.DataGridViewClient.Size = new System.Drawing.Size(791, 414);
            this.DataGridViewClient.TabIndex = 0;
            this.DataGridViewClient.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewClient_CellClick);
            this.DataGridViewClient.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridViewClient_DataBindingComplete);
            this.DataGridViewClient.SelectionChanged += new System.EventHandler(this.DataGridViewClient_SelectionChanged);
            // 
            // nameDataGridViewTextBoxColumn1
            // 
            this.nameDataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn1.HeaderText = "Наименование";
            this.nameDataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.nameDataGridViewTextBoxColumn1.Name = "nameDataGridViewTextBoxColumn1";
            this.nameDataGridViewTextBoxColumn1.ReadOnly = true;
            this.nameDataGridViewTextBoxColumn1.ToolTipText = "Наименование клиента";
            // 
            // addressDataGridViewTextBoxColumn
            // 
            this.addressDataGridViewTextBoxColumn.DataPropertyName = "Address";
            this.addressDataGridViewTextBoxColumn.HeaderText = "Адрес";
            this.addressDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.addressDataGridViewTextBoxColumn.Name = "addressDataGridViewTextBoxColumn";
            this.addressDataGridViewTextBoxColumn.ReadOnly = true;
            this.addressDataGridViewTextBoxColumn.ToolTipText = "Адрес клиента";
            // 
            // phoneDataGridViewTextBoxColumn
            // 
            this.phoneDataGridViewTextBoxColumn.DataPropertyName = "Phone";
            this.phoneDataGridViewTextBoxColumn.HeaderText = "Телефон";
            this.phoneDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.phoneDataGridViewTextBoxColumn.Name = "phoneDataGridViewTextBoxColumn";
            this.phoneDataGridViewTextBoxColumn.ReadOnly = true;
            this.phoneDataGridViewTextBoxColumn.ToolTipText = "Контактный телефон клиента";
            // 
            // contactPersonDataGridViewTextBoxColumn
            // 
            this.contactPersonDataGridViewTextBoxColumn.DataPropertyName = "ContactPerson";
            this.contactPersonDataGridViewTextBoxColumn.HeaderText = "Контактное лицо";
            this.contactPersonDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.contactPersonDataGridViewTextBoxColumn.Name = "contactPersonDataGridViewTextBoxColumn";
            this.contactPersonDataGridViewTextBoxColumn.ReadOnly = true;
            this.contactPersonDataGridViewTextBoxColumn.ToolTipText = "Контактное лицо";
            // 
            // bindingClient
            // 
            this.bindingClient.DataSource = typeof(ModelEntities.ModelViewClient);
            // 
            // DataGridViewKeyFeature
            // 
            this.DataGridViewKeyFeature.AllowUserToAddRows = false;
            this.DataGridViewKeyFeature.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewKeyFeature.AutoGenerateColumns = false;
            this.DataGridViewKeyFeature.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewKeyFeature.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGridViewKeyFeature.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewKeyFeature.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.selectedDataGridViewCheckBoxColumn,
            this.numberKeyDataGridViewTextBoxColumn,
            this.typeKeyDataGridViewTextBoxColumn,
            this.featureDataGridViewTextBoxColumn,
            this.endDateDataGridViewTextBoxColumn,
            this.initiatorDataGridViewTextBoxColumn,
            this.noteDataGridViewTextBoxColumn});
            this.DataGridViewKeyFeature.DataSource = this.bindingKeyFeatureClient;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewKeyFeature.DefaultCellStyle = dataGridViewCellStyle2;
            this.DataGridViewKeyFeature.Location = new System.Drawing.Point(14, 458);
            this.DataGridViewKeyFeature.Margin = new System.Windows.Forms.Padding(4);
            this.DataGridViewKeyFeature.Name = "DataGridViewKeyFeature";
            this.DataGridViewKeyFeature.RowHeadersVisible = false;
            this.DataGridViewKeyFeature.RowHeadersWidth = 51;
            this.DataGridViewKeyFeature.Size = new System.Drawing.Size(791, 260);
            this.DataGridViewKeyFeature.TabIndex = 1;
            this.DataGridViewKeyFeature.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.DataGridViewKeyFeature_CellEndEdit);
            this.DataGridViewKeyFeature.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridViewKeyFeature_DataBindingComplete);
            // 
            // selectedDataGridViewCheckBoxColumn
            // 
            this.selectedDataGridViewCheckBoxColumn.DataPropertyName = "Selected";
            this.selectedDataGridViewCheckBoxColumn.HeaderText = "У клиента";
            this.selectedDataGridViewCheckBoxColumn.MinimumWidth = 6;
            this.selectedDataGridViewCheckBoxColumn.Name = "selectedDataGridViewCheckBoxColumn";
            // 
            // numberKeyDataGridViewTextBoxColumn
            // 
            this.numberKeyDataGridViewTextBoxColumn.DataPropertyName = "NumberKey";
            this.numberKeyDataGridViewTextBoxColumn.HeaderText = "Номер ключа";
            this.numberKeyDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.numberKeyDataGridViewTextBoxColumn.Name = "numberKeyDataGridViewTextBoxColumn";
            this.numberKeyDataGridViewTextBoxColumn.ReadOnly = true;
            this.numberKeyDataGridViewTextBoxColumn.ToolTipText = "Номер ключа (нутренный номер + номер на ключе)";
            // 
            // typeKeyDataGridViewTextBoxColumn
            // 
            this.typeKeyDataGridViewTextBoxColumn.DataPropertyName = "TypeKey";
            this.typeKeyDataGridViewTextBoxColumn.HeaderText = "Тип ключа";
            this.typeKeyDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.typeKeyDataGridViewTextBoxColumn.Name = "typeKeyDataGridViewTextBoxColumn";
            this.typeKeyDataGridViewTextBoxColumn.ReadOnly = true;
            this.typeKeyDataGridViewTextBoxColumn.ToolTipText = "Тип ключа";
            // 
            // featureDataGridViewTextBoxColumn
            // 
            this.featureDataGridViewTextBoxColumn.DataPropertyName = "Feature";
            this.featureDataGridViewTextBoxColumn.HeaderText = "Функциональность";
            this.featureDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.featureDataGridViewTextBoxColumn.Name = "featureDataGridViewTextBoxColumn";
            this.featureDataGridViewTextBoxColumn.ToolTipText = "Функциональность на ключе";
            // 
            // endDateDataGridViewTextBoxColumn
            // 
            this.endDateDataGridViewTextBoxColumn.DataPropertyName = "EndDate";
            this.endDateDataGridViewTextBoxColumn.HeaderText = "Окончание действия";
            this.endDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.endDateDataGridViewTextBoxColumn.Name = "endDateDataGridViewTextBoxColumn";
            this.endDateDataGridViewTextBoxColumn.ToolTipText = "Окончание действия функциональности на ключе";
            // 
            // initiatorDataGridViewTextBoxColumn
            // 
            this.initiatorDataGridViewTextBoxColumn.DataPropertyName = "Initiator";
            this.initiatorDataGridViewTextBoxColumn.HeaderText = "Инициатор";
            this.initiatorDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.initiatorDataGridViewTextBoxColumn.Name = "initiatorDataGridViewTextBoxColumn";
            this.initiatorDataGridViewTextBoxColumn.ToolTipText = "Инициатор предоставить ключ с данной функциональностью клиенту";
            // 
            // noteDataGridViewTextBoxColumn
            // 
            this.noteDataGridViewTextBoxColumn.DataPropertyName = "Note";
            this.noteDataGridViewTextBoxColumn.HeaderText = "Прочие";
            this.noteDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.noteDataGridViewTextBoxColumn.Name = "noteDataGridViewTextBoxColumn";
            this.noteDataGridViewTextBoxColumn.ToolTipText = "Дополнительная информация";
            // 
            // bindingKeyFeatureClient
            // 
            this.bindingKeyFeatureClient.DataSource = typeof(ModelEntities.ModelViewKeyFeatureClient);
            // 
            // HeaderlineClient
            // 
            this.HeaderlineClient.AutoSize = true;
            this.HeaderlineClient.Location = new System.Drawing.Point(14, 1);
            this.HeaderlineClient.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HeaderlineClient.Name = "HeaderlineClient";
            this.HeaderlineClient.Size = new System.Drawing.Size(106, 16);
            this.HeaderlineClient.TabIndex = 2;
            this.HeaderlineClient.Text = "Список клиентов";
            // 
            // HeaderlineKey
            // 
            this.HeaderlineKey.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.HeaderlineKey.AutoSize = true;
            this.HeaderlineKey.Location = new System.Drawing.Point(10, 438);
            this.HeaderlineKey.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.HeaderlineKey.Name = "HeaderlineKey";
            this.HeaderlineKey.Size = new System.Drawing.Size(264, 16);
            this.HeaderlineKey.TabIndex = 3;
            this.HeaderlineKey.Text = "Список ключей доступных данному клиенту";
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonSave.Location = new System.Drawing.Point(109, 726);
            this.buttonSave.Margin = new System.Windows.Forms.Padding(4);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(88, 28);
            this.buttonSave.TabIndex = 4;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.ButtonSave_Click);
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn1.HeaderText = "Наименование";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.ToolTipText = "Наименование клиента";
            this.dataGridViewTextBoxColumn1.Width = 158;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Address";
            this.dataGridViewTextBoxColumn2.HeaderText = "Адрес";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            this.dataGridViewTextBoxColumn2.ToolTipText = "Адрес клиента";
            this.dataGridViewTextBoxColumn2.Width = 159;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Phone";
            this.dataGridViewTextBoxColumn3.HeaderText = "Телефон";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            this.dataGridViewTextBoxColumn3.ToolTipText = "Контактный телефон клиента";
            this.dataGridViewTextBoxColumn3.Width = 158;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.DataPropertyName = "ContactPerson";
            this.dataGridViewTextBoxColumn4.HeaderText = "Контактное лицо";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ReadOnly = true;
            this.dataGridViewTextBoxColumn4.ToolTipText = "Контактное лицо";
            this.dataGridViewTextBoxColumn4.Width = 158;
            // 
            // dataGridViewTextBoxColumn5
            // 
            this.dataGridViewTextBoxColumn5.DataPropertyName = "Name";
            this.dataGridViewTextBoxColumn5.HeaderText = "Name";
            this.dataGridViewTextBoxColumn5.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            this.dataGridViewTextBoxColumn5.ReadOnly = true;
            this.dataGridViewTextBoxColumn5.ToolTipText = "Номер ключа (нутренный номер + номер на ключе)";
            this.dataGridViewTextBoxColumn5.Width = 159;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.DataPropertyName = "TypeName";
            this.dataGridViewTextBoxColumn6.HeaderText = "TypeName";
            this.dataGridViewTextBoxColumn6.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            this.dataGridViewTextBoxColumn6.ToolTipText = "Тип ключа";
            this.dataGridViewTextBoxColumn6.Width = 158;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.DataPropertyName = "Client";
            this.dataGridViewTextBoxColumn7.HeaderText = "Клиент";
            this.dataGridViewTextBoxColumn7.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            this.dataGridViewTextBoxColumn7.ToolTipText = "Функциональность на ключе";
            this.dataGridViewTextBoxColumn7.Width = 106;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.DataPropertyName = "Note";
            this.dataGridViewTextBoxColumn8.HeaderText = "Прочие";
            this.dataGridViewTextBoxColumn8.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            this.dataGridViewTextBoxColumn8.ToolTipText = "Окончание действия функциональности на ключе";
            this.dataGridViewTextBoxColumn8.Width = 105;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Initiator";
            this.dataGridViewTextBoxColumn9.HeaderText = "Инициатор";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            this.dataGridViewTextBoxColumn9.ToolTipText = "Инициатор предоставить ключ с данной функциональностью клиенту";
            this.dataGridViewTextBoxColumn9.Width = 106;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Initiator";
            this.dataGridViewTextBoxColumn10.HeaderText = "Инициатор";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ToolTipText = "Дополнительная информация";
            this.dataGridViewTextBoxColumn10.Width = 79;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Note";
            this.dataGridViewTextBoxColumn11.HeaderText = "Прочие";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.Width = 79;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button1.Location = new System.Drawing.Point(13, 726);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 28);
            this.button1.TabIndex = 5;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonAdd_Click);
            // 
            // button2
            // 
            this.button2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button2.Location = new System.Drawing.Point(205, 726);
            this.button2.Margin = new System.Windows.Forms.Padding(4);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(88, 28);
            this.button2.TabIndex = 6;
            this.button2.Text = "Отмена";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.ButtonCancel_Click);
            // 
            // KeyFeatureClientView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(819, 757);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DataGridViewKeyFeature);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.HeaderlineKey);
            this.Controls.Add(this.HeaderlineClient);
            this.Controls.Add(this.DataGridViewClient);
            this.IconOptions.ShowIcon = false;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MinimumSize = new System.Drawing.Size(704, 528);
            this.Name = "KeyFeatureClientView";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование отношений ключ-клиент";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingClient)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewKeyFeature)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingKeyFeatureClient)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.BindingSource bindingClient;
        private System.Windows.Forms.DataGridView DataGridViewClient;
        private System.Windows.Forms.DataGridView DataGridViewKeyFeature;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.BindingSource bindingKeyFeatureClient;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.Label HeaderlineClient;
        private System.Windows.Forms.Label HeaderlineKey;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn addressDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn phoneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn contactPersonDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewCheckBoxColumn selectedDataGridViewCheckBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn typeKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn featureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn initiatorDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn noteDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}