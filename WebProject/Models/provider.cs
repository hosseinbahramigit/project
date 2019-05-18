using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebPtoject.ExtraFunction;

namespace WebProject.Models
{
    public class provider
    {
        public int id { get; set; }
        public string name { get; set; }
        public string phone { get; set; }
        public string address { get; set; }
        public string description { get; set; }
    }


    public class providerS
    {
        public static List<repository> SelectData(int? id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "SELECT * FROM provider WHERE Id = @id";

            return db.Database.SqlQuery<repository>(query, id).ToList<repository>();
        }


        public static int InsertData(string name, string phone, string address, string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "INSERT INTO [dbo].[provider] ([name] ,[phone] ,[address] , [description]) VALUES ('@name' ,'@phone', '@address','@description')";

            return db.Database.ExecuteSqlCommand(query, name, phone, address, description);
        }

        public static int UpdateData(string id, string name, string phone, string address, string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "UPDATE [dbo].[provider] SET [name]='@name' ,[phone]='@phone' ,[address]='@address',[description]='@description' where id=@id";

            return db.Database.ExecuteSqlCommand(query, id, name, phone, address, description);
        }


        public static int DeleteData(string id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "DELETE FROM [dbo].[provider] where id=@id";

            return db.Database.ExecuteSqlCommand(query, id);
        }
    }
}