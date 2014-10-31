using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.Ajax.Utilities;
using OSModel.Models;
using System.Web.Security;
//using RepositoryHelper;
using RepositoryDAL;
using RepositoryHelper;

namespace OnlineShoping.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
       readonly ShoppingContext db;
       AdminRepository adminRepository = new AdminRepository();

       public AccountController()
        {
            db = new ShoppingContext();
        }
        
        
        public ActionResult Login(string returnUrl)
        {
            try
            {
                
                    ViewBag.ReturnUrl = returnUrl;
                    return View();
                
            }
            catch (Exception)
            {

                throw;
            }

        }

        [HttpPost]
        public ActionResult Login(LoginModel aloginmodel, string returnUrl, string remember)
        {
            try
            {
                if (ModelState.IsValid)
                {

                    var validatelogin = adminRepository.ValidateAdmin(aloginmodel.UserName, aloginmodel.Password);
                    if (validatelogin != null)
                    {


                        Session["admin"] = aloginmodel.UserName;
                        int days = remember == "on" ? 2 : 1;
                        if (Url.IsLocalUrl(returnUrl))
                        {
                            return Redirect(returnUrl);
                        }
                        else
                        {
                            return RedirectToAction("Index", "Home");

                        }
                    }
                }

                return View(aloginmodel);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
      
        public ActionResult LogOut()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login", "Account");
        }

        public ActionResult Register()
        {
           // User user = new User();
            var obj = adminRepository.GetAllUser();
            return View(obj);
        }

        public ActionResult AddEdit(int? id)
        {
            var obj = id.HasValue && id.Value > 0
                ? adminRepository.GetUserById(id.Value) 
                : new User() ;
            //var prodTypes = ((int[])Enum.GetValues(typeof(Common.Roles))).Select(e => new
            //{
            //    Value = ((Common.Roles)e).GetString(),
            //    Text = ((Common.Roles)e).GetDescription()
            //});
            //ViewBag.RoleList = new SelectList(prodTypes, "Value", "Text", obj.CreatedId);
            var userTypelist = adminRepository.GetUserType();
            ViewBag.uTypeList = new SelectList(userTypelist, "UserTypeID", "Name", obj.CreatedId);
            
            ViewBag.IsAjax = Request.IsAjaxRequest();
            ViewBag.IsUpdate = id.HasValue && id.Value > 0;

            if (Request.IsAjaxRequest())
            {
                return PartialView("_UserEditPartial", obj);
            }
            else
            {
                return View(obj);    
            }
           
            

        }

        [HttpPost]
        public ActionResult AddEdit(int? id, FormCollection collection, User model)
        {
            var admin = id.HasValue && id.Value > 0
                ? adminRepository.GetUserById(id.Value)
                : new User();
            if(string.IsNullOrWhiteSpace(model.FirstName))
                ModelState.AddModelError("FirstName","FirstName is Required.");
            if (string.IsNullOrWhiteSpace(model.LastName))
                ModelState.AddModelError("LastName", "LastName is Required.");
            if (string.IsNullOrWhiteSpace(model.LoginName))
                ModelState.AddModelError("LoginName", "LoginName is Required.");
            if (string.IsNullOrWhiteSpace(model.Password))
                ModelState.AddModelError("Password", "Password is Required.");
            if (string.IsNullOrWhiteSpace(model.Email))
                ModelState.AddModelError("Email", "Email is Required.");
            if (string.IsNullOrWhiteSpace(model.ContactNo))
                ModelState.AddModelError("ContactNo", "ContactNo is Required.");
            //if (Request.Files.Count <=0 || string.IsNullOrWhiteSpace(Request.Files[0].FileName))
            //    ModelState.AddModelError("imageFile", "Image is Required.");
            if (string.IsNullOrWhiteSpace(model.Address))
                ModelState.AddModelError("Address", "Address is Required.");

            //if (ModelState.IsValid)
            //{
            //    var count =
            //    adminRepository.GetAllUser()
            //        .Where(u => u.LoginName == model.LoginName)
            //        .Count();
            //    if (count > 0)
            //    {
            //        ModelState.AddModelError("LoginName", "UserName is not Available.");
            //    }
            //    count = adminRepository.GetAllUser()
            //            .Where(u =>  u.Email == model.Email)
            //            .Count();
            //    if (count > 0)
            //    {
            //        ModelState.AddModelError("Email","Email is already Exist with another user.");
            //    }
            //}
            

            if (ModelState.IsValid)
            {
                admin.FirstName = model.FirstName;
                admin.LastName = model.LastName;
                admin.LoginName = model.LoginName;
                admin.Email = model.Email;
                admin.Password = model.Password;
                admin.ContactNo = model.ContactNo;
                admin.Address = model.Address;
                admin.UserTypeId = model.UserTypeId;
                admin.image = "Default.jpg";

                adminRepository.AddUpdate(admin);
                var img = Request.Files[0];
                var url = "~/Data/Image/";
                admin.image = "User_" + admin.UserID + img.FileName.Substring(img.FileName.Length - 4);
                var imagePath = Server.MapPath(url + admin.image);
                img.SaveAs(imagePath);
                db.Entry(admin).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                //obj.Image = "PROJECT_" + obj.ID + img.FileName.Substring(img.FileName.Length - 4);

                //var imagePath = Server.MapPath("~/Data/Projects/img/" + obj.Image);
                //var thumbPath = Server.MapPath("~/Data/Projects/thumb/" + obj.Image);

                //img.SaveAs(imagePath);
                return RedirectToAction("Register");
            }
            var userTypelist = adminRepository.GetUserType();
            ViewBag.uTypeList = new SelectList(userTypelist, "UserTypeID", "Name",model.CreatedId);
            
            return View(model);
        }

        [HttpGet]
        public ActionResult Detail(int id)
        {
            var user = adminRepository.GetUserById(id);
            return View(user);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var user = adminRepository.GetUserById(id);
            return View(user);
        }

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            var user = adminRepository.GetUserById(id);
            adminRepository.Delete(user);
            return RedirectToAction("Register");
        }
    }
}
