using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebPtoject.ExtraFunction;

namespace WebProject.Models
{
    public class customer
    {
        public int id { get; set; }
        public string fname { get; set; }
        public string lname { get; set; }
        public int age { get; set; }
        public int sex { get; set; }
        public string mobile { get; set; }
        public string address { get; set; }
        public string email { get; set; }
        public string credit { get; set; }
        public string created_date { get; set; }
        public string description { get; set; }
    }


    public class customerS
    {
        public static List<repository> SelectData(int? id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "SELECT * FROM customer WHERE Id = @id";

            return db.Database.SqlQuery<repository>(query, id).ToList<repository>();
        }


        public static int InsertData(string fname, string lname, string age, string sex, string mobile, string address, string email, string credit, string created_date, string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "INSERT INTO [dbo].[customer] ([query] ,[fname] ,[lname] ,[age] ,[sex], [mobile], [address], [email],[credit],[created_date],[description] ) VALUES (@query ,@fname ,'@lname', @age ,@sex , '@mobile', '@address' ,'@email','@credit','@created_date','@description')";

            return db.Database.ExecuteSqlCommand(query, fname, lname, age, sex, mobile, address, email, credit, created_date, description);
        }

        public static int UpdateData(string id, string fname, string lname, string age, string sex, string mobile, string address, string email, string credit, string created_date, string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "UPDATE [dbo].[customer] SET [fname]='@fname' ,[lname]='@lname' ,[age]=@age ,[sex]=@sex ,[mobile]='@mobile',[address]='@address',[email]='@email',[credit]='@credit',[created_date]='@created_date',[description]='@description' where id=@id";

            return db.Database.ExecuteSqlCommand(query, id, fname, lname, age, sex, mobile, address, email, credit, created_date, description);
        }


        public static int DeleteData(string id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "DELETE FROM [dbo].[customer] where id=@id";

            return db.Database.ExecuteSqlCommand(query, id);
        }
    }
}