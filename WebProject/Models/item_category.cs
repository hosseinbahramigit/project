﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class item_category
    {
        public int id { get; set; }
        public int shop_category_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }
}