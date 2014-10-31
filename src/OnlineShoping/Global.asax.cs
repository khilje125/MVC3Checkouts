using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Routing;
using OSModel.Models;
using RepositoryDAL;

namespace OnlineShoping
{
    // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
    // visit http://go.microsoft.com/?LinkId=9394801
    public class MvcApplication : System.Web.HttpApplication
    {
        ShoppingContext db = new ShoppingContext();
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();

            WebApiConfig.Register(GlobalConfiguration.Configuration);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
          //  AppInt();
        }

        //private void AppInt()
        //{
        //   AdminRepository adminRepository = new AdminRepository();

        //    var admin = adminRepository.GetAllUser();
        //    if (admin == null)
        //    {
        //        UserType user = new UserType()
        //        {
        //            UserTypeID = 1,
        //            Name = "Admin"
        //            //FirstName = "Muhammad",
        //            //LastName =  "Arslan",
        //            //LoginName = "arslan",
        //            //Address = "New Garden Town",
        //            //ContactNo = "03006680283",
                    

        //        };
               
        //    }
        //}
    }
}