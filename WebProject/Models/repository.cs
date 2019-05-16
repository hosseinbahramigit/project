using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using WebPtoject.ExtraFunction;

namespace WebProject.Models
{

    public class repository
    {
        public int id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public string employee { get; set; }
        public string total_repository_count { get; set; }
        public string description { get; set; }
    }


    public class repositoryS
    {
        public static List<repository> SelectData(int? id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "SELECT * FROM Department WHERE Id = @id";

           return db.Database.SqlQuery<repository>(query, id).ToList<repository>();
        }


        public static int InsertData(string name,string address,string employee,string total_repository_count,string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "INSERT INTO [dbo].[repository] ([name] ,[address] ,[employee] ,[total_repository_count] ,[description]) VALUES ('@name' ,'@address' ,'@employee','@total_repository_count' ,'@description')";

            return db.Database.ExecuteSqlCommand(query, name, address, employee, total_repository_count, description);
        }

        public static int UpdateData(string id, string name, string address, string employee, string total_repository_count, string description)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "UPDATE [dbo].[repository] SET [name]='@name' ,[address]='@address' ,[employee]='@employee' ,[total_repository_count]='@total_repository_count' ,[description]='@description' where id=@id";

            return db.Database.ExecuteSqlCommand(query, id, name, address, employee, total_repository_count, description);
        }


        public static int DeleteData(string id)
        {
            SqlHandler sq = new SqlHandler();

            DbContext db = new DbContext(sq.ConnectionString());
            string query = "DELETE FROM [dbo].[repository] where id=@id";

            return db.Database.ExecuteSqlCommand(query, id);
        }
    }

}