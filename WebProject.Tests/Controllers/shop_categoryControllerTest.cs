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
    public class shop_categoryControllerTest
    {
        [TestMethod]
        public void shop_categoryTest()
        {
            shop_categoryController scc = new shop_categoryController();


            scc.InsertData("name1", "des1");
            scc.InsertData("name2", "des2");
            scc.InsertData("name3", "des3");
            scc.SelectData(3);
            scc.UpdateData(3, "name4", "des4");
            scc.DeleteData(1);

        }
    }
}
