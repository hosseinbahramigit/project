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
        public static List<provider> SelectData(int? id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "SELECT * FROM [dbo].[provider] WHERE Id = {0}";

            return db.Database.SqlQuery<provider>(query, id).ToList<provider>();
        }


        public static int InsertData(string name, string phone, string address, string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "INSERT INTO [dbo].[provider] ([name] ,[phone] ,[address] , [description]) VALUES ({0} ,{1}, {2},{3})";

            return db.Database.ExecuteSqlCommand(query, name, phone, address, description);
        }

        public static int UpdateData(int id, string name, string phone, string address, string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "UPDATE [dbo].[provider] SET [name]={1} ,[phone]={2} ,[address]={3},[description]={4} where id={0}";

            return db.Database.ExecuteSqlCommand(query, id, name, phone, address, description);
        }


        public static int DeleteData(int id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "DELETE FROM [dbo].[provider] where id={0}";

            return db.Database.ExecuteSqlCommand(query, id);
        }
    }
}