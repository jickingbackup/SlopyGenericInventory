using System;
namespace InventoryView
{
    public interface IChildForm
    {
        bool IsUserAdmin { get; set; }
        IMainForm MainForm { get; set; }
        void DisableCRUDButoons();
    }
}
