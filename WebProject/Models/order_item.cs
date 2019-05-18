using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebPtoject.ExtraFunction;

namespace WebProject.Models
{
    public class order_item
    {
        public int order_id { get; set; }
        public int item_id { get; set; }
        public string count { get; set; }
        public string price { get; set; }
    }


    
}