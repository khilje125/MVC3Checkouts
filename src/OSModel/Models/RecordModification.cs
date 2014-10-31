using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;

namespace OSModel.Models
{
    public class RecordModification
    {
        [Key]
        public int ModifiedId { get; set; }
        public Nullable<int> UserId { get; set; }
        public string Ip { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> ModifiedDate { get; set; }

        public RecordModification()
        {
        }

        public RecordModification(int? userId = null, string ip = null, string description = "")
        {
            this.UserId = userId;
            this.Ip = ip;
            this.Description = description;
            this.ModifiedDate = DateTime.Now;
        }
        
    }
}
