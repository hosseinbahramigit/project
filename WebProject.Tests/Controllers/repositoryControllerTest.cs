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
    public class repositoryControllerTest
    {
        [TestMethod]
        public void repositoryTest()
        {
            repositoryController rc = new repositoryController();
            rc.InsertData("name1", "add1", "emp1", "100", "des1");
            rc.InsertData("name2", "add2", "emp2", "200", "des2");
            rc.InsertData("name3", "add3", "emp3", "300", "des3");
            rc.SelectData(3);
            rc.UpdateData(3, "name3", "add4", "emp4", "400", "des4");
            rc.DeleteData(1);
        }
    }
}
