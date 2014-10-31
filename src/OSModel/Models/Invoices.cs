using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OSModel.Models
{
    public class Invoices
    {
        [Key]
        public int InvoiceId { get; set; }
        public int? OrderId { get; set; }
        [DataType(DataType.Currency)]
        public decimal? ExcVATTotal { get; set; }
        [DataType(DataType.Currency)]
        public decimal? VATTotal { get; set; }
        [DataType(DataType.Currency)]
        public decimal? IncVATTotal { get; set; }
        [DataType(DataType.Currency)]
        public decimal? Discount { get; set; }
        [DataType(DataType.Currency)]
        public decimal? DelCharge { get; set; }
        [DataType(DataType.Currency)]
        public decimal? VATRate { get; set; }
        public int? CreatedId { get; set; }
        public int? ModifiedId { get; set; }
        public RecordCreation RecordCreation { get; set; }
        public RecordModification RecordModification { get; set; }
        public Orders Order { get; set; }

        public Invoices()
        {
        }

        public Invoices(int orderId, decimal ExcVATTotal, decimal VATTotal, decimal IncVATTotal, decimal Discount, decimal DelCharge, decimal VATRate)
        {
            this.OrderId = orderId;
            this.ExcVATTotal = ExcVATTotal;
            this.VATTotal = VATTotal;
            this.IncVATTotal = IncVATTotal;
            this.Discount = Discount;
            this.DelCharge = DelCharge;
            this.VATRate = VATRate;
        }
    }
}
