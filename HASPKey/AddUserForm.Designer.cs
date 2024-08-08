namespace HASPKey
{
    partial class AddUserForm
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textBoxName = new System.Windows.Forms.TextBox();
            this.panelFiltr = new System.Windows.Forms.Panel();
            this.checkUser = new System.Windows.Forms.RadioButton();
            this.checkSuperAdmin = new System.Windows.Forms.RadioButton();
            this.checkAdmin = new System.Windows.Forms.RadioButton();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.textBoxLogin = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.buttonClose = new System.Windows.Forms.Button();
            this.loginBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.panelFiltr.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loginBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.labelControl1.Appearance.Options.UseFont = true;
            this.labelControl1.Location = new System.Drawing.Point(78, 160);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(72, 28);
            this.labelControl1.TabIndex = 1;
            this.labelControl1.Text = "Логин:";
            // 
            // textBoxName
            // 
            this.textBoxName.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxName.Font = new System.Drawing.Font("Tahoma", 11F);
            this.textBoxName.Location = new System.Drawing.Point(165, 48);
            this.textBoxName.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxName.Name = "textBoxName";
            this.textBoxName.Size = new System.Drawing.Size(202, 30);
            this.textBoxName.TabIndex = 20;
            this.textBoxName.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxName_KeyDown);
            // 
            // panelFiltr
            // 
            this.panelFiltr.Controls.Add(this.checkUser);
            this.panelFiltr.Controls.Add(this.checkSuperAdmin);
            this.panelFiltr.Controls.Add(this.checkAdmin);
            this.panelFiltr.Location = new System.Drawing.Point(87, 97);
            this.panelFiltr.Margin = new System.Windows.Forms.Padding(4);
            this.panelFiltr.Name = "panelFiltr";
            this.panelFiltr.Size = new System.Drawing.Size(311, 56);
            this.panelFiltr.TabIndex = 21;
            // 
            // checkUser
            // 
            this.checkUser.AutoSize = true;
            this.checkUser.Font = new System.Drawing.Font("Tahoma", 10F);
            this.checkUser.Location = new System.Drawing.Point(226, 14);
            this.checkUser.Name = "checkUser";
            this.checkUser.Size = new System.Drawing.Size(65, 25);
            this.checkUser.TabIndex = 30;
            this.checkUser.TabStop = true;
            this.checkUser.Text = "User";
            this.checkUser.UseVisualStyleBackColor = true;
            // 
            // checkSuperAdmin
            // 
            this.checkSuperAdmin.AutoSize = true;
            this.checkSuperAdmin.Font = new System.Drawing.Font("Tahoma", 10F);
            this.checkSuperAdmin.Location = new System.Drawing.Point(100, 14);
            this.checkSuperAdmin.Name = "checkSuperAdmin";
            this.checkSuperAdmin.Size = new System.Drawing.Size(120, 25);
            this.checkSuperAdmin.TabIndex = 29;
            this.checkSuperAdmin.TabStop = true;
            this.checkSuperAdmin.Text = "SuperAdmin";
            this.checkSuperAdmin.UseVisualStyleBackColor = true;
            // 
            // checkAdmin
            // 
            this.checkAdmin.AutoSize = true;
            this.checkAdmin.Font = new System.Drawing.Font("Tahoma", 10F);
            this.checkAdmin.Location = new System.Drawing.Point(3, 14);
            this.checkAdmin.Name = "checkAdmin";
            this.checkAdmin.Size = new System.Drawing.Size(78, 25);
            this.checkAdmin.TabIndex = 28;
            this.checkAdmin.TabStop = true;
            this.checkAdmin.Text = "Admin";
            this.checkAdmin.UseVisualStyleBackColor = true;
            // 
            // labelControl2
            // 
            this.labelControl2.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.labelControl2.Appearance.Options.UseFont = true;
            this.labelControl2.Location = new System.Drawing.Point(64, 211);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(86, 28);
            this.labelControl2.TabIndex = 10;
            this.labelControl2.Text = "Пароль:";
            // 
            // labelControl3
            // 
            this.labelControl3.Appearance.Font = new System.Drawing.Font("Tahoma", 14F);
            this.labelControl3.Appearance.Options.UseFont = true;
            this.labelControl3.Location = new System.Drawing.Point(100, 48);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(50, 28);
            this.labelControl3.TabIndex = 22;
            this.labelControl3.Text = "Имя:";
            // 
            // textBoxLogin
            // 
            this.textBoxLogin.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxLogin.Font = new System.Drawing.Font("Tahoma", 11F);
            this.textBoxLogin.Location = new System.Drawing.Point(165, 162);
            this.textBoxLogin.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxLogin.Name = "textBoxLogin";
            this.textBoxLogin.Size = new System.Drawing.Size(202, 30);
            this.textBoxLogin.TabIndex = 23;
            this.textBoxLogin.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxLogin_KeyDown);
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.textBoxPassword.Font = new System.Drawing.Font("Tahoma", 11F);
            this.textBoxPassword.Location = new System.Drawing.Point(163, 213);
            this.textBoxPassword.Margin = new System.Windows.Forms.Padding(4);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(202, 30);
            this.textBoxPassword.TabIndex = 24;
            this.textBoxPassword.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxPassword_KeyDown);
            // 
            // buttonCreate
            // 
            this.buttonCreate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonCreate.Location = new System.Drawing.Point(150, 278);
            this.buttonCreate.Margin = new System.Windows.Forms.Padding(4);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(88, 28);
            this.buttonCreate.TabIndex = 26;
            this.buttonCreate.Text = "Создать";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.buttonCreate_Click);
            // 
            // buttonClose
            // 
            this.buttonClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClose.Location = new System.Drawing.Point(256, 278);
            this.buttonClose.Margin = new System.Windows.Forms.Padding(4);
            this.buttonClose.Name = "buttonClose";
            this.buttonClose.Size = new System.Drawing.Size(88, 28);
            this.buttonClose.TabIndex = 27;
            this.buttonClose.Text = "Закрыть";
            this.buttonClose.UseVisualStyleBackColor = true;
            this.buttonClose.Click += new System.EventHandler(this.buttonClose_Click);
            // 
            // loginBindingSource
            // 
            this.loginBindingSource.DataSource = typeof(ModelEntities.ModelViewUser);
            // 
            // AddUserForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(465, 319);
            this.Controls.Add(this.buttonClose);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxLogin);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.panelFiltr);
            this.Controls.Add(this.textBoxName);
            this.Controls.Add(this.labelControl1);
            this.IconOptions.ShowIcon = false;
            this.Name = "AddUserForm";
            this.Text = "Добавление пользователя";
            this.panelFiltr.ResumeLayout(false);
            this.panelFiltr.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.loginBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private System.Windows.Forms.TextBox textBoxName;
        private System.Windows.Forms.Panel panelFiltr;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private System.Windows.Forms.TextBox textBoxLogin;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.Button buttonClose;
        private System.Windows.Forms.BindingSource loginBindingSource;
        private System.Windows.Forms.RadioButton checkUser;
        private System.Windows.Forms.RadioButton checkSuperAdmin;
        private System.Windows.Forms.RadioButton checkAdmin;
    }
}