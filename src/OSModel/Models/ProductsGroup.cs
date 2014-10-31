using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OSModel.Models
{
    public class ProductsGroup
    {
        [Key]
        public int ProductGroupId { get; set; }
        public int? CategoryId { get; set; }
        public string Title { get; set; }
        public string Descirption { get; set; }
        public string Note { get; set; }
        public bool? isEnable { get; set; }
        public int? CreatedId { get; set; }
        public int? ModifiedId { get; set; }
        public RecordCreation RecordCreation { get; set; }
        public RecordModification RecordModification { get; set; }
        public Categories Category { get; set; }
    }
}
