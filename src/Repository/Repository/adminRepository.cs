using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSModel.Models;


namespace Repository.Repository
{
  public  class adminRepository
    {

      ShoppingContext db = new ShoppingContext();

         public User ValidateAdmin(string name, string password)
        {
            try
            {
                User aUser = new User();

                var Users = db.Users.Include("UserType")
                    .Where(u => (u.LoginName == name || u.Email == name) && u.Password == password && u.usertype.Name == "admin")
                    .ToList().Take(1);

                if (Users.Count() > 0)
                {
                    aUser = Users.Single();
                    return aUser;
                }

                return aUser;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
    }

