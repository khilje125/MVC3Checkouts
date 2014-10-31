using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
namespace OSModel.Models
{
   public class UserType
    {
       [Key]
       public int UserTypeID { get; set; }
       public string Name { get; set; }

    }
}
