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
    public partial class XtraFormStockReport : DevExpress.XtraEditors.XtraForm
    {
        public XtraFormStockReport()
        {
            InitializeComponent();
        }

        public XtraFormMain MainForm { get; set; }


        void LoadData()
        {
            DataTable rawlist = MySqlExpressDB.Select("SELECT * FROM stockhistoryview");
            

            gridControl1.DataSource = rawlist;
        }

        private void navBarItemRefresh_LinkClicked(object sender, DevExpress.XtraNavBar.NavBarLinkEventArgs e)
        {
            LoadData();
        }

        private void XtraFormStockReport_Load(object sender, EventArgs e)
        {
            LoadData();
        }

        private void XtraFormStockReport_Activated(object sender, EventArgs e)
        {
            LoadData();
        }
    }

    public class StockReport
    {
        public int Id { get; set; }
        public string Employee { get; set; }
        public string Product { get; set; }
        public int Quantity { get; set; }
    }
}