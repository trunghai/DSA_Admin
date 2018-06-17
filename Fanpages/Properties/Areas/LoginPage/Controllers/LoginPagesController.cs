using Fanpages.Areas.LoginPage.Models;
using Fanpages.Common;
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
            UserLoginInfo user = (UserLoginInfo)Session[CommonConstants.USER_LOGIN];
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
        public JsonResult AcceptPages(Array data)
        {
            List<Pagefb> pages = new List<Pagefb>();
            foreach(string pagesId in data)
            {
                foreach(var page in lstPage)
                {
                    if (pagesId == page.pageId)
                    {
                        pages.Add(page);
                    }
                }
            }

            Session[CommonConstants.PAGE_LOGIN] = pages;
            return Json(new { eDesc = "success" });
        }
    }
}