using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OSModel.Models
{
    public class StockLog
    {
        [Key]
        public int StockLogId { get; set; }
        public int? StockId { get; set; }
        public int? ProductId { get; set; }
        public int? OrderId { get; set; }
        public int Quantity { get; set; }
        public string Reference { get; set; }
        public int? CreatedId { get; set; }
        public int? ModifiedId { get; set; }
        public RecordCreation RecordCreation { get; set; }
        public RecordModification RecordModification { get; set; }
        public Stock Stock { get; set; }
        public Products Product { get; set; }
        public Orders Order { get; set; }
    }
}
