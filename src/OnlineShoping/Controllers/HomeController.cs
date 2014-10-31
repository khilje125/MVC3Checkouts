using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSModel.Models;
//using RepositoryHelper;

namespace OnlineShoping.Controllers
{
    public class HomeController : Controller
    {
        ShoppingContext db = new ShoppingContext();
        //
        // GET: /Home/

        public ActionResult Index()

        {
            db.Database.CreateIfNotExists();

            //UserType atype = new UserType();
            //atype.UserTypeID = 1;
            //atype.Name = "Admin";
            //db.UserType.Add(atype);
            //db.SaveChanges();
            //User aUser = new User();
            //aUser.FirstName = "Kaleem ";
            //aUser.LastName = "Paracha";
            //aUser.LoginName = "admin";
            //aUser.Password = "123456";
            //aUser.UserTypeId = 1;
            //db.Users.Add(aUser);
            //db.SaveChanges();
            return View();
        }

       
     
        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}
