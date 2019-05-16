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
        public static List<repository> SelectData(int? id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "SELECT * FROM item_category WHERE Id = @id";

            return db.Database.SqlQuery<repository>(query, id).ToList<repository>();
        }


        public static int InsertData(string shop_category_id, string name, string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "INSERT INTO [dbo].[item_category] ([shop_category_id] ,[name] ,[description]) VALUES (@shop_category_id ,'@name', '@description')";

            return db.Database.ExecuteSqlCommand(shop_category_id, name, description);
        }

        public static int UpdateData(string id, string shop_category_id, string name, string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "UPDATE [dbo].[item_category] SET [shop_category_id]=@shop_category_id ,[name]='@name' ,[description]='@description' where id=@id";

            return db.Database.ExecuteSqlCommand(query, id, shop_category_id, name, description);
        }


        public static int DeleteData(string id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "DELETE FROM [dbo].[item_category] where id=@id";

            return db.Database.ExecuteSqlCommand(query, id);
        }
    }
}