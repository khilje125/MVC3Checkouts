using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OSModel.Models
{
    public class OfferType
    {
        [Key]
        public int OfferTypeId { get; set; }
        public string Name { get; set; }
    }
}
