using System.Web.Mvc;

namespace MVCUI.Areas.AdminSpecial
{
    public class AdminSpecialAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminSpecial";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "AdminSpecial_default",
                "AdminSpecial/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}