using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fanpages.Models
{
    public class Comment
    {
        private string _created_time;
        private Facebooker _fbker;
        private string _id;
        private string _message;

        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

        public Facebooker fbker
        {
            get { return _fbker; }
            set { _fbker = value; }
        }

        public string created_time
        {
            get { return _created_time; }
            set { _created_time = value; }
        }

        public string message
        {
            get { return _message; }
            set { _message = value; }
        }
    }
}