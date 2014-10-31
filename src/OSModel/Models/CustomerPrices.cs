using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OSModel.Models
{
    public class CustomerPrices
    {
        [Key]
        public int CustomerPriceId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        [DataType(DataType.Currency)]
        public decimal Price { get; set; }

        public Products Product { get; set; }
        public Customers Customer { get; set; }

        public CustomerPrices()
        {
        }

        public CustomerPrices(int productId, int customerId, decimal price)
        {
            this.Price = price;
            this.ProductId = productId;
            this.CustomerId = customerId;
        }

    }
}
