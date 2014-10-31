using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OSModel.Models
{

    [Serializable]
    public class Cart
    {
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Size { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Price { get; set; }
        [DataType(DataType.Currency)]
        public decimal? CustomerPrice { get; set; }
        public string Image { get; set; }
        public decimal? TotalPrice { get; set; }
        public decimal? Discount { get; set; }
    }
}
