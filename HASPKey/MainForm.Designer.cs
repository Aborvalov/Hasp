namespace HASPKey
{
    partial class MainForm
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
            presenter.Dispose();

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.FileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.SelectDataBaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FeatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.KeyFeatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KeyFeatureClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.Reference = new System.Windows.Forms.ToolStripMenuItem();
            this.DataGridViewHomeView = new System.Windows.Forms.DataGridView();
            this.numberKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.featureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingHome = new System.Windows.Forms.BindingSource(this.components);
            this.Headline = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.buttonSearchClient = new System.Windows.Forms.Button();
            this.buttonAll = new System.Windows.Forms.Button();
            this.toolTipButton = new System.Windows.Forms.ToolTip(this.components);
            this.viewOldKeys = new System.Windows.Forms.CheckBox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewHomeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingHome)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.ReferenceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuStrip1.Size = new System.Drawing.Size(720, 30);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.SelectDataBaseToolStripMenuItem,
            this.toolStripSeparator1,
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(59, 26);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // SelectDataBaseToolStripMenuItem
            // 
            this.SelectDataBaseToolStripMenuItem.Name = "SelectDataBaseToolStripMenuItem";
            this.SelectDataBaseToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.SelectDataBaseToolStripMenuItem.Text = "Выбор базы данных";
            this.SelectDataBaseToolStripMenuItem.Click += new System.EventHandler(this.SelectDataBaseToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(231, 6);
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(234, 26);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ВыходToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.KeyToolStripMenuItem,
            this.FeatureToolStripMenuItem,
            this.ClientToolStripMenuItem,
            this.toolStripSeparator2,
            this.KeyFeatureToolStripMenuItem,
            this.KeyFeatureClientToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(137, 26);
            this.EditToolStripMenuItem.Text = "Редактирование";
            // 
            // KeyToolStripMenuItem
            // 
            this.KeyToolStripMenuItem.Name = "KeyToolStripMenuItem";
            this.KeyToolStripMenuItem.Size = new System.Drawing.Size(309, 26);
            this.KeyToolStripMenuItem.Text = "Ключ";
            this.KeyToolStripMenuItem.Click += new System.EventHandler(this.KeyToolStripMenuItem_Click);
            // 
            // FeatureToolStripMenuItem
            // 
            this.FeatureToolStripMenuItem.Name = "FeatureToolStripMenuItem";
            this.FeatureToolStripMenuItem.Size = new System.Drawing.Size(309, 26);
            this.FeatureToolStripMenuItem.Text = "Функциональность";
            this.FeatureToolStripMenuItem.Click += new System.EventHandler(this.FeatureToolStripMenuItem_Click);
            // 
            // ClientToolStripMenuItem
            // 
            this.ClientToolStripMenuItem.Name = "ClientToolStripMenuItem";
            this.ClientToolStripMenuItem.Size = new System.Drawing.Size(309, 26);
            this.ClientToolStripMenuItem.Text = "Клиент";
            this.ClientToolStripMenuItem.Click += new System.EventHandler(this.ClientToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(306, 6);
            // 
            // KeyFeatureToolStripMenuItem
            // 
            this.KeyFeatureToolStripMenuItem.Name = "KeyFeatureToolStripMenuItem";
            this.KeyFeatureToolStripMenuItem.Size = new System.Drawing.Size(309, 26);
            this.KeyFeatureToolStripMenuItem.Text = "Связь ключ-функциональность";
            this.KeyFeatureToolStripMenuItem.Click += new System.EventHandler(this.KeyFeatureToolStripMenuItem_Click);
            // 
            // KeyFeatureClientToolStripMenuItem
            // 
            this.KeyFeatureClientToolStripMenuItem.Name = "KeyFeatureClientToolStripMenuItem";
            this.KeyFeatureClientToolStripMenuItem.Size = new System.Drawing.Size(309, 26);
            this.KeyFeatureClientToolStripMenuItem.Text = "Связь ключ-клиент";
            this.KeyFeatureClientToolStripMenuItem.Click += new System.EventHandler(this.KeyFeatureClientToolStripMenuItem_Click);
            // 
            // ReferenceToolStripMenuItem
            // 
            this.ReferenceToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Reference});
            this.ReferenceToolStripMenuItem.Name = "ReferenceToolStripMenuItem";
            this.ReferenceToolStripMenuItem.Size = new System.Drawing.Size(81, 26);
            this.ReferenceToolStripMenuItem.Text = "Справка";
            // 
            // Reference
            // 
            this.Reference.Name = "Reference";
            this.Reference.Size = new System.Drawing.Size(187, 26);
            this.Reference.Text = "О программе";
            this.Reference.Click += new System.EventHandler(this.Reference_Click);
            // 
            // DataGridViewHomeView
            // 
            this.DataGridViewHomeView.AllowUserToAddRows = false;
            this.DataGridViewHomeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewHomeView.AutoGenerateColumns = false;
            this.DataGridViewHomeView.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewHomeView.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGridViewHomeView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewHomeView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.numberKeyDataGridViewTextBoxColumn,
            this.featureDataGridViewTextBoxColumn,
            this.clientDataGridViewTextBoxColumn,
            this.endDateDataGridViewTextBoxColumn});
            this.DataGridViewHomeView.DataSource = this.bindingHome;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewHomeView.DefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewHomeView.Location = new System.Drawing.Point(14, 66);
            this.DataGridViewHomeView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.DataGridViewHomeView.Name = "DataGridViewHomeView";
            this.DataGridViewHomeView.ReadOnly = true;
            this.DataGridViewHomeView.RowHeadersWidth = 51;
            this.DataGridViewHomeView.Size = new System.Drawing.Size(693, 484);
            this.DataGridViewHomeView.TabIndex = 3;
            this.DataGridViewHomeView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridViewHomeView_DataBindingComplete);
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
            // featureDataGridViewTextBoxColumn
            // 
            this.featureDataGridViewTextBoxColumn.DataPropertyName = "Feature";
            this.featureDataGridViewTextBoxColumn.HeaderText = "Функциональность";
            this.featureDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.featureDataGridViewTextBoxColumn.Name = "featureDataGridViewTextBoxColumn";
            this.featureDataGridViewTextBoxColumn.ReadOnly = true;
            this.featureDataGridViewTextBoxColumn.ToolTipText = "Наименование функциональности";
            // 
            // clientDataGridViewTextBoxColumn
            // 
            this.clientDataGridViewTextBoxColumn.DataPropertyName = "Client";
            this.clientDataGridViewTextBoxColumn.HeaderText = "Клиент";
            this.clientDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.clientDataGridViewTextBoxColumn.Name = "clientDataGridViewTextBoxColumn";
            this.clientDataGridViewTextBoxColumn.ReadOnly = true;
            this.clientDataGridViewTextBoxColumn.ToolTipText = "Наименование клиента + адрес";
            // 
            // endDateDataGridViewTextBoxColumn
            // 
            this.endDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.endDateDataGridViewTextBoxColumn.DataPropertyName = "EndDate";
            this.endDateDataGridViewTextBoxColumn.HeaderText = "Срок действия";
            this.endDateDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.endDateDataGridViewTextBoxColumn.Name = "endDateDataGridViewTextBoxColumn";
            this.endDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.endDateDataGridViewTextBoxColumn.ToolTipText = "Окончание срока действия у ключа";
            this.endDateDataGridViewTextBoxColumn.Width = 131;
            // 
            // bindingHome
            // 
            this.bindingHome.DataSource = typeof(ModelEntities.ModelViewMain);
            // 
            // Headline
            // 
            this.Headline.AutoSize = true;
            this.Headline.Location = new System.Drawing.Point(16, 47);
            this.Headline.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Headline.Name = "Headline";
            this.Headline.Size = new System.Drawing.Size(167, 16);
            this.Headline.TabIndex = 4;
            this.Headline.Text = "Действующие HASP-ключи";
            this.Headline.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "NumberKey";
            this.dataGridViewTextBoxColumn1.HeaderText = "Номер ключа";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ToolTipText = "Номер ключа (нутренный номер + номер на ключе)";
            this.dataGridViewTextBoxColumn1.Width = 140;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "Feature";
            this.dataGridViewTextBoxColumn2.HeaderText = "Функциональность";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ToolTipText = "Наименование функциональности";
            this.dataGridViewTextBoxColumn2.Width = 140;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Client";
            this.dataGridViewTextBoxColumn3.HeaderText = "Клиент";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ToolTipText = "Наименование клиента + адрес";
            this.dataGridViewTextBoxColumn3.Width = 140;
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewTextBoxColumn4.DataPropertyName = "EndDate";
            this.dataGridViewTextBoxColumn4.HeaderText = "Срок действия";
            this.dataGridViewTextBoxColumn4.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            this.dataGridViewTextBoxColumn4.ToolTipText = "Окончание срока действия у ключа";
            this.dataGridViewTextBoxColumn4.Width = 131;
            // 
            // buttonSearchClient
            // 
            this.buttonSearchClient.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSearchClient.Location = new System.Drawing.Point(461, 34);
            this.buttonSearchClient.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonSearchClient.Name = "buttonSearchClient";
            this.buttonSearchClient.Size = new System.Drawing.Size(150, 28);
            this.buttonSearchClient.TabIndex = 5;
            this.buttonSearchClient.Text = "Поиск по клиенту";
            this.toolTipButton.SetToolTip(this.buttonSearchClient, "Выбор клиента для поиска.");
            this.buttonSearchClient.UseVisualStyleBackColor = true;
            this.buttonSearchClient.Click += new System.EventHandler(this.ButtonSearchClient_Click);
            // 
            // buttonAll
            // 
            this.buttonAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAll.Location = new System.Drawing.Point(618, 34);
            this.buttonAll.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(88, 28);
            this.buttonAll.TabIndex = 6;
            this.buttonAll.Text = "Все";
            this.toolTipButton.SetToolTip(this.buttonAll, "Список всех клиентов и действующих ключей.");
            this.buttonAll.UseVisualStyleBackColor = true;
            this.buttonAll.Click += new System.EventHandler(this.ButtonAll_Click);
            // 
            // viewOldKeys
            // 
            this.viewOldKeys.AutoSize = true;
            this.viewOldKeys.Location = new System.Drawing.Point(208, 39);
            this.viewOldKeys.Name = "viewOldKeys";
            this.viewOldKeys.Size = new System.Drawing.Size(246, 20);
            this.viewOldKeys.TabIndex = 7;
            this.viewOldKeys.Text = "Отображение просроченных ключей";
            this.viewOldKeys.UseVisualStyleBackColor = true;
            this.viewOldKeys.CheckedChanged += new System.EventHandler(this.viewOldKeys_CheckedChanged);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(720, 565);
            this.Controls.Add(this.viewOldKeys);
            this.Controls.Add(this.buttonAll);
            this.Controls.Add(this.buttonSearchClient);
            this.Controls.Add(this.Headline);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.DataGridViewHomeView);
            this.IconOptions.Icon = ((System.Drawing.Icon)(resources.GetObject("MainForm.IconOptions.Icon")));
            this.IconOptions.ShowIcon = false;
            this.MainMenuStrip = this.menuStrip1;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MinimumSize = new System.Drawing.Size(619, 427);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "HASP-ключи";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewHomeView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingHome)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem FileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ExitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem EditToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ReferenceToolStripMenuItem;
        private System.Windows.Forms.DataGridView DataGridViewHomeView;
        private System.Windows.Forms.BindingSource bindingHome;
        private System.Windows.Forms.ToolStripMenuItem KeyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem FeatureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KeyFeatureToolStripMenuItem;
        private System.Windows.Forms.Label Headline;
        private System.Windows.Forms.ToolStripMenuItem KeyFeatureClientToolStripMenuItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn numberKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn featureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.ToolStripMenuItem SelectDataBaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem Reference;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Button buttonSearchClient;
        private System.Windows.Forms.Button buttonAll;
        private System.Windows.Forms.ToolTip toolTipButton;
        private System.Windows.Forms.CheckBox viewOldKeys;
    }
}

