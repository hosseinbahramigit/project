using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebPtoject.ExtraFunction;

namespace WebProject.Models
{
    public class item_category
    {
        public int id { get; set; }
        public int shop_category_id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }


    public class item_categoryS
    {
        public static List<item_category> SelectData(int? id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "SELECT * FROM item_category WHERE Id = {0}";

            return db.Database.SqlQuery<item_category>(query, id).ToList<item_category>();
        }


        public static int InsertData(int shop_category_id, string name, string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "INSERT INTO [dbo].[item_category] ([shop_category_id] ,[name] ,[description]) VALUES ({0} ,{1}, {2})";

            return db.Database.ExecuteSqlCommand(query, shop_category_id, name, description);
        }

        public static int UpdateData(int id, int shop_category_id, string name, string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "UPDATE [dbo].[item_category] SET [shop_category_id]={1} ,[name]={2} ,[description]={3} where id={0}";

            return db.Database.ExecuteSqlCommand(query, id, shop_category_id, name, description);
        }


        public static int DeleteData(int id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "DELETE FROM [dbo].[item_category] where id={0}";

            return db.Database.ExecuteSqlCommand(query, id);
        }
    }
}