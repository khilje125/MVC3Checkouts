using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OSModel.Models
{
    public class Orders
    {
        [Key]
        public int OrderId { get; set; }
        public int? CustomerId { get; set; }
        public DateTime? OrderDate { get; set; }
        public string Ref { get; set; }
        public bool? DeliveryNote { get; set; }
        public bool? isDispatched { get; set; }
        public bool? isInvoiced { get; set; }
        public bool? isFullPaymentReceived { get; set; }
        public string OrderBy { get; set; }
        public bool? isCancelled { get; set; }
        public bool? isCompleted { get; set; }
        public int? CreatedId { get; set; }
        public int? ModifiedId { get; set; }
        [DataType(DataType.Currency)]
        public decimal? DeliveryCharges { get; set; }
        [DataType(DataType.Currency)]
        public decimal? VATRate { get; set; }
        public RecordCreation RecordCreation { get; set; }
        public RecordModification RecordModification { get; set; }
        public Customers Customer { get; set; }
        public virtual List<OrderDetail> ItemsList { get; set; }
    }
}
