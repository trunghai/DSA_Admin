using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fanpages.Areas.LoginPage.Models
{
    public class UserFacebook
    {
        private string _access_token;
        private string _first_name;
        private string _last_name;
        private string _email;
        private string _user_id;
        private string _url_image;

       public string access_token
        {
            get { return _access_token; }
            set { _access_token = value; }
        }

        public string first_name
        {
            get { return _first_name; }
            set { _first_name = value; }
        }

        public string last_name
        {
            get { return _last_name; }
            set { _last_name = value; }
        }

        public string email
        {
            get { return _email; }
            set { _email = value; }
        }

        public string user_id
        {
            get { return _user_id; }
            set { _user_id = value; }
        }

        public string url_image
        {
            get { return url_image; }
            set { url_image = value; }
        }
    }
}