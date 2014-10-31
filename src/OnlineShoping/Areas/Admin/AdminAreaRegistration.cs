using System.Web.Mvc;

namespace OnlineShoping.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Admin_default",
                "Admin/{controller}/{action}/{id}",
                new {Controller="Account", action = "Login", id = UrlParameter.Optional },
                new string[] { "OnlineShoping.Areas.Admin.Controllers" }
            );
        }
    }
}
