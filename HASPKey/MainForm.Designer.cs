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
            this.ExitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.EditToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KeyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.FeatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.KeyFeatureToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ReferenceToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.DataGridViewHomeView = new System.Windows.Forms.DataGridView();
            this.numberKeyDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.featureDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.clientDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.endDateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bindingHome = new System.Windows.Forms.BindingSource(this.components);
            this.Headline = new System.Windows.Forms.Label();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewHomeView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bindingHome)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.FileToolStripMenuItem,
            this.EditToolStripMenuItem,
            this.ReferenceToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(617, 24);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // FileToolStripMenuItem
            // 
            this.FileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ExitToolStripMenuItem});
            this.FileToolStripMenuItem.Name = "FileToolStripMenuItem";
            this.FileToolStripMenuItem.Size = new System.Drawing.Size(48, 20);
            this.FileToolStripMenuItem.Text = "Файл";
            // 
            // ExitToolStripMenuItem
            // 
            this.ExitToolStripMenuItem.Name = "ExitToolStripMenuItem";
            this.ExitToolStripMenuItem.Size = new System.Drawing.Size(108, 22);
            this.ExitToolStripMenuItem.Text = "Выход";
            this.ExitToolStripMenuItem.Click += new System.EventHandler(this.ВыходToolStripMenuItem_Click);
            // 
            // EditToolStripMenuItem
            // 
            this.EditToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.KeyToolStripMenuItem,
            this.FeatureToolStripMenuItem,
            this.ClientToolStripMenuItem,
            this.KeyFeatureToolStripMenuItem});
            this.EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            this.EditToolStripMenuItem.Size = new System.Drawing.Size(108, 20);
            this.EditToolStripMenuItem.Text = "Редактирование";
            // 
            // KeyToolStripMenuItem
            // 
            this.KeyToolStripMenuItem.Name = "KeyToolStripMenuItem";
            this.KeyToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.KeyToolStripMenuItem.Text = "Ключ";
            this.KeyToolStripMenuItem.Click += new System.EventHandler(this.KeyToolStripMenuItem_Click);
            // 
            // FeatureToolStripMenuItem
            // 
            this.FeatureToolStripMenuItem.Name = "FeatureToolStripMenuItem";
            this.FeatureToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.FeatureToolStripMenuItem.Text = "Функциональность";
            this.FeatureToolStripMenuItem.Click += new System.EventHandler(this.FeatureToolStripMenuItem_Click);
            // 
            // ClientToolStripMenuItem
            // 
            this.ClientToolStripMenuItem.Name = "ClientToolStripMenuItem";
            this.ClientToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.ClientToolStripMenuItem.Text = "Клиент";
            this.ClientToolStripMenuItem.Click += new System.EventHandler(this.ClientToolStripMenuItem_Click);
            // 
            // KeyFeatureToolStripMenuItem
            // 
            this.KeyFeatureToolStripMenuItem.Name = "KeyFeatureToolStripMenuItem";
            this.KeyFeatureToolStripMenuItem.Size = new System.Drawing.Size(249, 22);
            this.KeyFeatureToolStripMenuItem.Text = "Связь ключ-функциональность";
            this.KeyFeatureToolStripMenuItem.Click += new System.EventHandler(this.KeyFeatureToolStripMenuItem_Click);
            // 
            // ReferenceToolStripMenuItem
            // 
            this.ReferenceToolStripMenuItem.Name = "ReferenceToolStripMenuItem";
            this.ReferenceToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.ReferenceToolStripMenuItem.Text = "Справка";
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
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 8.25F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(31)))), ((int)(((byte)(53)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewHomeView.DefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewHomeView.Location = new System.Drawing.Point(12, 46);
            this.DataGridViewHomeView.Name = "DataGridViewHomeView";
            this.DataGridViewHomeView.ReadOnly = true;
            this.DataGridViewHomeView.Size = new System.Drawing.Size(594, 337);
            this.DataGridViewHomeView.TabIndex = 3;
            this.DataGridViewHomeView.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.DataGridViewHomeView_DataBindingComplete);
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
            // clientDataGridViewTextBoxColumn
            // 
            this.clientDataGridViewTextBoxColumn.DataPropertyName = "Client";
            this.clientDataGridViewTextBoxColumn.HeaderText = "Клиент";
            this.clientDataGridViewTextBoxColumn.Name = "clientDataGridViewTextBoxColumn";
            this.clientDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // endDateDataGridViewTextBoxColumn
            // 
            this.endDateDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.endDateDataGridViewTextBoxColumn.DataPropertyName = "EndDate";
            this.endDateDataGridViewTextBoxColumn.HeaderText = "Срок действия";
            this.endDateDataGridViewTextBoxColumn.Name = "endDateDataGridViewTextBoxColumn";
            this.endDateDataGridViewTextBoxColumn.ReadOnly = true;
            this.endDateDataGridViewTextBoxColumn.Width = 131;
            // 
            // bindingHome
            // 
            this.bindingHome.DataSource = typeof(ModelEntities.ModelViewMain);
            // 
            // Headline
            // 
            this.Headline.AutoSize = true;
            this.Headline.Location = new System.Drawing.Point(12, 30);
            this.Headline.Name = "Headline";
            this.Headline.Size = new System.Drawing.Size(146, 13);
            this.Headline.TabIndex = 4;
            this.Headline.Text = "Действующие HASP-ключи";
            this.Headline.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(617, 395);
            this.Controls.Add(this.Headline);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.DataGridViewHomeView);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.ShowIcon = false;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn numberKeyDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn featureDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn clientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn endDateDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem FeatureToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClientToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem KeyFeatureToolStripMenuItem;
        private System.Windows.Forms.Label Headline;
    }
}

