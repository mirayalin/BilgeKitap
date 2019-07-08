using System.Web.Mvc;

namespace MVCUI.Areas.MemberSpecial
{
    public class MemberSpecialAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "MemberSpecial";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "MemberSpecial_default",
                "MemberSpecial/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}