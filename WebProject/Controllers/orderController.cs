using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebProject.Controllers
{
    public class orderController : Controller
    {
        // GET: order
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Report()
        {
            ViewBag.Title = "گزارشگیری";
            ViewBag.Message = "گزارشگیری";

            var C = Models.customerS.SelectAllData();

            var D = Models.orderS.SelectAllData();

            var M = Models.itemS.SelectAllData();

            
            for (int i = 0; i < D.Count; i++)
            {
                List<string> K = new List<string>();
                var X1 = D[i].item_list.Split(',');
                var X2 = D[i].item_list.Split(',');
                for (int j = 0; j < X1.Count(); j++)
                {
                    K.Add(M.First(p => p.id.ToString().Equals(X1[j])).name + "(" + X2[j] + ")");
                }
                D[i].item_list = string.Join(",", K);
                D[i].customer_name = C.First(p => p.id.Equals(D[i].customer_id)).fname + " " + C.First(p => p.id.Equals(D[i].customer_id)).lname;
            }

            return View(D);
        }



        public ActionResult orderpage(string buyName0, string buyName1, string buyName2, string buyName3)
        {
            ViewBag.Title = "خرید";
            ViewBag.Message = "خرید";
 
            Models.DataAllInformationorder DAIO = new Models.DataAllInformationorder();
            DAIO.items = Models.itemS.SelectAllData();
            DAIO.customers = Models.customerS.SelectAllData();
            DAIO.repositorys = Models.repositoryS.SelectAllData();
            DAIO.Message = "";
            DAIO.MessageError = "";


            if (buyName0 != null & buyName1 != null & buyName2 != null & buyName3 != null)
            {
                try
                {

                    System.Diagnostics.Debug.WriteLine("buyName0=" + buyName0.ToString());
                    System.Diagnostics.Debug.WriteLine("buyName1=" + buyName1.ToString());
                    System.Diagnostics.Debug.WriteLine("buyName2=" + buyName2.ToString());
                    System.Diagnostics.Debug.WriteLine("buyName3=" + buyName3.ToString());
                    //System.Diagnostics.Debug.WriteLine(DAIO.items.First(p => p.id.ToString().Equals(buyName2) & p.repository_code.ToString().Equals(buyName0)).count.ToString());

                    if (Convert.ToDouble(buyName3) <= 0)
                    {
                        DAIO.MessageError = "تعداد وارد شده صحیح نمی باشد";
                    }
                    else
                    {
                        if (DAIO.items.Count(p => p.id.ToString().Equals(buyName2) & p.repository_code.ToString().Equals(buyName0)) == 0)
                        {
                            DAIO.MessageError = "در این انبار کالای موردنظر موجود نمی باشد.";
                        }
                        else
                        {
                            if (DAIO.items.First(p => p.id.ToString().Equals(buyName2) & p.repository_code.ToString().Equals(buyName0)).count < Convert.ToInt32(buyName3))
                            {
                                DAIO.MessageError = "تعداد مورد نظر در این انبار از کالای خواسته شده موجود نمی باشد";
                            }
                        }
                    }

                    if (DAIO.MessageError.Length == 0)
                    {
                        DateTime dt = new DateTime();
                        string DATE = dt.Year.ToString("0000") + dt.Month.ToString("00") + dt.Day.ToString("00") + dt.Hour.ToString("00") + dt.Minute.ToString("00") + dt.Second.ToString("00");

                        string Price = (Convert.ToDouble(DAIO.items.First(p => p.id.ToString().Equals(buyName2) & p.repository_code.ToString().Equals(buyName0)).sell_price) * Convert.ToDouble(buyName3)).ToString();

                        Models.orderS.InsertData(Convert.ToInt32(buyName1), buyName2, buyName3, DATE, Price, "");
                        var R = DAIO.items.First(p => p.id.ToString().Equals(buyName2) & p.repository_code.ToString().Equals(buyName0));
                        Models.itemS.UpdateData(R.id, R.repository_code, R.item_category_id, R.name, R.count - Convert.ToInt16(buyName3), R.buy_price, R.sell_price, R.buy_date, R.description);
                        DAIO.Message = "خرید انجام شد";
                    }

                    if (DAIO.MessageError.Length > 0)
                    {
                        DAIO.Current_repositorys = Convert.ToInt16(buyName0);
                        DAIO.Current_customers = Convert.ToInt16(buyName1);
                        DAIO.Current_items = Convert.ToInt16(buyName2);
                        DAIO.Current_Count = Convert.ToInt16(buyName3);
                    }
                }
                catch
                {
                    DAIO.MessageError = "اطلاعات وارد شده صحیح نمی باشد";
                    DAIO.Current_repositorys = Convert.ToInt16(buyName0);
                    DAIO.Current_customers = Convert.ToInt16(buyName1);
                    DAIO.Current_items = Convert.ToInt16(buyName2);
                    DAIO.Current_Count = Convert.ToInt16(buyName3);
                }
            }
            

            return View(DAIO);
        }



        public ActionResult SelectData(int? id)
        {
            var T = Models.orderS.SelectData(id);
            return View(T);
        }

        public ActionResult InsertData(int customer_id, string item_list, string item_count, string date, string price, string description)
        {
            var T = Models.orderS.InsertData(customer_id, item_list, item_count, date, price, description);
            return View(T);
        }


        public ActionResult UpdateData(int id, int customer_id, string item_list, string item_count, string date, string price, string description)
        {
            var T = Models.orderS.UpdateData(id, customer_id, item_list, item_count, date, price, description);
            return View(T);
        }


        public ActionResult DeleteData(int id)
        {
            var T = Models.orderS.DeleteData(id);
            return View(T);
        }
    }
}