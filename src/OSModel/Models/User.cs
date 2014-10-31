using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace OSModel.Models
{
   public class User
    {
       [Key]
        public int UserID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string LoginName { get; set; }
        public string Email { get; set; }
        public string ContactNo { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string image { get; set; }
        public int? UserTypeId { get; set; }
    
        public int? CreatedId { get; set; }
        public int? ModifiedId { get; set; }
        public UserType Usertype { get; set; }
        //public RecordCreation RecordCreation { get; set; }
        //public RecordModification RecordModification { get; set; }
        //public UserType UserType { get; set; }
        //public UserStatus UserStatus { get; set; 
       public string getutypename()
       {
         try
         {
             ShoppingContext db = new ShoppingContext(); 
             
               return  db.Usertype.Where((c => c.UserTypeID == this.UserTypeId)).FirstOrDefault().Name;
                
             

         }

           catch (Exception)
           {
                
               throw;
           }
       }
    }

 
}

