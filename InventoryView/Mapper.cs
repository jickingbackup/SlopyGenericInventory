using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using System.Data;
using BusinessObjects;

namespace InventoryView
{
    /// <summary>
    /// Converts datatable to list<BusinessObject> Vice-versa
    /// Converts datarow to BusinessObject Vice-versa
    /// </summary>
    public static class Mapper
    {

        public static Vendor MapVendor(DataRow row)
        {
            Vendor entity = new Vendor()
            {
                Id = (int)row["Id"],
                Name = (string)row["Name"],
                ContactNumber = (string)row["ContactNumber"],
                Email = (string)row["Email"]
            };
            return entity;
        }

        public static List<Vendor> MapVendor(DataTable table)
        {
            List<Vendor> entities = new List<Vendor>();

            foreach (DataRow row in table.Rows)
            {
                entities.Add(MapVendor(row));
            }

            return entities;
        }

        public static Category MapCategory(DataRow row)
        {
            Category entity = new Category()
            {
                Id = (int)row["Id"],
                Name = (string)row["Name"]
            };
            return entity;
        }

        public static List<Category> MapCategory(DataTable table)
        {
            List<Category> entities = new List<Category>();

            foreach (DataRow row in table.Rows)
            {
                entities.Add(MapCategory(row));
            }

            return entities;
        }

        public static Product MapProduct(DataRow row)
        {
            Product entity = new Product()
            {
                Id = (int)row["Id"],
                VendorId = (int)row["VendorId"],
                CategoryId = (int)row["CategoryId"],
                Name = (string)row["Name"],
                Description = (string)row["Description"],
                Price = (decimal)row["Price"],
                Quantity = (int)row["Quantity"],
                DateStored = (string)row["TimeStamp"].ToString()

            };


            return entity;
        }

        public static List<Product> MapProduct(DataTable table)
        {
            List<Product> entities = new List<Product>();

            foreach (DataRow row in table.Rows)
            {
                entities.Add(MapProduct(row));
            }

            return entities;
        }

        /// <summary>
        /// Gets the index of the specified property name in a data row.
        /// </summary>
        public static int GetColumnIndex(DataRow row,string propertyName)
        {
            int colIndex = 0;
            bool hasFound = false;
            
            for (int i = 0; i < row.Table.Columns.Count;i++ )
            {
                if (row.Table.Columns[i].ColumnName == propertyName)
                {
                    hasFound = true;
                    colIndex = i;
                    break;
                }
            }
            if (!hasFound)
            {
                throw new Exception("The specified propertyName was not found in the specified datarow.");
            }
            return colIndex;
        }
    }
}
