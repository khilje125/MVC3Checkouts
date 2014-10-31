using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OSModel.Models
{
    public class CustomerRegisterWrapper
    {
        public Customers Customer { get; set; }
        public CustomerBillingAddress BillingAddress { get; set; }
    }
}
