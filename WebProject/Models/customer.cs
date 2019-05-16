using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class customer
    {
        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public int age { get; set; }
        public int sex { get; set; }
        public string mobile { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string credit { get; set; }
        public string created_date { get; set; }
        public string description { get; set; }
    }
}