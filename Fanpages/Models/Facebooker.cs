using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fanpages.Models
{
    public class Facebooker
    {
        private string _id;
        private string _name;
        private string _linkImg;

        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string name
        {
            get { return _name; }
            set { _name = value; }
        }

        public string linkImg
        {
            get { return _linkImg; }
            set { _linkImg = value; }
        }
    }
}