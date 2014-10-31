using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OSModel.Models
{
    public class Stock
    {
        [Key]
        public int StockId { get; set; }
        public int? ProductId { get; set; }
        public int? SupplierId { get; set; }
        public int Quantity { get; set; }
        public string Reference { get; set; }
        public int? CreatedId { get; set; }
        public int? ModifiedId { get; set; }
        public RecordCreation RecordCreation { get; set; }
        public RecordModification RecordModification { get; set; }
        public Suppliers Supplier { get; set; }
        public Products Product { get; set; }

        public IEnumerable<StockLog> StockLog { get; set; }

    }
}
