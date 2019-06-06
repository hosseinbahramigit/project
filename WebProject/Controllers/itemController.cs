using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class itemController : Controller
    {
        // GET: item
        public ActionResult Index()
        {
            return View();
        }



        public ActionResult SelectData(int id)
        {

            var T = Models.itemS.SelectData(id);
            return View(T);
        }

        public ActionResult InsertData(int repository_code, int item_category_id, string name, int count, string buy_price, string sell_price, string buy_date, string description)
        {
            var T = Models.itemS.InsertData(repository_code, item_category_id, name, count, buy_price, sell_price, buy_date, description);
            return View(T);
        }


        public ActionResult UpdateData(int id, int repository_code, int item_category_id, string name, int count, string buy_price, string sell_price, string buy_date, string description)
        {
            var T = Models.itemS.UpdateData(id, repository_code, item_category_id, name, count, buy_price, sell_price, buy_date, description);
            return View(T);
        }


        public ActionResult DeleteData(int id)
        {
            var T = Models.itemS.DeleteData(id);
            return View(T);
        }
    }
}