using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace WebPtoject.ExtraFunction
{
    public class SqlHandler
    {
        
        public string ConnectionString()
        {
            return (@"server=localhost,1433;database=repository;uid=sa;pwd=123;MultipleActiveResultSets=True;");


           // return (@"Data Source = (local); Initial Catalog = repository; User Id=sa;Password=123;Integrated Security=true");
        }

        public SqlConnection MySqlConnection()
        {
            SqlConnection myConnection = new SqlConnection();
            var x = ConnectionString();
            if (x != null)
            {
                myConnection.ConnectionString = x;
                return myConnection;
            }
            else
            {
                return null;
            }
        }


        


        public DataTable SqlSelect(string A)
        {
            DataTable myDataTable = new DataTable("data");
            try
            {
                if (A != null)
                {
                    if (A.Length > 0)
                    {
                        SqlConnection myConnection = MySqlConnection();
                        if (myConnection.State == ConnectionState.Closed)
                        {
                            myConnection.Open();
                        }

                        SqlCommand cmd = myConnection.CreateCommand();
                        cmd.CommandText = A;
                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        da.Fill(myDataTable);
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("err:SqlSelect:" + ex.Message + "(" + A + ")");
            }
            return myDataTable;
        }




        public bool SqlInsert(string Tabel, Dictionary<string, string> VALUES)
        {
            //try
            //{
            string strCommand = "";
            string strValue = "";
            string strUpdate = "";
            foreach (var x in VALUES.Keys)
            {
                strCommand += x + ",";
                strValue += VALUES[x] + ",";
                strUpdate += x + "=" + VALUES[x] + ",";
            }
            strCommand = strCommand.TrimEnd(',');
            strValue = strValue.TrimEnd(',');
            strUpdate = strUpdate.TrimEnd(',');

            string A = "INSERT INTO " + Tabel + " (" + strCommand + ") VALUES (" + strValue + ")";

            System.Diagnostics.Debug.WriteLine(A);
            SqlConnection myConnection = MySqlConnection();
            if (myConnection.State == ConnectionState.Closed)
            {
                myConnection.Open();
            }

            SqlCommand cmd = myConnection.CreateCommand();
            cmd.CommandText = A;
            SqlDataAdapter da = new SqlDataAdapter();
            da.InsertCommand = cmd;
            da.InsertCommand.ExecuteNonQuery();
            return true;
            //}
            //catch (Exception ex)
            //{
            //    System.Diagnostics.Debug.WriteLine("err:SqlInsert:" + ex.Message);
            //}
            //return false;
        }


        public bool SqlUpdate(string Tabel, Dictionary<string, string> VALUES, string Conditions)
        {
            try
            {
                string strCommand = "";
                string strValue = "";
                string strUpdate = "";
                foreach (var x in VALUES.Keys)
                {
                    strCommand += x + ",";
                    strValue += VALUES[x] + ",";
                    strUpdate += x + "=" + VALUES[x] + ",";
                }
                strCommand = strCommand.TrimEnd(',');
                strValue = strValue.TrimEnd(',');
                strUpdate = strUpdate.TrimEnd(',');

                string A = "UPDATE " + Tabel + " SET " + strUpdate + " where " + Conditions;
                System.Diagnostics.Debug.WriteLine(A);
                SqlConnection myConnection = MySqlConnection();
                if (myConnection.State == ConnectionState.Closed)
                {
                    myConnection.Open();
                }

                SqlCommand cmd = myConnection.CreateCommand();
                cmd.CommandText = A;
                SqlDataAdapter da = new SqlDataAdapter();
                da.UpdateCommand = cmd;
                da.UpdateCommand.ExecuteNonQuery();
                return true;

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("err:SqlUpdate:" + ex.Message);
            }
            return false;
        }


        public bool SqlDelete(string A)
        {
            try
            {
                if (A != null)
                {
                    if (A.Length > 0)
                    {
                        SqlConnection myConnection = new SqlConnection();
                        myConnection.ConnectionString = ConnectionString();
                        if (myConnection.State == ConnectionState.Closed)
                        {
                            myConnection.Open();
                        }

                        SqlCommand cmd = myConnection.CreateCommand();
                        cmd.CommandText = A;
                        SqlDataAdapter da = new SqlDataAdapter();
                        da.DeleteCommand = cmd;
                        da.DeleteCommand.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("err:SqlDelete:" + ex.Message + "(" + A + ")");
            }
            return false;
        }


        public string PersianDate(string decimalstring)
        {
            string dateP = "";


            if (decimalstring.Length >= 4)
            {
                dateP += decimalstring.Substring(0, 4);
            }
            if (decimalstring.Length >= 6)
            {
                dateP += "/" + decimalstring.Substring(4, 2);
            }
            if (decimalstring.Length >= 8)
            {
                dateP += "/" + decimalstring.Substring(6, 2);
            }
            if (decimalstring.Length >= 10)
            {
                dateP += " " + decimalstring.Substring(8, 2);
            }
            if (decimalstring.Length >= 12)
            {
                dateP += ":" + decimalstring.Substring(10, 2);
            }
            if (decimalstring.Length >= 14)
            {
                dateP += ":" + decimalstring.Substring(12, 2);
            }
            return dateP;
        }

    }


}