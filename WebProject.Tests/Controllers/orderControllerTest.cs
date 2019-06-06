using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebProject;
using WebProject.Controllers;

namespace WebProject.Tests.Controllers
{
    [TestClass]
    public class orderControllerTest
    {
        [TestMethod]
        public void orderTest()
        {
            orderController oc = new orderController();


            DateTime dt = DateTime.Now;
            string currentDate = dt.Year.ToString("0000") + dt.Month.ToString("00") + dt.Day.ToString("00") + dt.Hour.ToString("00") + dt.Minute.ToString("00") + dt.Second.ToString("00");


            oc.InsertData(1, "1,2,3", "10,20,30", currentDate, "3000", "des1");
            oc.InsertData(2, "4,5", "10,20", currentDate, "2000", "des2");
            oc.InsertData(3, "6", "10", currentDate, "1000", "des3");
            oc.SelectData(3);
            oc.UpdateData(3, 3, "6,8", "10,20", currentDate, "3000", "des3");
            oc.DeleteData(1);
        }
    }
}
