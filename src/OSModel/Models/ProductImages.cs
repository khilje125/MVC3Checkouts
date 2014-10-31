using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OSModel.Models
{
    public class ProductImages
    {
        [Key]
        public int ImageId { get; set; }
        public int? ProductId { get; set; }
        public string Image { get; set; }
        public string TinyImages { get; set; }
        public bool? isShow { get; set; }
        public int? CreatedId { get; set; }
        public int? ModifiedId { get; set; }
        public RecordCreation RecordCreation { get; set; }
        public RecordModification RecordModification { get; set; }
        public Products Product { get; set; }
    }
}
