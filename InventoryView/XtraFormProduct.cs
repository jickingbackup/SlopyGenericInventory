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
    /// <summary>
    /// 
    /// </summary>
    public partial class XtraFormProduct : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormProduct()
        {
            InitializeComponent();
            textEditDateStored.Enabled = false;

            textEditCategoryId.Properties.DataSource = Mapper.MapCategory(MySqlExpressDB.Select("SELECT * FROM Category"));
            textEditCategoryId.Properties.ValueMember = "Id";
            textEditCategoryId.Properties.DisplayMember = "Name";

            textEditVendorId.Properties.DataSource = Mapper.MapVendor(MySqlExpressDB.Select("SELECT * FROM Vendor"));
            textEditVendorId.Properties.DisplayMember = "Name";
            textEditVendorId.Properties.ValueMember = "Id";
        }

        public XtraFormProduct(int id)
            :this()
        {
            textEditId.Text = id.ToString();
            //gets 
            var entity = Mapper.MapProduct(MySqlExpressDB.Select("SELECT * FROM Product WHERE Id=" + id.ToString()).Rows[0]);
            //sets controls.
            textEditName.Text = entity.Name;
            textEditDescription.Text = entity.Description;
            textEditPrice.Text = entity.Price.ToString();
            textEditQuantity.Text = entity.Quantity.ToString();
            textEditDateStored.Text = entity.DateStored;
            //textEditName.Enabled = false;
            ///textEditCategoryId.Enabled = false;
            //textEditDescription.Enabled = false;
            //textEditVendorId.Enabled = false;

            textEditCategoryId.EditValue = entity.CategoryId;
            textEditVendorId.EditValue = entity.VendorId;

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            string query = "";
            Product entity = new Product() { 
                Id = Convert.ToInt32(textEditId.Text),
                Name = textEditName.Text,
                Description = textEditDescription.Text,
                CategoryId = Convert.ToInt32(textEditCategoryId.EditValue),
                VendorId = Convert.ToInt32(textEditVendorId.EditValue),
                Quantity = Convert.ToInt32(textEditQuantity.Text),
                Price = Convert.ToDecimal(textEditPrice.Text)
            };

            bool isUnique = CheckIfNameIsUnique(entity.Name);
            bool isValid = entity.Validate();

            //Checks id entity is valid
            if (isValid && isUnique)
            {
                //Checks if product exists in db.
                if (Convert.ToInt32(textEditId.Text) != 0)
                {
                    query = "UPDATE Product SET ";
                    query += "VendorId =" + entity.VendorId.ToString() + ", CategoryId=" + entity.CategoryId.ToString() + ", Name='" + entity.Name + "', Description='" + entity.Description + "', Price=" + entity.Price.ToString() + ",Quantity= " + entity.Quantity.ToString() + " WHERE Id=" + entity.Id;
                    MySqlExpressDB.Update(query);
                }
                else
                {
                    query = "INSERT INTO Product(VendorId, CategoryId, Name, Description, Price, Quantity)";
                    query += "VALUES(" + entity.VendorId.ToString() + ", " + entity.CategoryId.ToString() + ", '" + entity.Name + "', '" + entity.Description + "', " + entity.Price.ToString() + ", " + entity.Quantity.ToString() + ")";
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
                    MessageBox.Show("Sorry, Specified Product Name Already Exists.");
                }
            }
            
        }

        bool CheckIfNameIsUnique(string name)
        {
            bool isUnique = true;
            List<Product> products = Mapper.MapProduct(MySqlExpressDB.Select("SELECT * From Product"));

            foreach (Product product in products)
            {
                if (product.Name.ToLower() == name.ToLower())
                {
                    isUnique = false;
                    break;
                }
            }

            return isUnique;
        }

    }
}