using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fanpages.Areas.LoginPage.Models
{
    [Serializable]
    public class Pagefb
    {
        private string _pageId;
        private string _accessToken;
        private string _category;
        private string _pageName;
        private dynamic _perms;
        private string _image;

        public string pageId
        {
            get { return _pageId; }
            set { _pageId = value; }
        }

        public string accessToken
        {
            get { return _accessToken; }
            set { _accessToken = value; }
        }

        public string category
        {
            get { return _category; }
            set { _category = value; }
        }

        public string pageName
        {
            get { return _pageName; }
            set { _pageName = value; }
        }

        public dynamic perms
        {
            get { return _perms; }
            set { _perms = value; }
        }

        public string image
        {
            get { return _image; }
            set { _image = value; }
        }
    }
}