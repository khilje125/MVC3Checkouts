using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OSModel.Models
{
    public class Products
    {
        [Key]
        public int ProductId { get; set; }
        public int? ProductGroupId { get; set; }
        public string Code { get; set; }
        public string Size { get; set; }
        public string Title { get; set; }
        public string Descirption { get; set; }
        public int? Qunatity { get; set; }
        public string Image { get; set; }

        [DataType(DataType.Currency)]
        public decimal? PriceExcVAT { get; set; }
        public bool? isActive {get;set;}
        public int? CreatedId { get; set; }
        public int? ModifiedId { get; set; }
        public RecordCreation RecordCreation { get; set; }
        public RecordModification RecordModification { get; set; }
        public ProductsGroup ProductsGroup { get; set; }

        public List<ProductImages> Images { get; set; }
    }
}
