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
        public int customer_id { get; set; }
        public string item_list { get; set; }
        public string item_count { get; set; }
        public string date { get; set; }
        public string price { get; set; }
        public string description { get; set; }
    }


    public class orderS
    {
        public static List<repository> SelectData(int? id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "SELECT * FROM order WHERE Id = @id";

            return db.Database.SqlQuery<repository>(query, id).ToList<repository>();
        }


        public static int InsertData(string customer_id, string item_list, string item_count,string date,string price,string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "INSERT INTO [dbo].[order] ([customer_id] ,[item_list] ,[item_count] , [date] ,[price],[description] ) VALUES (@customer_id ,'@item_list', '@item_count','@date','@price','@description')";

            return db.Database.ExecuteSqlCommand(query, customer_id, item_list, item_count, date, price, description);
        }

        public static int UpdateData(string id, string customer_id, string item_list, string item_count, string date, string price, string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "UPDATE [dbo].[order] SET [customer_id]=@shop_category_id ,[item_list]='@name' ,[item_count]='@description',[date]='@date',[price]='@price',[description]='@description' where id=@id";

            return db.Database.ExecuteSqlCommand(query, id, customer_id, item_list, item_count, date, price, description);
        }


        public static int DeleteData(string id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "DELETE FROM [dbo].[order] where id=@id";

            return db.Database.ExecuteSqlCommand(query, id);
        }
    }
}