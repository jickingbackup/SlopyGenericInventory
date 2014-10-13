using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

using BusinessObjects.BusinessRules;
namespace BusinessObjects
{
    /// <summary>
    /// Class that holds information about a Category.
    /// </summary>
    public partial class Category:BusinessObject
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Category()
        {
            //add bsusiness rules.
            AddRule(new ValidateId("Id"));
            AddRule(new ValidateRequired("Name"));
        }
    }
}
