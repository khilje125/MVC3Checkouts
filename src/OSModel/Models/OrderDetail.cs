using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OSModel.Models
{
    public class OrderDetail
    {
        [Key]
        public int OrderDetailId { get; set; }
        public int? OfferId { get; set; }
        public int? ProductId { get; set; }
        [DataType(DataType.Currency)]
        public decimal? CustomerPrice { get; set; }
        public int? OrderId { get; set; }
        public string Title { get; set; }
        public string Code { get; set; }
        public string Size { get; set; }
        public int? Quantity { get; set; }
        public string Description { get; set; }
        [DataType(DataType.Currency)]
        public decimal? PriceExcVAT { get; set; }
        public string Note { get; set; }
        public bool? isEnabled { get; set; }
        public string Image { get; set; }
        [DataType(DataType.Currency)]
        public decimal? ExcVATTotal { get; set; }
        public bool? Pending { get; set; }
        public int? QtyPending { get; set; }
        public int? QtySent { get; set; }
        public Products Product { get; set; }
        public Offers Offers { get; set; }
        public Orders Order { get; set; }
    }
}
