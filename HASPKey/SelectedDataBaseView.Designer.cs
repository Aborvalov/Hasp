namespace HASPKey
{
    partial class SelectedDataBaseView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SelectedDataBaseView));
            this.groupBoxListDataBase = new System.Windows.Forms.GroupBox();
            this.radioButtonWorkDataBase = new System.Windows.Forms.RadioButton();
            this.radioButtonTestDataBase = new System.Windows.Forms.RadioButton();
            this.groupBoxListDataBase.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxListDataBase
            // 
            this.groupBoxListDataBase.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxListDataBase.Controls.Add(this.radioButtonWorkDataBase);
            this.groupBoxListDataBase.Controls.Add(this.radioButtonTestDataBase);
            this.groupBoxListDataBase.Location = new System.Drawing.Point(12, 12);
            this.groupBoxListDataBase.Name = "groupBoxListDataBase";
            this.groupBoxListDataBase.Size = new System.Drawing.Size(170, 226);
            this.groupBoxListDataBase.TabIndex = 0;
            this.groupBoxListDataBase.TabStop = false;
            this.groupBoxListDataBase.Text = "Список баз данных";
            // 
            // radioButtonWorkDataBase
            // 
            this.radioButtonWorkDataBase.AutoSize = true;
            this.radioButtonWorkDataBase.Location = new System.Drawing.Point(6, 43);
            this.radioButtonWorkDataBase.Name = "radioButtonWorkDataBase";
            this.radioButtonWorkDataBase.Size = new System.Drawing.Size(93, 17);
            this.radioButtonWorkDataBase.TabIndex = 1;
            this.radioButtonWorkDataBase.Text = "Рабочая база";
            this.radioButtonWorkDataBase.UseVisualStyleBackColor = true;
            this.radioButtonWorkDataBase.CheckedChanged += new System.EventHandler(this.RadioButtonWorkDataBase_CheckedChanged);
            // 
            // radioButtonTestDataBase
            // 
            this.radioButtonTestDataBase.AutoSize = true;
            this.radioButtonTestDataBase.Location = new System.Drawing.Point(6, 20);
            this.radioButtonTestDataBase.Name = "radioButtonTestDataBase";
            this.radioButtonTestDataBase.Size = new System.Drawing.Size(98, 17);
            this.radioButtonTestDataBase.TabIndex = 0;
            this.radioButtonTestDataBase.Text = "Тестовая база";
            this.radioButtonTestDataBase.UseVisualStyleBackColor = true;
            this.radioButtonTestDataBase.CheckedChanged += new System.EventHandler(this.RadioButtonTestDataBase_CheckedChanged);
            // 
            // SelectedDataBaseView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(194, 250);
            this.Controls.Add(this.groupBoxListDataBase);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SelectedDataBaseView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Выбор базы данных";
            this.groupBoxListDataBase.ResumeLayout(false);
            this.groupBoxListDataBase.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxListDataBase;
        private System.Windows.Forms.RadioButton radioButtonWorkDataBase;
        private System.Windows.Forms.RadioButton radioButtonTestDataBase;
    }
}