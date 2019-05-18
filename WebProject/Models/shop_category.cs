using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebPtoject.ExtraFunction;

namespace WebProject.Models
{
    public class shop_category
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
    }


    public class shop_categoryS
    {
        public static List<repository> SelectData(int? id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "SELECT * FROM shop_category WHERE Id = @id";

            return db.Database.SqlQuery<repository>(query, id).ToList<repository>();
        }


        public static int InsertData(string name, string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "INSERT INTO [dbo].[shop_category] ([name] ,[description]) VALUES ('@name' ,'@description')";

            return db.Database.ExecuteSqlCommand(query, name, description);
        }

        public static int UpdateData(string id, string name, string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "UPDATE [dbo].[shop_category] SET [name]='@name' ,[description]='@item_category_id' where id=@id";

            return db.Database.ExecuteSqlCommand(query, id, name, description);
        }


        public static int DeleteData(string id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "DELETE FROM [dbo].[shop_category] where id=@id";

            return db.Database.ExecuteSqlCommand(query, id);
        }
    }
}