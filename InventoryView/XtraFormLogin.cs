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
    public partial class XtraFormLogin : DevExpress.XtraEditors.XtraForm
    {
        UserDetails userdDetails;
        public XtraFormLogin(UserDetails userDetails)
        {
            InitializeComponent();
            this.userdDetails = userDetails;

        }

        bool Login(string username,string password)
        {
            bool hasLoggedin = false;
            int userId = 0;

            try
            {
                userId = (int)MySqlExpressDB.ObjectScalar("SELECT Id from Employee WHERE Username=@username AND Password=@password", username, password);
            }
            catch
            {
                userId = 0;
            }
            
            if(userId > 0)
            {
                userdDetails.Id = userId;
                userdDetails.Username = username;
                userdDetails.LoggedIn = true;
                hasLoggedin = true;
            }
            return hasLoggedin;
        }

        private void simpleButtonLogin_Click(object sender, EventArgs e)
        {
            string username = textEditUsername.EditValue.ToString();
            string password = Utility.CalculateMD5Hash(textEditPassword.EditValue.ToString());

            if (Login(username, password))
            {
                MessageBox.Show("Login Successful!");
                this.Close();
            }
            else
            {
                MessageBox.Show("Login failed, invalid username or password");
            }
        }

        private void simpleButtonQuit_Click(object sender, EventArgs e)
        {
            Utility.ExitApp();
        }

    }
}