using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OSModel.Models;
using System.Data;


namespace RepositoryDAL
{
   public class AdminRepository
    {
       ShoppingContext db = new ShoppingContext();

       public User ValidateAdmin(string userName, string password)
       {
           User aUser = new User();

           var user = db.Users.Include("UserType").Where(c => (c.LoginName == userName || c.Email == userName) && c.Password == password && c.Usertype.Name == "superadmin").FirstOrDefault();

           if (user == null)
           {
               return aUser;
           }
           return user;
       }

       public User GetUserById(int id)
       {
           User aUser = new User();
           var user = db.Users.Include("UserType").Where(c => c.UserID == id).FirstOrDefault();
           //if (user == null)
           //{
           //    return aUser;
           //}
           return user;
       }

       public IEnumerable<User> GetAllUser()
       {
           var users = db.Users.Include("Usertype").ToList();
           return users;
       }

       public void AddUpdate(User user)
       {
           if (user.UserID > 0)
           {
              // db.Entry(user).State = EntityState.Modified;
               db.Entry(user).State = System.Data.Entity.EntityState.Modified;
               db.SaveChanges();

           }
           else
           {
               db.Users.Add(user);
               db.SaveChanges();
           }

       }

       public void Delete(User user)
       {
           db.Entry(user).State = System.Data.Entity.EntityState.Deleted;
           db.SaveChanges();
       }

       public IEnumerable<UserType> GetUserType()
       {
           var userTypeList = db.Usertype.ToList();
           return userTypeList;
       }
    }
}
