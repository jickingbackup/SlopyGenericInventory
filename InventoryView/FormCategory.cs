using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using BusinessObjects;
namespace InventoryView
{
    public partial class FormCategory : DevExpress.XtraEditors.XtraForm
    {

        public FormCategory()
        {
            InitializeComponent();

        }

        public FormCategory(int id)
            :this()
        {
            Category entity = Mapper.MapCategory( MySqlExpressDB.Select("SELECT * FROM Category WHERE Id="+id.ToString()).Rows[0]);
            textBoxId.Text = id.ToString();
            textBoxName.Text = entity.Name;
        }

        private void simpleButtonSave_Click(object sender, EventArgs e)
        {
            string query = "";
            Category entity = new Category()
            {
                Id = Convert.ToInt32(textBoxId.Text),
                Name = textBoxName.Text
            };
            bool isUnique = CheckIfNameIsUnique(entity.Name);
            bool isValid = entity.Validate();

            //Checks id entity is valid
            if (isValid && isUnique)
            {
                //Decides wether to perform Insert Or Update.
                if (Convert.ToInt32(textBoxId.Text) != 0)
                {
                    query = "UPDATE Category SET Name='" + entity.Name + "' WHERE Id=" + entity.Id;
                    MySqlExpressDB.Update(query);
                }
                else
                {
                    query = "INSERT INTO Category(Name) VALUES('" + entity.Name + "')";
                    MySqlExpressDB.Insert(query);
                }
                //Notify Action
                MessageBox.Show("Action Successful!");
                this.Close();
            }
            else
            {
                if(!isValid)
                {
                    MessageBox.Show(entity.ValidationErrors[0]);
                }
                else
                {
                    MessageBox.Show("Sorry, Specified Category Name Already Exists.");
                }
            }
        }

        bool CheckIfNameIsUnique(string name)
        {
            bool isUnique = true;
            List<Category> categories = Mapper.MapCategory(MySqlExpressDB.Select("SELECT * From Category"));

            foreach(Category category in categories)
            {
                if(category.Name.ToLower() == name.ToLower())
                {
                    isUnique = false;
                    break;
                }
            }

            return isUnique;
        }
    }
}
