using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OSModel.Models
{
    public class Company
    {
        [Key]
        public int CompanyId { get; set; }
        public string Name { get; set; }
        public string AddressLine1 { get; set; }
        public string AddressLine2 { get; set; }
        public string City { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }
        public string Country { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public string VATNo { get; set; }
        public string DelCharge { get; set; }
        public string VATRate { get; set; }
        public int? CreatedId { get; set; }
        public int? ModifiedId { get; set; }
        public RecordCreation RecordCreation { get; set; }
        public RecordModification RecordModification { get; set; }
    }
}
