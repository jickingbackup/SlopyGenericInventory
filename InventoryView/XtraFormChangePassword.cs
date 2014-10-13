using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

namespace InventoryView
{
    public partial class XtraFormChangePassword : DevExpress.XtraEditors.XtraForm
    {
        int userId = 0;

        public XtraFormChangePassword(int userId)
        {
            InitializeComponent();
            this.userId = userId;
        }

        bool ValidateCurrentPassword()
        {
            bool isValid = false;
            string password = Utility.CalculateMD5Hash(textEditCurrentPassword.EditValue.ToString());
            isValid = MySqlExpressDB.BooleanScalar("SELECT Id FROM Employee WHERE Id=@userId AND Password=@password",userId,password);
            return isValid;
        }

        bool ChangePassword()
        {
            string newPassword = Utility.CalculateMD5Hash(textEditNewPassword2.EditValue.ToString());
            return MySqlExpressDB.Update("UPDATE Employee SET Password=@newPassword WHERE Id=@userId ", newPassword, userId);
        }


        private void simpleButtonOk_Click(object sender, EventArgs e)
        {
            if (textEditCurrentPassword.Text != string.Empty && textEditNewPassword.Text != string.Empty)
            {
                if (!ValidateCurrentPassword())
                {
                    MessageBox.Show("Current Password entered did not match to the current password in db.");
                }
                else
                {
                    if (textEditNewPassword.EditValue.ToString() != textEditNewPassword2.EditValue.ToString())
                    {
                        MessageBox.Show("New password did not match.");
                    }
                    else
                    {
                        //
                        if (ChangePassword())
                        {
                            MessageBox.Show("Password Updated.");
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Opps something went wrong.");
                        }

                    }
                }
            }
            else
            {
                MessageBox.Show("Fields must not be left blank.");
            }
            
        }
    }
}