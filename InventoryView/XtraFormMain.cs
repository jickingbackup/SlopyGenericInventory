using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using DevExpress.XtraEditors;

//References for the Skin Changer on the menu bar.
using DevExpress.XtraBars;
using DevExpress.XtraBars.Helpers;

namespace InventoryView
{
    public partial class XtraFormMain : DevExpress.XtraEditors.XtraForm,IMainForm
    {
        List<XtraForm> childForms = new List<XtraForm>();
        UserDetails userDetails = new UserDetails() { Id = 0, LoggedIn = false };

        public UserDetails CurrentUser
        {
            get { return userDetails; }
            set { userDetails = value; }
        }

        public XtraFormMain()
        {
            InitializeComponent();
            DevExpress.UserSkins.BonusSkins.Register();
            SkinHelper.InitSkinPopupMenu(barLinkContainerItem1);

            if(!MySqlExpressDB.TryConnect())
            {
                MessageBox.Show("Opps,theres a problem with your DB connection.");
                Environment.Exit(0);
            }

            //display login form
            while (!userDetails.LoggedIn)
            {
                XtraFormLogin login = new XtraFormLogin(userDetails);
                login.ShowDialog();
            }

            if (userDetails.LoggedIn)
            {
                splashScreenManager1.ShowWaitForm();
                barStaticItemUsername.Caption = userDetails.Username;
                InitializeChildXtraForms();
            }

        }

        #region init forms

        private void InitializeChildXtraForms()
        {
            bool isAdmin = true;
            if (userDetails.Id > 1)
            {
                isAdmin = false;
            }

            XtraFormProducts products = new XtraFormProducts(isAdmin);
            products.MainForm = this;
            XtraFormCategories categories = new XtraFormCategories(isAdmin);
            categories.MainForm = this;
            XtraFormSuppliers suppliers = new XtraFormSuppliers(isAdmin);
            suppliers.MainForm = this;
            XtraFormStockReport report = new XtraFormStockReport();
            report.MainForm = this;

            childForms.Add(categories);
            childForms.Add(suppliers);
            childForms.Add(report);
            childForms.Add(products);
            
            foreach (XtraForm form in childForms)
            {
                form.MdiParent = this;
                form.Show();
            }
        }

        #endregion 

        private void XtraFormMain_Load(object sender, EventArgs e)
        {
            RefreshLists();
        }

        private void barButtonItemExit_ItemClick(object sender, ItemClickEventArgs e)
        {
            Utility.ExitApp();
        }

        private void XtraFormMain_Shown(object sender, EventArgs e)
        {
            splashScreenManager1.CloseWaitForm();
        }

        private void barButtonItemChangePassword_ItemClick(object sender, ItemClickEventArgs e)
        {
            using(XtraFormChangePassword cp = new XtraFormChangePassword(userDetails.Id))
            {
                cp.ShowDialog();
            }
        }



        #region IMainForm Members

        public List<BusinessObjects.Category> Categories
        {
            get;
            set;
        }

        public List<BusinessObjects.Vendor> Vendors
        {
            get;
            set;
        }

        public List<BusinessObjects.Product> Products
        {
            get;
            set;
        }

        public void RefreshLists()
        {
            Categories = Mapper.MapCategory(MySqlExpressDB.Select("SELECT * FROM Category"));
            Vendors = Mapper.MapVendor(MySqlExpressDB.Select("SELECT * FROM Vendor"));
            Products =  Mapper.MapProduct(MySqlExpressDB.Select("SELECT * FROM Product")); 
        }

        #endregion
    }

    public class UserDetails
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public bool LoggedIn { get; set; }
    }
}