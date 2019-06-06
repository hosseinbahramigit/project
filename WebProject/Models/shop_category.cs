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


    public class DataAllInformation
    {
        public List<Models.shop_category> shop_category { get; set; }
        public List<Models.repository> repository { get; set; }
        public List<Models.item> item { get; set; }
        public DataAllInformation()
        {
            this.shop_category = new List<Models.shop_category>();
            this.repository = new List<Models.repository>();
            this.item = new List<Models.item>();
        }
    }

    public class shop_categoryS
    {
        public static List<shop_category> SelectData(int? id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "SELECT * FROM  [dbo].[shop_category] WHERE Id = {0}";

            return db.Database.SqlQuery<shop_category>(query, id).ToList<shop_category>();
        }


        public static List<shop_category> SelectAllData()
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "SELECT * FROM  [dbo].[shop_category]";

            return db.Database.SqlQuery<shop_category>(query).ToList<shop_category>();
        }


        public static int InsertData(string name, string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "INSERT INTO [dbo].[shop_category] ([name] ,[description]) VALUES ({0} ,{1})";

            return db.Database.ExecuteSqlCommand(query, name, description);
        }

        public static int UpdateData(int id, string name, string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "UPDATE [dbo].[shop_category] SET [name]={1} ,[description]={2} where id={0}";

            return db.Database.ExecuteSqlCommand(query, id, name, description);
        }


        public static int DeleteData(int id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "DELETE FROM [dbo].[shop_category] where id={0}";

            return db.Database.ExecuteSqlCommand(query, id);
        }
    }
}