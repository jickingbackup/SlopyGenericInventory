using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessObjects;

namespace InventoryView
{
    public interface IMainForm
    {
        List<Category> Categories { get; set; }
        List<Vendor> Vendors { get; set; }
        List<Product> Products { get; set; }
        UserDetails CurrentUser { get; set; }
        void RefreshLists();
    }
}
