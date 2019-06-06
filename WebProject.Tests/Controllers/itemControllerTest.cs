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
    public class itemControllerTest
    {
        [TestMethod]
        public void itemTest()
        {
            itemController ic = new itemController();

            DateTime dt = DateTime.Now;
            string currentDate = dt.Year.ToString("0000") + dt.Month.ToString("00") + dt.Day.ToString("00") + dt.Hour.ToString("00") + dt.Minute.ToString("00") + dt.Second.ToString("00");
   
            ic.InsertData(1001, 1, "device1", 10, "1000", "1100", currentDate, "des1");
            ic.InsertData(1002, 1, "device2", 20, "2000", "2100", currentDate, "des2");
            ic.InsertData(1003, 1, "device3", 30, "3000", "3100", currentDate, "des3");
            ic.SelectData(3);
            ic.UpdateData(3, 1003, 1, "device3", 30, "4000", "4100", currentDate, "des3");
            ic.DeleteData(1);
        }
    }
}
