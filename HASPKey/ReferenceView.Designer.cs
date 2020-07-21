namespace HASPKey
{
    partial class ReferenceView
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ReferenceView));
            this.labelHeaderline = new System.Windows.Forms.Label();
            this.labelReference = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // labelHeaderline
            // 
            this.labelHeaderline.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.labelHeaderline.AutoSize = true;
            this.labelHeaderline.Font = new System.Drawing.Font("Tahoma", 15F);
            this.labelHeaderline.Location = new System.Drawing.Point(210, 9);
            this.labelHeaderline.Name = "labelHeaderline";
            this.labelHeaderline.Size = new System.Drawing.Size(92, 24);
            this.labelHeaderline.TabIndex = 0;
            this.labelHeaderline.Text = "Справка.";
            // 
            // labelReference
            // 
            this.labelReference.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelReference.AutoSize = true;
            this.labelReference.Font = new System.Drawing.Font("Tahoma", 12F);
            this.labelReference.Location = new System.Drawing.Point(12, 45);
            this.labelReference.Name = "labelReference";
            this.labelReference.Size = new System.Drawing.Size(42, 19);
            this.labelReference.TabIndex = 1;
            this.labelReference.Text = "label";
            // 
            // ReferenceView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 490);
            this.Controls.Add(this.labelReference);
            this.Controls.Add(this.labelHeaderline);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ReferenceView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справка";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label labelHeaderline;
        private System.Windows.Forms.Label labelReference;
    }
}