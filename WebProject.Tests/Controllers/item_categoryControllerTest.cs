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
    public class item_categoryControllerTest
    {
        [TestMethod]
        public void item_categoryTest()
        {
            item_categoryController icc = new item_categoryController();

            DateTime dt = DateTime.Now;
            string currentDate = dt.Year.ToString("0000") + dt.Month.ToString("00") + dt.Day.ToString("00") + dt.Hour.ToString("00") + dt.Minute.ToString("00") + dt.Second.ToString("00");

            icc.InsertData(1, "cat1", "des1");
            icc.InsertData(2, "cat2", "des2");
            icc.InsertData(3, "cat3", "des3");
            icc.SelectData(3);
            icc.UpdateData(3, 3, "cat3", "des3");
            icc.DeleteData(1);

        }
    }
}
