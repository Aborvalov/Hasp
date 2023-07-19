namespace HASPKey
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
            ((System.ComponentModel.ISupportInitialize)(this.panelControl1)).BeginInit();
            this.panelControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelControl1
            // 
            this.panelControl1.Controls.Add(this.labelControl1);
            this.panelControl1.Controls.Add(this.DataWindow);
            this.panelControl1.Location = new System.Drawing.Point(0, 0);
            this.panelControl1.Name = "panelControl1";
            this.panelControl1.Size = new System.Drawing.Size(297, 156);
            this.panelControl1.TabIndex = 0;
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(88, 27);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(100, 16);
            this.labelControl1.TabIndex = 2;
            this.labelControl1.Text = "Количество дней";
            // 
            // DataWindow
            // 
            this.DataWindow.Location = new System.Drawing.Point(88, 58);
            this.DataWindow.Name = "DataWindow";
            this.DataWindow.Size = new System.Drawing.Size(100, 23);
            this.DataWindow.TabIndex = 1;
            this.DataWindow.TextChanged += new System.EventHandler(this.DataWindowTextChanged);
            this.DataWindow.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.DataWindowKeyPress);
            this.DataWindow.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.DataWindow_MouseDoubleClick);
            // 
            // NewDataForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 156);
            this.Controls.Add(this.panelControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "NewDataForm";
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
    }
}