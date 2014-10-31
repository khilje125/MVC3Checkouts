using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Enitity.Models
{
   public class User
    {
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public Nullable<int> UserTypeId { get; set; }
        public Nullable<int> UserStatusId { get; set; }
        public int? CreatedId { get; set; }
        public int? ModifiedId { get; set; }
        //public RecordCreation RecordCreation { get; set; }
        //public RecordModification RecordModification { get; set; }
        //public UserType UserType { get; set; }
        //public UserStatus UserStatus { get; set; }
    }
}
