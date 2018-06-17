using Fanpages.Areas.LoginPage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fanpages.Areas.LoginPage.Controllers
{
    public class LoginPagesController : Controller
    {

        private static List<Pagefb> lstPage;
        // GET: LoginPage/LoginPages
        public ActionResult Page()
        {
            UserFacebook user = (UserFacebook)Session["infoUser"];
            var fb = new Facebook.FacebookClient();
            fb.AccessToken = user.access_token;
            dynamic avatar = fb.Get("me/accounts?type=page");
            
            dynamic data = avatar.data;
            lstPage = new List<Models.Pagefb>();

            foreach (dynamic info in data)
            {
                Pagefb page = new Pagefb();
                page.pageId = info.id;
                page.accessToken = info.access_token;
                page.category = info.category;
                page.pageName = info.name;
                page.perms = info.perms;
                lstPage.Add(page);
            }
            ViewData.Add("pages", lstPage);
            return View();
        }

        [HttpPost]
        public ActionResult AcceptPages(Array data)
        {
            List<Pagefb> pages = new List<Pagefb>();
            foreach(var pagesId in data)
            {
                foreach(var page in lstPage)
                {
                    if (pagesId.Equals(page.pageId))
                    {
                        pages.Add(page);
                    }
                }
            }

            Session["pageInfo"] = pages;
            return Redirect("/Home/Index");
        }
    }
}