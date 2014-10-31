using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OSModel.Models
{
    public class CustomePrices
    {
        [Key]
        public int CustomePriceId { get; set; }
        public int? ProductId { get; set; }
        public int? CustomerId { get; set; }
        public decimal? PriceExcVAT { get; set; }
        public bool? isActive { get; set; }
        public int? CreatedId { get; set; }
        public int? ModifiedId { get; set; }
        public RecordCreation RecordCreation { get; set; }
        public RecordModification RecordModification { get; set; }
        public Products Product { get; set; }
        public Customers Customer { get; set; }

    }
}
