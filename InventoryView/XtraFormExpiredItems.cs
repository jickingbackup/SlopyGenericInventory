using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;
using System.Linq;
using BusinessObjects;
namespace InventoryView
{
    public partial class XtraFormExpiredItems : DevExpress.XtraEditors.XtraForm,IChildForm
    {
        public XtraFormExpiredItems(bool isAdmin = false)
        {
            IsUserAdmin = isAdmin;
            InitializeComponent();
        }

        #region IChildForm Members

        public bool IsUserAdmin
        {
            get;
            set;
        }

        public IMainForm MainForm
        {
            get;
            set;
        }

        public void DisableCRUDButoons()
        {

        }

        private void RefreshDataGrid()
        {
            MainForm.RefreshLists();
            List<Product> list = MainForm.Products.Where(x => x.Quantity <= 0).ToList();
            //gridControl1.DataSource = MainForm.Categories;
        }

        #endregion
    }
}