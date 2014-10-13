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
    public partial class XtraFormCategories : DevExpress.XtraEditors.XtraForm, IChildForm
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

        public XtraFormCategories(bool isAdmin = false)
        {
            InitializeComponent();
            IsUserAdmin = isAdmin;

            if (!IsUserAdmin)
            {
                DisableCRUDButoons();
            }

        }

        #region MyCode

        public void DisableCRUDButoons()
        {
            foreach(DevExpress.XtraNavBar.NavBarItem item in navBarControl1.Items)
            {
                item.Enabled = false;
                item.Visible = false;

            }
        }

        private void RefreshDataGrid()
        {
            MainForm.RefreshLists();
            gridControl1.DataSource = MainForm.Categories;
        }

        private int GetSelectedRowId()
        {
            //code here
            int id = Convert.ToInt32( gridView1.GetFocusedRowCellValue("Id"));
            return id;
        }

        #endregion

        private void navBarItemAddNew_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            using (FormCategory formToOpen = new FormCategory())
            {
                formToOpen.ShowDialog();
                RefreshDataGrid();
            }
        }

        private void navBarItemEdit_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            using (FormCategory formToOpen = new FormCategory(GetSelectedRowId()))
            {
                formToOpen.ShowDialog();
                RefreshDataGrid();
            }
        }

        private void navBarItemDelete_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            int id = GetSelectedRowId();

            if (Utility.CheckIfCategoryCanBeDeleted(id, MainForm.Products))
            {
                string query = "DELETE FROM Category WHERE Id=@id";
                Utility.DeleteRow(query, id);
                RefreshDataGrid();
            }
            else
            {
                MessageBox.Show("Sorry, You cannot delete this record since it is being used by a product.");
            }
            
        }

        private void XtraFormCategories_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }


    }
}