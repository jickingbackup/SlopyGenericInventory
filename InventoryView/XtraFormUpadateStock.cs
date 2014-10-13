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
    public partial class XtraFormUpadateStock : DevExpress.XtraEditors.XtraForm
    {
        const int MAXVALUE = 999999999;
        Product product;
        int newQuantity = 0;
        public int EmployeeId = 0;

        public XtraFormUpadateStock(int id)
        {
            InitializeComponent();
            //set product
            product = Mapper.MapProduct(MySqlExpressDB.Select("SELECT * FROM Product WHERE Id="+id).Rows[0]);
            textEditName.Text = product.Name;
            textEditCurrentQuantity.Text = product.Quantity.ToString();

        }

        void UpdateRecord()
        {
            int quantityAdded = Convert.ToInt32(spinEditQuantity.Value);
            int productId = product.Id;
            
            if (comboBoxEdit1.SelectedIndex == 1)
            {
                quantityAdded = quantityAdded * -1;
            }


            if (CheckIfInputIsCorrect())
            {
                string query = string.Format( "UPDATE Product SET Quantity={0} WHERE Id={1}",newQuantity,product.Id);
                MySqlExpressDB.Update(query);
                //insert new stock history
                MySqlExpressDB.Insert("INSERT INTO genericinventory.stockhistory (Id,Quantity, ProductId,Date, EmployeeId) VALUES (NULL, @quantityAdded, @productId, CURRENT_TIMESTAMP, @EmployeeId)", quantityAdded, productId, EmployeeId);
                //Notify Action
                MessageBox.Show("Action Successful!");

                this.Close();
            }
            else
            {
                MessageBox.Show("Update Failed,New Value must not exceed 999999999 and cannot fall below 0 .Please Check your inputs.");

            }
        }


        bool CheckIfInputIsCorrect()
        {
            bool isCorrect = true;

            if (comboBoxEdit1.SelectedIndex == 0)
            {
                int sum = product.Quantity + Convert.ToInt32(spinEditQuantity.EditValue);
                if (sum > MAXVALUE)
                {
                    isCorrect = false;
                    spinEditQuantity.EditValue = MAXVALUE - product.Quantity;
                    newQuantity = MAXVALUE;
                }
                else
                {
                    newQuantity = sum;
                }
            }
            else
            {
                if (product.Quantity < Convert.ToInt32(spinEditQuantity.EditValue))
                {
                    isCorrect = false;
                    spinEditQuantity.EditValue = product.Quantity;
                    newQuantity = 0;
                }
                else
                {
                    newQuantity = product.Quantity - Convert.ToInt32(spinEditQuantity.EditValue);
                }
            }

            return isCorrect;
        }

        private void simpleButtonUpdate_Click(object sender, EventArgs e)
        {
            UpdateRecord();
        }
    }
}