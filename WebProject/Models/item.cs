using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebPtoject.ExtraFunction;

namespace WebProject.Models
{


    public class item
    {
        public int id { get; set; }
        public int repository_code { get; set; }
        public int item_category_id { get; set; }
        public string name { get; set; }
        public int count { get; set; }
        public string buy_price { get; set; }
        public string sell_price { get; set; }
        public string buy_date { get; set; }
        public string description { get; set; }
    }

    public class itemS
    {
        public static List<item> SelectData(int id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "SELECT * FROM item WHERE Id = {0}";

            return db.Database.SqlQuery<item>(query, id).ToList<item>();
        }

        public static List<item> SelectAllData()
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "SELECT * FROM item";

            return db.Database.SqlQuery<item>(query).ToList<item>();
        }

        public static List<item> SelectAllData(int repository_code,int item_category_id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "SELECT * FROM item WHERE repository_code = {0} and item_category_id ={1}";

            return db.Database.SqlQuery<item>(query, repository_code, item_category_id).ToList<item>();
        }


        public static int InsertData(int repository_code, int item_category_id, string name, int count, string buy_price, string sell_price, string buy_date, string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "INSERT INTO [dbo].[item] ([repository_code] ,[item_category_id] ,[name] ,[count] ,[buy_price], [sell_price], [buy_date], [description] ) VALUES ({0},{1},{2},{3},{4},{5},{6},{7})";

            return db.Database.ExecuteSqlCommand(query, repository_code, item_category_id, name, count, buy_price, sell_price, buy_date, description);
        }

        public static int UpdateData(int id, int repository_code, int item_category_id, string name, int count, string buy_price, string sell_price, string buy_date, string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "UPDATE [dbo].[item] SET [repository_code]={1} ,[item_category_id]={2} ,[name]={3} ,[count]={4} ,[buy_price]={5},[sell_price]={6},[buy_date]={7},[description]={8} where id={0}";

            return db.Database.ExecuteSqlCommand(query, id, repository_code, item_category_id, name, count, buy_price, sell_price, buy_date, description);
        }


        public static int DeleteData(int id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "DELETE FROM [dbo].[item] where id={0}";

            return db.Database.ExecuteSqlCommand(query, id);
        }
    }
}