using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class orderController : Controller
    {
        // GET: order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Report()
        {
            ViewBag.Title = "گزارشگیری";
            ViewBag.Message = "گزارشگیری";

            var C = Models.customerS.SelectAllData();

            var D = Models.orderS.SelectAllData();

            var M = Models.itemS.SelectAllData();

            
            for (int i = 0; i < D.Count; i++)
            {
                List<string> K = new List<string>();
                var X1 = D[i].item_list.Split(',');
                var X2 = D[i].item_list.Split(',');
                for (int j = 0; j < X1.Count(); j++)
                {
                    K.Add(M.First(p => p.id.ToString().Equals(X1[j])).name + "(" + X2[j] + ")");
                }
                D[i].item_list = string.Join(",", K);
                D[i].customer_name = C.First(p => p.id.Equals(D[i].customer_id)).fname + " " + C.First(p => p.id.Equals(D[i].customer_id)).lname;
            }

            return View(D);
        }



        public ActionResult SelectData(int? id)
        {
            var T = Models.orderS.SelectData(id);
            return View(T);
        }

        public ActionResult InsertData(int customer_id, string item_list, string item_count, string date, string price, string description)
        {
            var T = Models.orderS.InsertData(customer_id, item_list, item_count, date, price, description);
            return View(T);
        }


        public ActionResult UpdateData(int id, int customer_id, string item_list, string item_count, string date, string price, string description)
        {
            var T = Models.orderS.UpdateData(id, customer_id, item_list, item_count, date, price, description);
            return View(T);
        }


        public ActionResult DeleteData(int id)
        {
            var T = Models.orderS.DeleteData(id);
            return View(T);
        }
    }
}