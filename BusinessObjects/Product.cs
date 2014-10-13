using BusinessObjects.BusinessRules;

namespace BusinessObjects
{
    using System;
    using System.Collections.Generic;
    
    public partial class Product: BusinessObject
    {

        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int VendorId { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public string DateStored { get; set; }

        public Product()
        {
            //add bsusiness rules.
            AddRule(new ValidateId("Id"));
            AddRule(new ValidateId("CategoryId"));
            AddRule(new ValidateId("VendorId"));
            AddRule(new ValidateRequired("Name"));
            AddRule(new ValidateRequired("Description"));
            AddRule(new ValidateRequired("Price"));
            AddRule(new ValidateRequired("Quantity"));
        }
    
    }
}
