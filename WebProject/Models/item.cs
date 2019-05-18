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
        public static List<repository> SelectData(int? id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "SELECT * FROM item WHERE Id = @id";

            return db.Database.SqlQuery<repository>(query, id).ToList<repository>();
        }


        public static int InsertData(string repository_code, string item_category_id, string name, string count, string buy_price, string sell_price, string buy_date, string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "INSERT INTO [dbo].[item] ([repository_code] ,[item_category_id] ,[name] ,[count] ,[buy_price], [sell_price], [buy_date], [description] ) VALUES (@repository_code ,@item_category_id ,'@name',@count ,'@buy_price' , '@sell_price', '@buy_date' ,'@description')";

            return db.Database.ExecuteSqlCommand(query, repository_code, item_category_id, name, count, buy_price, sell_price, buy_date, description);
        }

        public static int UpdateData(string id, string repository_code, string item_category_id, string name, string count, string buy_price, string sell_price, string buy_date, string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "UPDATE [dbo].[item] SET [repository_code]=@repository_code ,[item_category_id]=@item_category_id ,[name]='@name' ,[count]=@count ,[buy_price]='@description',[sell_price]='@sell_price',[buy_date]='@buy_date',[description]='@description' where id=@id";

            return db.Database.ExecuteSqlCommand(query, id, repository_code, item_category_id, name, count, buy_price, sell_price, buy_date, description);
        }


        public static int DeleteData(string id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "DELETE FROM [dbo].[item] where id=@id";

            return db.Database.ExecuteSqlCommand(query, id);
        }
    }
}