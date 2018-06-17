using Fanpages.Areas.LoginPage.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fanpages.Areas.LoginPage.Controllers
{
    public class LoginFacebookController : Controller
    {
        private Uri RedirectUri
        {
            get
            {
                var uriBuilder = new UriBuilder(Request.Url);
                uriBuilder.Query = null;
                uriBuilder.Fragment = null;
                uriBuilder.Path = Url.Action("FacebookCallBack");
                return uriBuilder.Uri;
            }
        }

        // GET: LoginPage/LoginFacebook
        public ActionResult Index()
        {
            if(Session["infoUser"] != null)
            {
                return Redirect("/Login/Page");
            }
            else
            {
                return View();
            }
            
        }

        
        public ActionResult LoginFacebook()
        {
            var fb = new Facebook.FacebookClient();
            var loginUrl = fb.GetLoginUrl(new
            {
                client_id = ConfigurationManager.AppSettings["FBAppId"],
                client_secret = ConfigurationManager.AppSettings["FBSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                response_type = "code",
                scope = "email",
            });

            return Redirect(loginUrl.AbsoluteUri);
        }

        public ActionResult FacebookCallBack (string code)
        {
            var fb = new Facebook.FacebookClient();
            dynamic result = fb.Post("oauth/access_token", new {
                client_id = ConfigurationManager.AppSettings["FBAppId"],
                client_secret = ConfigurationManager.AppSettings["FBSecret"],
                redirect_uri = RedirectUri.AbsoluteUri,
                code = code,
            });

            var accessToken = result.access_token;

            if (!string.IsNullOrEmpty(accessToken))
            {
                fb.AccessToken = accessToken;
                dynamic me = fb.Get("me?fields=id,first_name,last_name,email");
                UserFacebook users = new UserFacebook();
                users.user_id = me.id;
                users.access_token = accessToken;
                users.email = me.email;
                users.first_name = me.first_name;
                users.last_name = me.last_name;

                Session.Add("infoUser", users);
            }
            else
            {
                
            }

            return Redirect("/Login/Page");
        }
    }
}