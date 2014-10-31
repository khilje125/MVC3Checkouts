using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OSModel.Models
{
    public class Payments
    {
        [Key]
        public int PaymentId { get; set; }
        public int? OrderId { get; set; }

        public bool? OnlinePayment { get; set; }
        public bool? OfflinePayment { get; set; }

        public bool? BACS { get; set; }
        public bool? Cheque { get; set; }

        public string ChequeNo { get; set; }
        public string ScanChq { get; set; }
        public string NameOnChq { get; set; }

        public string SortCode { get; set; }
        public string AccountNo { get; set; }
        public string BankName { get; set; }

        [DataType(DataType.Currency)]
        public decimal? AmountReceived { get; set; }
        [DataType(DataType.Currency)]
        public decimal? VATReceived { get; set; }
        [DataType(DataType.Currency)]
        public decimal? TotalReceived { get; set; }
        [DataType(DataType.Currency)]
        public decimal? DeliveryChargeReceived { get; set; }

        public string PaymentMode { get; set; }
        public string ReceivedDetails { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public int? CreatedId { get; set; }
        public int? ModifiedId { get; set; }
        public RecordCreation RecordCreation { get; set; }
        public RecordModification RecordModification { get; set; }
        public Orders Order { get; set; }

    }
}
