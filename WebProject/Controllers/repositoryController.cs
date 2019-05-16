using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebPtoject.ExtraFunction;

namespace WebProject.Controllers
{
    public class repositoryController : Controller
    {
        // GET: repository
        public ActionResult Index()
        {             
            return View();
        }

        public ActionResult SelectData(int? id)
        {
            var T= Models.repositoryS.SelectData(id);
            return View(T);
        }

        public ActionResult InsertData(string name, string address, string employee, string total_repository_count, string description)
        {
            var T = Models.repositoryS.InsertData(name, address, employee, total_repository_count, description);
            return View(T);
        }


        public ActionResult UpdateData(string id, string name, string address, string employee, string total_repository_count, string description)
        {
            var T = Models.repositoryS.UpdateData(id, name, address, employee, total_repository_count, description);
            return View(T);
        }


        public ActionResult DeleteData(string id)
        {
            var T = Models.repositoryS.DeleteData(id);
            return View(T);
        }
    }
}