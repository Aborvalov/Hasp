namespace HASPKey
{
    partial class EditKeyFeatureView
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
            this.buttonSave = new System.Windows.Forms.Button();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.labelEndDate = new System.Windows.Forms.Label();
            this.dtmStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtmEndDate = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // buttonSave
            // 
            this.buttonSave.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
            this.buttonSave.Location = new System.Drawing.Point(215, 542);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(75, 23);
            this.buttonSave.TabIndex = 0;
            this.buttonSave.Text = "Сохранить";
            this.buttonSave.UseVisualStyleBackColor = true;
            // 
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(303, 72);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(123, 13);
            this.labelStartDate.TabIndex = 1;
            this.labelStartDate.Text = "Дата начала действия";
            // 
            // labelEndDate
            // 
            this.labelEndDate.AutoSize = true;
            this.labelEndDate.Location = new System.Drawing.Point(303, 182);
            this.labelEndDate.Name = "labelEndDate";
            this.labelEndDate.Size = new System.Drawing.Size(141, 13);
            this.labelEndDate.TabIndex = 2;
            this.labelEndDate.Text = "Дата окончания действия";
            // 
            // dtmStartDate
            // 
            this.dtmStartDate.Location = new System.Drawing.Point(306, 88);
            this.dtmStartDate.Name = "dtmStartDate";
            this.dtmStartDate.Size = new System.Drawing.Size(138, 21);
            this.dtmStartDate.TabIndex = 3;
            // 
            // dtmEndDate
            // 
            this.dtmEndDate.Location = new System.Drawing.Point(306, 198);
            this.dtmEndDate.Name = "dtmEndDate";
            this.dtmEndDate.Size = new System.Drawing.Size(138, 21);
            this.dtmEndDate.TabIndex = 4;
            // 
            // EditKeyFeatureView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(504, 577);
            this.Controls.Add(this.dtmEndDate);
            this.Controls.Add(this.dtmStartDate);
            this.Controls.Add(this.labelEndDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.buttonSave);
            this.Name = "EditKeyFeatureView";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Редактирование отношений ключ-функциональность";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.Label labelEndDate;
        private System.Windows.Forms.DateTimePicker dtmStartDate;
        private System.Windows.Forms.DateTimePicker dtmEndDate;
    }
}