using Fanpages.Areas.LoginPage.Models;
using Fanpages.Common;
using Fanpages.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Fanpages.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            
            if(Session[CommonConstants.USER_LOGIN] == null)
            {
                return Redirect("/LoginPage/Index");
            }
            else
            {
                var user = (UserLoginInfo)Session[CommonConstants.USER_LOGIN];
                Console.WriteLine(user.url_image);
            }

            ViewBag.Title = "Home Page";

            List<Pagefb> lstpage = (List<Pagefb>)Session[CommonConstants.PAGE_LOGIN];
            Pagefb page = lstpage[0];
            var fb = new Facebook.FacebookClient();
            fb.AccessToken = page.accessToken;
            dynamic piture = fb.Get("me?fields=picture");
            dynamic feed = fb.Get("me/feed");
            page.image = piture.picture.data.url;

            List<Feeds> feeds = new List<Feeds>();
            foreach(var data in feed.data)
            {
                Feeds fe = new Feeds();
                fe.id = data.id;
                fe.message = data.message;
                fe.create_time = data.created_time;

                feeds.Add(fe);
            }

            ViewData.Add("feeds", feeds);
            ViewData.Add("page", page);

            return View();
        }

        [HttpGet]
        public JsonResult GetComment(string id)
        {
            UserLoginInfo user = (UserLoginInfo)Session[CommonConstants.USER_LOGIN];
            var fb = new Facebook.FacebookClient();
            fb.AccessToken = user.access_token;
            dynamic data = fb.Get(id + "/comments");

            List<Comment> comments = new List<Comment>();
            foreach(var com in data.data)
            {
                Comment comment = new Comment();
                Facebooker fa = new Facebooker();
                comment.id = com.id;
                comment.message = com.message;
                comment.created_time = com.created_time;
                fa.id = com.from.id;
                fa.name = com.from.name;

                dynamic dataImg = fb.Get(fa.id + "?fields=picture");
                fa.linkImg = dataImg.picture.data.url;


                comment.fbker = fa;

                comments.Add(comment);
            }

            return Json(new {data = comments }, JsonRequestBehavior.AllowGet);
        }
    }
}
