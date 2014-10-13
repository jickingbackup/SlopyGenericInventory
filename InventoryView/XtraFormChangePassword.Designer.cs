namespace InventoryView
{
    partial class XtraFormChangePassword
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
            this.labelControl1 = new DevExpress.XtraEditors.LabelControl();
            this.textEditCurrentPassword = new DevExpress.XtraEditors.TextEdit();
            this.textEditNewPassword = new DevExpress.XtraEditors.TextEdit();
            this.textEditNewPassword2 = new DevExpress.XtraEditors.TextEdit();
            this.labelControl2 = new DevExpress.XtraEditors.LabelControl();
            this.labelControl3 = new DevExpress.XtraEditors.LabelControl();
            this.simpleButtonOk = new DevExpress.XtraEditors.SimpleButton();
            ((System.ComponentModel.ISupportInitialize)(this.textEditCurrentPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNewPassword.Properties)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNewPassword2.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // labelControl1
            // 
            this.labelControl1.Location = new System.Drawing.Point(12, 12);
            this.labelControl1.Name = "labelControl1";
            this.labelControl1.Size = new System.Drawing.Size(90, 13);
            this.labelControl1.TabIndex = 0;
            this.labelControl1.Text = "Current Password:";
            // 
            // textEditCurrentPassword
            // 
            this.textEditCurrentPassword.Location = new System.Drawing.Point(12, 31);
            this.textEditCurrentPassword.Name = "textEditCurrentPassword";
            this.textEditCurrentPassword.Properties.PasswordChar = '*';
            this.textEditCurrentPassword.Size = new System.Drawing.Size(272, 20);
            this.textEditCurrentPassword.TabIndex = 1;
            // 
            // textEditNewPassword
            // 
            this.textEditNewPassword.Location = new System.Drawing.Point(12, 76);
            this.textEditNewPassword.Name = "textEditNewPassword";
            this.textEditNewPassword.Properties.PasswordChar = '*';
            this.textEditNewPassword.Size = new System.Drawing.Size(272, 20);
            this.textEditNewPassword.TabIndex = 3;
            // 
            // textEditNewPassword2
            // 
            this.textEditNewPassword2.Location = new System.Drawing.Point(12, 121);
            this.textEditNewPassword2.Name = "textEditNewPassword2";
            this.textEditNewPassword2.Properties.PasswordChar = '*';
            this.textEditNewPassword2.Size = new System.Drawing.Size(272, 20);
            this.textEditNewPassword2.TabIndex = 4;
            // 
            // labelControl2
            // 
            this.labelControl2.Location = new System.Drawing.Point(12, 57);
            this.labelControl2.Name = "labelControl2";
            this.labelControl2.Size = new System.Drawing.Size(74, 13);
            this.labelControl2.TabIndex = 2;
            this.labelControl2.Text = "New Password:";
            // 
            // labelControl3
            // 
            this.labelControl3.Location = new System.Drawing.Point(12, 102);
            this.labelControl3.Name = "labelControl3";
            this.labelControl3.Size = new System.Drawing.Size(120, 13);
            this.labelControl3.TabIndex = 5;
            this.labelControl3.Text = "Re-enter New Password:";
            // 
            // simpleButtonOk
            // 
            this.simpleButtonOk.Location = new System.Drawing.Point(12, 152);
            this.simpleButtonOk.Name = "simpleButtonOk";
            this.simpleButtonOk.Size = new System.Drawing.Size(272, 36);
            this.simpleButtonOk.TabIndex = 6;
            this.simpleButtonOk.Text = "Ok";
            this.simpleButtonOk.Click += new System.EventHandler(this.simpleButtonOk_Click);
            // 
            // XtraFormChangePassword
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(296, 200);
            this.Controls.Add(this.simpleButtonOk);
            this.Controls.Add(this.labelControl3);
            this.Controls.Add(this.textEditNewPassword2);
            this.Controls.Add(this.textEditNewPassword);
            this.Controls.Add(this.labelControl2);
            this.Controls.Add(this.textEditCurrentPassword);
            this.Controls.Add(this.labelControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "XtraFormChangePassword";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Change Password";
            ((System.ComponentModel.ISupportInitialize)(this.textEditCurrentPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNewPassword.Properties)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.textEditNewPassword2.Properties)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private DevExpress.XtraEditors.LabelControl labelControl1;
        private DevExpress.XtraEditors.TextEdit textEditCurrentPassword;
        private DevExpress.XtraEditors.TextEdit textEditNewPassword;
        private DevExpress.XtraEditors.TextEdit textEditNewPassword2;
        private DevExpress.XtraEditors.LabelControl labelControl2;
        private DevExpress.XtraEditors.LabelControl labelControl3;
        private DevExpress.XtraEditors.SimpleButton simpleButtonOk;
    }
}