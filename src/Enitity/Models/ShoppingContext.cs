using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Entity;
using System.Threading.Tasks;

namespace Enitity.Models
{
   public class ShoppingContext: DbContext
    {
       public ShoppingContext()
           : base("OnlineShoppingDB")
       {
           this.Configuration.ValidateOnSaveEnabled = false;
       }

       public DbSet<User> Users { get; set; }
       public DbSet<UserType> UserType {get; set;}
    }
}
