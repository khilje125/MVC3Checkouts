using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OSModel.Models
{
    public class Offers
    {
        [Key]
        public int OfferId { get; set; }
        public int? OfferTypeId { get; set; }
        public int? ProductId { get; set; }
        public float? PercentOff { get; set; }
        public int? BuyX { get; set; }
        public int? GetY { get; set; }
         [DataType(DataType.Currency)]
        public decimal? NowPrice { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool? isActive { get; set; }
        public int? CreatedId { get; set; }
        public int? ModifiedId { get; set; }
        public RecordCreation RecordCreation { get; set; }
        public RecordModification RecordModification { get; set; }
        public OfferType OfferType { get; set; }
        public Products Product { get; set; }
    }
}
