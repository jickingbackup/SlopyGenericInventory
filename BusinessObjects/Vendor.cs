using BusinessObjects.BusinessRules;
namespace BusinessObjects
{
    using System;
    using System.Collections.Generic;
    
    public partial class Vendor:BusinessObject
    {
    
        public int Id { get; set; }
        public string Name { get; set; }
        public string ContactNumber { get; set; }
        public string Email { get; set; }
        public Vendor()
        {
            //add bsusiness rules.
            AddRule(new ValidateId("Id"));
            AddRule(new ValidateRequired("Name"));
            AddRule(new ValidateEmail("Email"));
        }
    }
}
