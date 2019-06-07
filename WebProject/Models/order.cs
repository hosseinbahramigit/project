using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebPtoject.ExtraFunction;

namespace WebProject.Models
{
    public class order
    {
        public int id { get; set; }
        public string customer_name { get; set; }
        public int customer_id { get; set; }
        public string item_list { get; set; }
        public string item_count { get; set; }
        public string date { get; set; }
        public string price { get; set; }
        public string description { get; set; }
    }


    public class DataAllInformationorder
    {
        public List<Models.customer> customers { get; set; }
        public List<Models.repository> repositorys { get; set; }
        public List<Models.item> items { get; set; }
        public string Message { get; set; }
        public string MessageError { get; set; }

        public int Current_customers { get; set; }
        public int Current_repositorys { get; set; }
        public int Current_items { get; set; }
        public int Current_Count { get; set; }

        public DataAllInformationorder()
        {
            this.Current_Count = 0;
            this.Current_customers = 0;
            this.Current_repositorys = 0;
            this.Current_items = 0;
            this.Message = "";
            this.MessageError = "";
            this.repositorys = new List<Models.repository>();
            this.customers = new List<Models.customer>();
            this.items = new List<Models.item>();
        }
    }



    public class orderS
    {
        public static List<order> SelectData(int? id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "SELECT * FROM [dbo].[order] WHERE Id = {0}";

            return db.Database.SqlQuery<order>(query, id).ToList<order>();
        }

        public static List<order> SelectAllData()
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "SELECT * FROM [dbo].[order]";

            return db.Database.SqlQuery<order>(query).ToList<order>();
        }


        public static int InsertData(int customer_id, string item_list, string item_count,string date,string price,string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "INSERT INTO [dbo].[order] ([customer_id] ,[item_list] ,[item_count] , [date] ,[price],[description] ) VALUES ({0} ,{1}, {2},{3},{4},{5})";

            return db.Database.ExecuteSqlCommand(query, customer_id, item_list, item_count, date, price, description);
        }

        public static int UpdateData(int id, int customer_id, string item_list, string item_count, string date, string price, string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "UPDATE [dbo].[order] SET [customer_id]={1} ,[item_list]={2} ,[item_count]={3},[date]={4},[price]={5},[description]={6} where id={0}";

            return db.Database.ExecuteSqlCommand(query, id, customer_id, item_list, item_count, date, price, description);
        }


        public static int DeleteData(int id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "DELETE FROM [dbo].[order] where id={0}";

            return db.Database.ExecuteSqlCommand(query, id);
        }
    }
}