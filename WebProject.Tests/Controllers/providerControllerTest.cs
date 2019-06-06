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
    public class providerControllerTest
    {
        [TestMethod]
        public void providerTest()
        {
            providerController pc = new providerController();

            pc.InsertData("name1", "09111111", "add1", "des1");
            pc.InsertData("name2", "09111112", "add2", "des2");
            pc.InsertData("name3", "09111113", "add3", "des3");
            pc.SelectData(3);
            pc.UpdateData(3, "name3", "09111114", "add4", "des4");
            pc.DeleteData(1);
        }
    }
}
