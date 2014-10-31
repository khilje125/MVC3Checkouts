using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;

namespace OSModel.Models
{
    public class ChangePasswordModel
    {
    }

    public class LoginModel
    {
        [Required]
        [Display(Name="User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name="Password")]
        public string Password { get; set; }

        [Display(Name="Remmember Me?")]
        public bool RemmemberMe { get; set; }
    }

    public class RegisterModel
    { 
    }
}