﻿namespace HASPKey
{
    partial class NewDataForm
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
            this.panelControl1 = new DevExpress.XtraEditors.PanelControl();
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.DataWindow = new System.Windows.Forms.TextBox();
            this.ButtonDelete = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.button1);
            this.panelControl1.Controls.Add(this.ButtonDelete);
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.DataWindow);
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(296, 158);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(99, 28);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(100, 16);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Количество дней";
            // 
            // DataWindow
            // 
            this.DataWindow.Location = new System.Drawing.Point(99, 67);
            this.DataWindow.Name = "DataWindow";
            this.DataWindow.Size = new System.Drawing.Size(100, 23);
            this.DataWindow.TabIndex = 1;
            // 
            // ButtonDelete
            // 
            this.ButtonDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonDelete.Location = new System.Drawing.Point(13, 116);
            this.ButtonDelete.Margin = new System.Windows.Forms.Padding(4);
            this.ButtonDelete.Name = "ButtonDelete";
            this.ButtonDelete.Size = new System.Drawing.Size(88, 28);
            this.ButtonDelete.TabIndex = 9;
            this.ButtonDelete.Text = "ОК";
            this.ButtonDelete.UseVisualStyleBackColor = true;
            this.ButtonDelete.Click += new System.EventHandler(this.ButtonOK_Click);
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Location = new System.Drawing.Point(183, 116);
            this.button1.Margin = new System.Windows.Forms.Padding(4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(88, 28);
            this.button1.TabIndex = 10;
            this.button1.Text = "Отмена";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.ButtonUndo_Click);
            // 
            // NewDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(120F, 120F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Dpi;
            this.ClientSize = new System.Drawing.Size(295, 157);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.ShowIcon = false;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(297, 197);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(297, 197);
            this.Name = "NewDataForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройки";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.DXFormFormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).EndInit();
            this.panelControl1.ResumeLayout(false);
            this.panelControl1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.PanelControl panelControl1;
        private System.Windows.Forms.TextBox DataWindow;
        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.Button ButtonDelete;
        private System.Windows.Forms.Button button1;
    }
}