using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

using System.ComponentModel.DataAnnotations.Schema;

namespace OSModel.Models
{
    public class Customers
    {
        [Key]
        public int CustomerId { get; set; }

        public int? CompanyId { get; set; }

        [Required(ErrorMessage = "Please provide contact name")]
        public string ContactName { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        [Required(ErrorMessage = "Please provide city")]
        public string City { get; set; }

        [Required(ErrorMessage = "Please provide password")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        public string WebPassword { get; set; }

        //[Required(ErrorMessage = "Please provide password")]
        [DataType(DataType.Password)]
      
       // [Compare("WebPassword", ErrorMessage = "Passwords do not match.")]
        public string ConfirmPassword { get; set; }

        [Required(ErrorMessage = "Please provide county")]
        public string County { get; set; }

        [Required(ErrorMessage = "Please provide postcode")]
        public string Postcode { get; set; }

        public string Country { get; set; }

        [Required(ErrorMessage = "Please provide phone number")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Please provide mobile number")]
        public string Mobile { get; set; }

        [Required(ErrorMessage = "Please provide fax")]
        public string Fax { get; set; }

        public string AccountNo { get; set; }

        [Required(ErrorMessage = "Please provide email")]
        [RegularExpression("^[a-zA-Z0-9_.-]+@[a-zA-Z0-9-]+.[a-zA-Z0-9-.]+$", ErrorMessage = "Must be a valid email")]
        public string Email { get; set; }

     
        [Compare("Email", ErrorMessage = "Email do not match.")]
        public string ConfirmEmail { get; set; }

        public string Website { get; set; }

        public string Notes { get; set; }

        public bool? isActive { get; set; }

        [Required(ErrorMessage = "Please provide business name")]
        public string WebUsername { get; set; }

        public string Salt { get; set; }

        public bool? GPShop { get; set; }

        public bool? DentistShop { get; set; }

        public bool? VetShop { get; set; }

        public bool? Homecare { get; set; }

        public bool? OtherCare { get; set; }

        public bool? StandingOrder { get; set; }

        public DateTime? RegDate { get; set; }

        public int? CreatedId { get; set; }

        public int? ModifiedId { get; set; }

        public RecordCreation RecordCreation { get; set; }

        public RecordModification RecordModification { get; set; }

        public Company Company { get; set; }
    }
}