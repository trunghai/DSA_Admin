using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fanpages.Models
{
    public class Feeds
    {
        private string _id;
        private string _message;
        private string _create_time;

        public string id
        {
            get { return _id; }
            set { _id = value; }
        }

        public string message
        {
            get { return _message; }
            set { _message = value; }
        }

        public string create_time
        {
            get { return _create_time; }
            set { _create_time = value; }
        }
    }
}