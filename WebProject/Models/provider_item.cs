using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebProject.Models
{
    public class provider_item
    {
        public int provider_id { get; set; }
        public int item_id { get; set; }
        public string count { get; set; }
        public string item_count { get; set; }
        public string total_count { get; set; }
    }
}