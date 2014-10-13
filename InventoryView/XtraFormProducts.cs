using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;

namespace InventoryView
{
    public partial class XtraFormProducts : DevExpress.XtraEditors.XtraForm
    {
        public IMainForm MainForm
        {
            get;
            set;
        }

        bool isUserAdmin = false;

        public bool IsUserAdmin
        {
            get { return isUserAdmin; }
            set { isUserAdmin = value; }
        }

        public XtraFormProducts(bool isAdmin = false)
        {
            InitializeComponent();
            IsUserAdmin = isAdmin;

            if (!IsUserAdmin)
            {
                DisableCRUDButoons();
            }
            
        }

        public void DisableCRUDButoons()
        {
            foreach (DevExpress.XtraNavBar.NavBarItem item in navBarControl1.Items)
            {
                item.Enabled = false;
                item.Visible = false;
            }

            navBarControl1.Items[3].Enabled = true;
            navBarControl1.Items[3].Visible = true;
        }

        #region MyCode

        private void RefreshDataGrid()
        {
            MainForm.RefreshLists();
            List<BusinessObjects.Vendor> vendors = MainForm.Vendors;
            List<BusinessObjects.Category> categories = MainForm.Categories;
            List<ProductView> products = new List<ProductView>();
            List<BusinessObjects.Product> rawProducts = MainForm.Products;
            //map raw to view products
            foreach(var item in rawProducts)
            {
                var product = new ProductView();
                product.Id = item.Id;
                product.Name = item.Name;
                product.Price = item.Price;
                product.Quantity = item.Quantity;
                product.Description = item.Description;
                product.DateStored = item.DateStored;
                product.Category = categories.FirstOrDefault(c => c.Id == item.CategoryId).Name;
                product.Vendor = vendors.FirstOrDefault(v => v.Id == item.VendorId).Name;
                products.Add(product);
            }



            gridControl1.DataSource = products;
        }

        private int GetSelectedRowId()
        {
            //code here
            int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
            return id;
        }

        #endregion

        #region Events
        private void navBarItemAddNew_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            using (XtraFormProduct formToOpen = new XtraFormProduct())
            {
                formToOpen.ShowDialog();
                RefreshDataGrid();
            }
        }

        private void navBarItemEdit_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            using (XtraFormProduct formToOpen = new XtraFormProduct(GetSelectedRowId()))
            {
                formToOpen.ShowDialog();
                RefreshDataGrid();
            }
        }

        private void navBarItemDelete_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            int id = GetSelectedRowId();
            string query = "DELETE FROM Product WHERE Id=@id";
            Utility.DeleteRow(query,id);
            RefreshDataGrid();
        }

        private void XtraFormProducts_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        private void navBarItemUpdateStock_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            using (XtraFormUpadateStock formToOpen = new XtraFormUpadateStock(GetSelectedRowId()))
            {
                formToOpen.EmployeeId = MainForm.CurrentUser.Id;
                formToOpen.ShowDialog();
                
                RefreshDataGrid();
            }

        }
        #endregion


    }

    public class ProductView
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public string Vendor { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string DateStored { get; set; }
    }
}