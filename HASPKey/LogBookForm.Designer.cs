namespace HASPKey
{
    partial class LogBookForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogBookForm));
            this.DataGridViewLogBook = new System.Windows.Forms.DataGridView();
            this.userDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.loginTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.actionsDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.logbookBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.comboSorting = new DevExpress.XtraEditors.ComboBoxEdit();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.paginationPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonAll = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewLogBook)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.logbookBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboSorting.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridViewLogBook
            // 
            this.DataGridViewLogBook.AllowUserToAddRows = false;
            this.DataGridViewLogBook.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DataGridViewLogBook.AutoGenerateColumns = false;
            this.DataGridViewLogBook.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DataGridViewLogBook.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DataGridViewLogBook.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridViewLogBook.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userDataGridViewTextBoxColumn,
            this.loginTimeDataGridViewTextBoxColumn,
            this.actionsDataGridViewTextBoxColumn});
            this.DataGridViewLogBook.DataSource = this.logbookBindingSource;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Tahoma", 7.8F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(40)))), ((int)(((byte)(40)))));
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.DataGridViewLogBook.DefaultCellStyle = dataGridViewCellStyle1;
            this.DataGridViewLogBook.Location = new System.Drawing.Point(18, 44);
            this.DataGridViewLogBook.Margin = new System.Windows.Forms.Padding(4);
            this.DataGridViewLogBook.Name = "DataGridViewLogBook";
            this.DataGridViewLogBook.RowHeadersVisible = false;
            this.DataGridViewLogBook.RowHeadersWidth = 51;
            this.DataGridViewLogBook.Size = new System.Drawing.Size(756, 457);
            this.DataGridViewLogBook.TabIndex = 16;
            // 
            // userDataGridViewTextBoxColumn
            // 
            this.userDataGridViewTextBoxColumn.DataPropertyName = "User";
            this.userDataGridViewTextBoxColumn.HeaderText = "Имя";
            this.userDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.userDataGridViewTextBoxColumn.Name = "userDataGridViewTextBoxColumn";
            // 
            // loginTimeDataGridViewTextBoxColumn
            // 
            this.loginTimeDataGridViewTextBoxColumn.DataPropertyName = "LoginTime";
            this.loginTimeDataGridViewTextBoxColumn.HeaderText = "Время";
            this.loginTimeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.loginTimeDataGridViewTextBoxColumn.Name = "loginTimeDataGridViewTextBoxColumn";
            // 
            // actionsDataGridViewTextBoxColumn
            // 
            this.actionsDataGridViewTextBoxColumn.DataPropertyName = "Actions";
            this.actionsDataGridViewTextBoxColumn.HeaderText = "Действия";
            this.actionsDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.actionsDataGridViewTextBoxColumn.Name = "actionsDataGridViewTextBoxColumn";
            // 
            // logbookBindingSource
            // 
            this.logbookBindingSource.DataSource = typeof(ModelEntities.ModelViewLog);
            // 
            // comboSorting
            // 
            this.comboSorting.Location = new System.Drawing.Point(572, 9);
            this.comboSorting.Name = "comboSorting";
            this.comboSorting.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 11F);
            this.comboSorting.Properties.Appearance.Options.UseFont = true;
            this.comboSorting.Properties.Buttons.AddRange(new DevExpress.XtraEditors.Controls.EditorButton[] {
            new DevExpress.XtraEditors.Controls.EditorButton(DevExpress.XtraEditors.Controls.ButtonPredefines.Combo)});
            this.comboSorting.Properties.Items.AddRange(new object[] {
            "Вход в программу",
            "Удаления",
            "Обновления",
            "Добавления"});
            this.comboSorting.Size = new System.Drawing.Size(202, 28);
            this.comboSorting.TabIndex = 30;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "User";
            this.dataGridViewTextBoxColumn1.HeaderText = "Имя";
            this.dataGridViewTextBoxColumn1.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.Width = 251;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "LoginTime";
            this.dataGridViewTextBoxColumn2.HeaderText = "Время";
            this.dataGridViewTextBoxColumn2.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.Width = 251;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "Actions";
            this.dataGridViewTextBoxColumn3.HeaderText = "Действия";
            this.dataGridViewTextBoxColumn3.MinimumWidth = 6;
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.Width = 251;
            // 
            // paginationPanel
            // 
            this.paginationPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.paginationPanel.AutoScroll = true;
            this.paginationPanel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("paginationPanel.BackgroundImage")));
            this.paginationPanel.Location = new System.Drawing.Point(248, 522);
            this.paginationPanel.Name = "paginationPanel";
            this.paginationPanel.Size = new System.Drawing.Size(299, 71);
            this.paginationPanel.TabIndex = 31;
            this.paginationPanel.WrapContents = false;
            // 
            // buttonAll
            // 
            this.buttonAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonAll.Location = new System.Drawing.Point(459, 8);
            this.buttonAll.Margin = new System.Windows.Forms.Padding(4);
            this.buttonAll.Name = "buttonAll";
            this.buttonAll.Size = new System.Drawing.Size(88, 28);
            this.buttonAll.TabIndex = 32;
            this.buttonAll.Text = "Все";
            this.buttonAll.UseVisualStyleBackColor = true;
            this.buttonAll.Click += new System.EventHandler(this.ButtonAll_Click);
            // 
            // LogBookForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(787, 605);
            this.Controls.Add(this.buttonAll);
            this.Controls.Add(this.paginationPanel);
            this.Controls.Add(this.comboSorting);
            this.Controls.Add(this.DataGridViewLogBook);
            this.IconOptions.ShowIcon = false;
            this.MinimumSize = new System.Drawing.Size(789, 641);
            this.Name = "LogBookForm";
            this.Text = "Журнал";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridViewLogBook)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.logbookBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.comboSorting.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridViewLogBook;
        private System.Windows.Forms.BindingSource logbookBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn userDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn loginTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn actionsDataGridViewTextBoxColumn;
        private DevExpress.XtraEditors.ComboBoxEdit comboSorting;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.FlowLayoutPanel paginationPanel;
        private System.Windows.Forms.Button buttonAll;
    }
}