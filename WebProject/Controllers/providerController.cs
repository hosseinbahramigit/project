using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class providerController : Controller
    {
        // GET: provider
        public ActionResult Index()
        {
            return View();
        }


        public ActionResult SelectData(int? id)
        {
            var T = Models.providerS.SelectData(id);
            return View(T);
        }

        public ActionResult InsertData(string name, string phone, string address, string description)
        {
            var T = Models.providerS.InsertData(name, phone, address, description);
            return View(T);
        }


        public ActionResult UpdateData(int id, string name, string phone, string address, string description)
        {
            var T = Models.providerS.UpdateData(id, name, phone, address, description);
            return View(T);
        }


        public ActionResult DeleteData(int id)
        {
            var T = Models.providerS.DeleteData(id);
            return View(T);
        }
    }
}