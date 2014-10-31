using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OSModel.Models
{
    public class Categories
    {
        [Key]
        public int CategoryId { get; set; }
        public Nullable<int> ParentId { get; set; }
        public string Name { get; set; }
        public string Icon { get; set; }
        public string Image { get; set; }
        public bool? isActive { get; set; }
        public string Description { get; set; }
        public int? CreatedId { get; set; }
        public int? ModifiedId { get; set; }
        public RecordCreation RecordCreation { get; set; }
        public RecordModification RecordModification { get; set; }
        public bool? isMainMenu { get; set; }
        public int? Order { get; set; }

        public virtual List<Categories> SubCategories { get; set; }
        public virtual List<ProductsGroup> ProductGroup { get; set; }


    }
}
