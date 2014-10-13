using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

using BusinessObjects;
namespace InventoryView
{
    public partial class XtraFormSupplier : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormSupplier()
        {
            InitializeComponent();
        }

        public XtraFormSupplier(int id)
            :this()
        {
            Vendor entity = Mapper.MapVendor(MySqlExpressDB.Select("SELECT * FROM Vendor WHERE Id=" + id.ToString()).Rows[0]);
            textBoxId.Text = id.ToString();
            textBoxName.Text = entity.Name;
            textEditEmail.Text = entity.Email;
            textEditContact.Text = entity.ContactNumber;
        }

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            string query = "";
            Vendor entity = new Vendor() { Id = Convert.ToInt32(textBoxId.Text), Name = textBoxName.Text,Email = textEditEmail.Text,ContactNumber = textEditContact.Text };
            bool isUnique = CheckIfNameIsUnique(entity.Name);
            bool isValid = entity.Validate();

            //Checks id entity is valid
            if (isValid && isUnique)
            {
                if (Convert.ToInt32(textBoxId.Text) != 0)
                {
                    query = "UPDATE Vendor SET Name='" + entity.Name + "',Email='" + entity.Email + "',ContactNumber='" + entity.ContactNumber + "'   WHERE Id=" + entity.Id;
                    MySqlExpressDB.Update(query);

                }
                else
                {
                    query = "INSERT INTO Vendor(Name,Email,ContactNumber) VALUES('" + entity.Name + "','"+entity.Email+"','"+entity.ContactNumber+"')";
                    MySqlExpressDB.Insert(query);
                }
                //Notify Action
                MessageBox.Show("Action Successful!");
                this.Close();
            }
            else
            {
                if (!isValid)
                {
                    MessageBox.Show(entity.ValidationErrors[0]);
                }
                else
                {
                    MessageBox.Show("Sorry, Specified Vendor Name Already Exists.");
                }
            }
        }

        bool CheckIfNameIsUnique(string name)
        {
            bool isUnique = true;
            List<Vendor> vendors = Mapper.MapVendor(MySqlExpressDB.Select("SELECT * From Vendor"));

            foreach (Vendor vendor in vendors)
            {
                if (vendor.Name.ToLower() == name.ToLower())
                {
                    isUnique = false;
                    break;
                }
            }

            return isUnique;
        }

    }
}