using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OSModel.Models;
using System.Data.Entity;

namespace OnlineShoping.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Admin/Home/
        ShoppingContext db = new ShoppingContext();
        public ActionResult Index()
        {
            if (Session["UserName"] == null)
            {
                return RedirectToAction("Login", "Account");
            }
            return View();
        }
        public ActionResult resetpassword()
        {

            return View();
        }
        [HttpPost]
        public ActionResult resetpassword(string validatepassword,string newpassword)
        {
           // var usersession = Session["UserName"];
            try
            {
                if (Session["admin"]!=null && !string.IsNullOrEmpty(validatepassword) && !string.IsNullOrEmpty(newpassword))
                {
                    var ds = (User)(Session["admin"]);
                    var user = db.Users.Find(ds.UserID);
                    if (ds.Password == validatepassword)
                    {
                        user.Password = newpassword;
                        db.Entry(user).State = EntityState.Detached;
                        db.Entry(user).State = EntityState.Modified;
                        db.SaveChanges();
                        if (db.SaveChanges() > 0)
                        {
                            return RedirectToAction("resetpassword", "Home", new { msg = "2" });
                        }
                        
                    }

                }
                return RedirectToAction("resetpassword", "Home", new { error = "2" });
            }
           
            catch (Exception)
            {
                
                throw;
            }
        }
    }
}
