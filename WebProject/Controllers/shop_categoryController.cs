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




        public ActionResult Report(string reportName1, string reportName2)
        {
            ViewBag.Title = "گزارشگیری";
            ViewBag.Message = "گزارشگیری";

            Models.DataAllInformation D = new Models.DataAllInformation();
            D.shop_category = Models.shop_categoryS.SelectAllData();
            D.repository = Models.repositoryS.SelectAllData();


            System.Diagnostics.Debug.WriteLine("reportName1=" + reportName1 + "  reportName2=" + reportName2);

            if (reportName1 != null & reportName2 != null)
            {
                if (reportName1.Length > 0 & reportName2.Length > 0)
                {
                    D.item = Models.itemS.SelectAllData(Convert.ToInt16(reportName1), Convert.ToInt16(reportName2));
                }
            }

            return View(D);
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


        public ActionResult UpdateData(int id, string name, string description)
        {
            var T = Models.shop_categoryS.UpdateData(id, name, description);
            return View(T);
        }


        public ActionResult DeleteData(int id)
        {
            var T = Models.shop_categoryS.DeleteData(id);
            return View(T);
        }
    }
}