using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class order
    {
        public int id { get; set; }
        public int customer_id { get; set; }
        public string item_list { get; set; }
        public string item_count { get; set; }
        public string date { get; set; }
        public string price { get; set; }
        public string description { get; set; }
    }
}