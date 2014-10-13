using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
namespace InventoryView
{
    public static class Utility
    {
        public static void DeleteRow(string query, int id)
        {
            DialogResult dResult = MessageBox.Show("Are you sure about deleting this record?", "", MessageBoxButtons.OKCancel);

            if (dResult.ToString() == "OK")
            {
                MySqlExpressDB.Delete(query, id);
            }
        }


        public static bool CheckIfCategoryCanBeDeleted(int id, List<BusinessObjects.Product> list)
        {
            bool canBeDeleted = true;

            foreach (var item in list)
            {
                if (item.CategoryId == id)
                {
                    canBeDeleted = false;
                    break;
                }
            }

            return canBeDeleted;
        }

        public static bool CheckIfVendorCanBeDeleted(int id, List<BusinessObjects.Product> list)
        {
            bool canBeDeleted = true;

            foreach (var item in list)
            {
                if (item.VendorId == id)
                {
                    canBeDeleted = false;
                    break;
                }
            }

            return canBeDeleted;
        }


        public static void ExitApp()
        {
            DialogResult dResult = MessageBox.Show("Are you sure you want to terminate this app?", "", MessageBoxButtons.OKCancel);

            if (dResult.ToString() == "OK")
            {
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// calculates md5 hash
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string CalculateMD5Hash(string input)
        {
            
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString());
            }
            return sb.ToString();
        }
    }
}
