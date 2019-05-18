using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class shop_categoryController : Controller
    {
        // GET: shop_category
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SelectData(int? id)
        {
            var T = Models.shop_categoryS.SelectData(id);
            return View(T);
        }

        public ActionResult InsertData(string name, string description)
        {
            var T = Models.shop_categoryS.InsertData(name, description);
            return View(T);
        }


        public ActionResult UpdateData(string id, string name, string description)
        {
            var T = Models.shop_categoryS.UpdateData(id, name, description);
            return View(T);
        }


        public ActionResult DeleteData(string id)
        {
            var T = Models.shop_categoryS.DeleteData(id);
            return View(T);
        }
    }
}