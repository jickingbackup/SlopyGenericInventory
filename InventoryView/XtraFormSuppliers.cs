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
    public partial class XtraFormSuppliers : DevExpress.XtraEditors.XtraForm,IChildForm
    {
        bool isUserAdmin = false;

        public bool IsUserAdmin
        {
            get { return isUserAdmin; }
            set { isUserAdmin = value; }
        }

        public IMainForm MainForm
        {
            get;
            set;
        }

        public XtraFormSuppliers(bool isAdmin = false)
        {
            IsUserAdmin = isAdmin;
            InitializeComponent();
            

            if(!IsUserAdmin)
            {
                DisableCRUDButoons();
            }
        }

        #region MyCode

        public void DisableCRUDButoons()
        {
            foreach (DevExpress.XtraNavBar.NavBarItem item in navBarControl1.Items)
            {
                item.Enabled = false;
                item.Visible = false;
            }
        }


        private void RefreshDataGrid()
        {
            MainForm.RefreshLists();
            gridControl1.DataSource = MainForm.Vendors;
        }

        private int GetSelectedRowId()
        {
            //code here
            int id = Convert.ToInt32(gridView1.GetFocusedRowCellValue("Id"));
            return id;
        }

        #endregion

        private void navBarItemAddNew_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            using (XtraFormSupplier formToOpen = new XtraFormSupplier())
            {
                formToOpen.ShowDialog();
                RefreshDataGrid();
            }
        }

        private void navBarItemEdit_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            using (XtraFormSupplier formToOpen = new XtraFormSupplier(GetSelectedRowId()))
            {
                formToOpen.ShowDialog();
                RefreshDataGrid();
            }
        }

        private void navBarItemDelete_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            int id = GetSelectedRowId();
            
            if (Utility.CheckIfVendorCanBeDeleted(id, MainForm.Products))
            {
                string query = "DELETE FROM Vendor WHERE Id=@id";
                Utility.DeleteRow(query, id);
                RefreshDataGrid();
            }
            else
            {
                MessageBox.Show("Sorry, You cannot delete this record since it is being used by a product.");
            }
        }

        private void XtraFormSuppliers_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }


    }
}