using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class customerController : Controller
    {
        // GET: customer
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult Report()
        {
            ViewBag.Title = "گزارشگیری";
            ViewBag.Message = "گزارشگیری";

            var D = Models.customerS.SelectAllData();

            return View(D);
        }


        public ActionResult SelectData(int? id)
        {
            var T = Models.customerS.SelectData(id);
            return View(T);
        }

        public ActionResult InsertData(string fname, string lname, string age, string sex, string mobile, string address, string email, string credit, string created_date, string description)
        {
            var T = Models.customerS.InsertData(fname, lname, age, sex, mobile, address, email, credit, created_date, description);
            return View(T);
        }


        public ActionResult UpdateData(string id, string fname, string lname, string age, string sex, string mobile, string address, string email, string credit, string created_date, string description)
        {
            var T = Models.customerS.UpdateData(id, fname, lname, age, sex, mobile, address, email, credit, created_date, description);
            return View(T);
        }


        public ActionResult DeleteData(string id)
        {
            var T = Models.customerS.DeleteData(id);
            return View(T);
        }
    }
}