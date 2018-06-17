using System.Web.Mvc;

namespace Fanpages.Areas.LoginPage
{
    public class LoginPageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "LoginPage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
               "Login",
               "Login/{action}/{id}",
                   new { controller = "LoginPages", action = "Page", id = UrlParameter.Optional }
               //HelpPageConfig.Register(GlobalConfiguration.Configuration);
               );

            context.MapRoute(
                "LoginFacebook_default",
                "LoginPage/{action}/{id}",
                new { controller = "LoginFacebook", action = "Index", id = UrlParameter.Optional }
                 //HelpPageConfig.Register(GlobalConfiguration.Configuration);
            );
         
        }
    }

}