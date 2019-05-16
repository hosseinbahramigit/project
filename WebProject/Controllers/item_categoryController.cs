using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class item_categoryController : Controller
    {
        // GET: item_category
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SelectData(int? id)
        {
            var T = Models.itemS.SelectData(id);
            return View(T);
        }

        public ActionResult InsertData(string shop_category_id, string name, string description)
        {
            var T = Models.item_categoryS.InsertData(shop_category_id, name, description);
            return View(T);
        }


        public ActionResult UpdateData(string id, string shop_category_id, string name, string description)
        {
            var T = Models.item_categoryS.UpdateData(id, shop_category_id, name, description);
            return View(T);
        }


        public ActionResult DeleteData(string id)
        {
            var T = Models.item_categoryS.DeleteData(id);
            return View(T);
        }
    }
}