using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Data;
using System.Data.SqlClient;

namespace AJSGame.Core
{
    public class SQL
    {
        private static SqlConnection conn;

        public static bool Exists(string tableName, string whereClause)
        {
            bool result;
            try
            {
                using (conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AJSGameConnectionString"].ConnectionString))
                {
                    conn.Open();
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    SqlCommand comm = new SqlCommand();
                    string str = "SELECT COUNT(*) FROM " + tableName + " WHERE " + whereClause;
                    comm.CommandText = str;
                    comm.Connection = conn;
                    string str2 = comm.ExecuteScalar().ToString();
                    conn.Close();
                    comm.Dispose();
                    if (Convert.ToInt32(str2) >= 1)
                        result = true;
                    else
                        result = false;
                }
            }
            catch
            {
                result = false;
            }
            return result;
        }

        public static Hashtable DeleteData(string tableName, string whereClause)
        {
            Hashtable hashtable = new Hashtable();
            try
            {
                using (conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AJSGameConnectionString"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = "DELETE FROM " + tableName + " WHERE " + whereClause;
                    comm.Connection = conn;
                    comm.ExecuteNonQuery();
                    conn.Close();
                    comm.Dispose();
                }
            }
            catch (Exception e)
            {
                hashtable.Add("Error", e.Message);
            }
            return hashtable;
        }

        public static DataSet ExecuteDataset(string sqlCommand)
        {
            DataSet ds;
            try
            {
                using (conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AJSGameConnectionString"].ConnectionString))
                {
                    conn.Open();
                    DataSet dataSet = new DataSet();
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = sqlCommand;
                    comm.Connection = conn;
                    da.SelectCommand = comm;
                    da.Fill(dataSet);
                    ds = dataSet;
                }
            }
            catch (Exception)
            {
                ds = null;
            }
            return ds;
        }

        public static Hashtable ExecuteSQL(string sqlCommand)
        {
            Hashtable hashtable = new Hashtable();
            try
            {
                using (conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AJSGameConnectionString"].ConnectionString))
                {
                    conn.Open();
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = sqlCommand;
                    comm.Connection = conn;
                    hashtable.Add("Value", comm.ExecuteScalar());
                    conn.Close();
                    comm.Dispose();
                }
            }
            catch (Exception e)
            {
                hashtable.Add("Error", e.Message);
            }
            return hashtable;
        }

        public static Hashtable ExecuteWithParameter(string sqlCommand, Dictionary<string, object> parameters)
        {
            Hashtable hashtable = new Hashtable();
            try
            {
                using (conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AJSGameConnectionString"].ConnectionString))
                {
                    conn.Open();
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand comm = new SqlCommand();
                    comm.CommandText = sqlCommand;
                    comm.Connection = conn;
                    da.SelectCommand = comm;
                    foreach (KeyValuePair<string, object> pair in parameters)
                    {
                        SqlParameter param = new SqlParameter();
                        param.ParameterName = pair.Key;
                        param.Value = pair.Value;
                        comm.Parameters.Add(param);
                    }
                    da.Fill(ds);
                    da.Fill(dt);
                    hashtable.Add("Command", comm.CommandText);
                    hashtable.Add("DataSet", ds);
                    hashtable.Add("DataTable", dt);
                    hashtable.Add("DataCount", ds.Tables[0].Rows.Count);
                    conn.Close();
                    da.Dispose();
                    comm.Dispose();
                }
            }
            catch (Exception e)
            {
                hashtable.Add("Error", e.Message);
            }
            return hashtable;
        }

        public static Hashtable SecureQuery(string tableName, Hashtable whereClause, string orderBy, string columns)
        {
            Hashtable hashtable = new Hashtable();
            try
            {
                using (conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AJSGameConnectionString"].ConnectionString))
                {
                    conn.Open();
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    comm.CommandText = "SELECT " + columns + " FROM " + tableName + " {0} " + orderBy;
                    string str = "";
                    int num = 0;
                    foreach (string str2 in whereClause.Keys)
                    {
                        if (str2[0] != '@')
                        {
                            if ((num / 2) == 0)
                            {
                                object obj2 = str;
                                str = string.Concat(new object[] { obj2, " ", whereClause["@" + num], " " });
                            }
                            string str4 = str;
                            str = str4 + "[" + str2 + "] = @" + str2 + " ";
                            num++;
                            SqlParameter param = new SqlParameter();
                            param.ParameterName = "@" + str2;
                            param.Value = whereClause[str2];
                            comm.Parameters.Add(param);
                        }
                    }
                    str = "WHERE " + str;
                    string str3 = string.Format(comm.CommandText, str);
                    comm.CommandText = str3;
                    da.SelectCommand = comm;
                    da.Fill(ds);
                    da.Fill(dt);
                    hashtable.Add("DataSet", ds);
                    hashtable.Add("DataTable", dt);
                    hashtable.Add("DataCount", ds.Tables[0].Rows.Count);
                    conn.Close();
                    da.Dispose();
                    comm.Dispose();
                }
            }
            catch (Exception e)
            {
                hashtable.Add("Error", e.Message);
            }
            return hashtable;
        }

        public static Hashtable SimpleQuery(string tableName, string whereClause, string orderBy, string columns)
        {
            Hashtable hashtable = new Hashtable();
            try
            {
                using (conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AJSGameConnectionString"].ConnectionString))
                {
                    conn.Open();
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    SqlDataAdapter da = new SqlDataAdapter();
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    string str = "SELECT " + columns + " FROM " + tableName + " " + whereClause + " " + orderBy;
                    comm.CommandText = str;
                    da.SelectCommand = comm;
                    da.Fill(ds);
                    da.Fill(dt);
                    hashtable.Add("DataSet", ds);
                    hashtable.Add("DataTable", dt);
                    hashtable.Add("DataCount", ds.Tables[0].Rows.Count);
                    conn.Close();
                    da.Dispose();
                    comm.Dispose();
                }
            }
            catch (Exception e)
            {
                hashtable.Add("Error", e.Message);
            }
            return hashtable;
        }

        public static string TextQuery(string tableName, string whereClause, string orderBy, string columns)
        {
            string str3;
            try
            {
                using (conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AJSGameConnectionString"].ConnectionString))
                {
                    conn.Open();
                    DataSet ds = new DataSet();
                    DataTable dt = new DataTable();
                    SqlCommand comm = new SqlCommand();
                    string str = "SELECT " + columns + " FROM " + tableName + " " + whereClause + " " + orderBy;
                    comm.CommandText = str;
                    comm.Connection = conn;
                    string str2 = comm.ExecuteScalar().ToString();
                    conn.Close();
                    comm.Dispose();
                    str3 = str2;
                }
            }
            catch
            {
                str3 = "<! error !>";
            }
            return str3;
        }

        public static Hashtable InsertData(string tableName, Hashtable columnValues)
        {
            Hashtable hashtable2;
            Hashtable hashtable = new Hashtable();
            try
            {
                using (conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AJSGameConnectionString"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    string str = "";
                    string str2 = "";
                    int num = 0;
                    foreach (string str3 in columnValues.Keys)
                    {
                        num++;
                        str2 = str2 + "[" + str3 + "]";
                        str = str + "@" + str3;
                        if (num != columnValues.Keys.Count)
                        {
                            str2 = str2 + ",";
                            str = str + ",";
                        }
                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@" + str3;
                        param.Value = columnValues[str3];
                        comm.Parameters.Add(param);
                    }
                    string str4 = "INSERT INTO " + tableName + "(" + str2 + ") VALUES(" + str + ")";
                    comm.CommandText = str4;
                    comm.ExecuteNonQuery();
                    SqlCommand comm2 = new SqlCommand();
                    comm2.CommandText = "SELECT @@IDENTITY";
                    comm2.Connection = conn;
                    int num2 = Convert.ToInt32(comm2.ExecuteScalar());
                    hashtable.Add("Identity", num2);
                    conn.Close();
                    comm.Dispose();
                    comm2.Dispose();
                    hashtable2 = hashtable;
                }
            }
            catch (Exception e)
            {
                hashtable.Add("Error", e.Message);
                hashtable2 = hashtable;
            }
            return hashtable2;
        }

        public static Hashtable InsertDataChecked(string tableName, Hashtable columnValues, string whereClause, string identityColumn)
        {
            Hashtable hashtable2;
            Hashtable hashtable = new Hashtable();
            try
            {
                using (conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AJSGameConnectionString"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand();
                    string str = "";
                    comm.CommandText = "SELECT " + identityColumn + " FROM " + tableName + " WHERE" + whereClause;
                    comm.Connection = conn;
                    try
                    {
                        SqlDataReader dr = comm.ExecuteReader();
                        if (dr.Read())
                        {
                            str = dr[identityColumn].ToString();
                        }
                        dr.Dispose();
                    }
                    catch (Exception exx)
                    {
                    }

                    comm = new SqlCommand();
                    comm.Connection = conn;
                    if (str == "")
                    {
                        string str2 = "";
                        string str3 = "";
                        int num = 0;
                        foreach (string str4 in columnValues.Keys)
                        {
                            num++;
                            str3 = str3 + "[" + str4 + "]";
                            str2 = str2 + "@" + str4;
                            if (num != columnValues.Keys.Count)
                            {
                                str3 = str3 + ",";
                                str2 = str2 + ",";
                            }
                            SqlParameter param = new SqlParameter();
                            param.ParameterName = "@" + str4;
                            param.Value = columnValues[str4];
                            comm.Parameters.Add(param);
                        }
                        string str5 = "INSERT INTO " + tableName + "(" + str3 + ") VALUES(" + str2 + ")";
                        comm.CommandText = str5;
                        comm.ExecuteNonQuery();
                        SqlCommand comm2 = new SqlCommand();
                        comm2.CommandText = "SELECT @@IDENTITY";
                        comm2.Connection = conn;
                        str = comm2.ExecuteScalar().ToString();
                        hashtable.Add("BeforeAdded", false);
                        comm2.Dispose();
                        conn.Close();
                        comm.Dispose();
                    }
                    else
                    {
                        hashtable.Add("BeforeAdded", true);
                    }
                    hashtable.Add("Identity", Convert.ToInt32(str));
                    conn.Close();
                    comm.Dispose();
                    hashtable2 = hashtable;
                }
            }
            catch (Exception e)
            {
                hashtable.Add("@Error", e.Message);
                hashtable2 = hashtable;
            }
            return hashtable2;
        }

        public static Hashtable InsertCheckedUpdate(string tableName, Hashtable columnsValues, string whereClause, string identityColumn)
        {
            Hashtable hashtable2;
            Hashtable hashtable = new Hashtable();
            try
            {
                using (conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AJSGameConnectionString"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand();
                    string str = "";
                    comm.CommandText = "SELECT " + identityColumn + " FROM " + tableName + " WHERE " + whereClause;
                    comm.Connection = conn;
                    SqlDataReader dr = comm.ExecuteReader();
                    if (dr.Read())
                    {
                        str = dr[identityColumn].ToString();
                    }
                    dr.Dispose();
                    comm = new SqlCommand();
                    comm.Connection = conn;
                    string str2 = "";
                    string str3 = "";
                    int index = 0;
                    foreach (string str4 in columnsValues.Keys)
                    {
                        index++;
                        str3 = str3 + "[" + str4 + "]";
                        str2 = str2 + "@" + str4;
                        if (index != columnsValues.Keys.Count)
                        {
                            str3 = str3 + ",";
                            str2 = str2 + ",";
                        }
                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@" + str4;
                        param.Value = columnsValues[str4];
                        comm.Parameters.Add(param);
                    }
                    if (str == "")
                    {
                        comm.CommandText = "INSERT INTO " + tableName + "(" + str3 + ") VALUES(" + str2 + ")";
                    }
                    else
                    {
                        string str5 = "";
                        string[] strArray = str3.Split(new char[] { ',' });
                        string[] strArray2 = str2.Split(new char[] { ',' });
                        for (index = 0; index < strArray.Length; index++)
                        {
                            str5 = (str5 + strArray[index] + "=" + strArray2[index]) + ((index != (strArray.Length - 1)) ? "," : "");
                        }
                        comm.CommandText = "UPDATE " + tableName + " SET " + str5 + " WHERE " + whereClause;
                    }
                    comm.ExecuteNonQuery();
                    if (str == "")
                    {
                        SqlCommand comm2 = new SqlCommand();
                        comm2.CommandText = "SELECT @@IDENTITY";
                        comm2.Connection = conn;
                        str = comm2.ExecuteScalar().ToString();
                        hashtable.Add("BeforeAdded", false);
                        comm2.Dispose();
                    }
                    conn.Close();
                    comm.Dispose();
                    if (str != "")
                    {
                        hashtable.Add("BeforeAdded", true);
                    }
                    hashtable.Add("Identity", Convert.ToInt32(str));
                    conn.Close();
                    comm.Dispose();
                    hashtable2 = hashtable;
                }
            }
            catch (Exception e)
            {
                hashtable.Add("Error", e.Message);
                hashtable2 = hashtable;
            }
            return hashtable2;
        }

        public static Hashtable UpdateData(string tableName, string whereClause, Hashtable columnsValues)
        {
            Hashtable hashtable2;
            Hashtable hashtable = new Hashtable();
            try
            {
                using (conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AJSGameConnectionString"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    string str = "";
                    int num = 0;
                    foreach (string str2 in columnsValues.Keys)
                    {
                        num++;
                        string str3 = str;
                        str = str3 + "[" + str2 + "] = @" + str2;
                        SqlParameter param = new SqlParameter();
                        param.ParameterName = "@" + str2;
                        param.Value = columnsValues[str2];
                        comm.Parameters.Add(param);
                        if (num != columnsValues.Keys.Count)
                        {
                            str = str + ",";
                        }
                    }
                    comm.CommandText = "UPDATE " + tableName + " SET " + str + " WHERE " + whereClause;
                    comm.ExecuteNonQuery();
                    conn.Close();
                    comm.Dispose();
                    hashtable2 = hashtable;
                }
            }
            catch (Exception e)
            {
                hashtable.Add("Error", e.Message);
                hashtable2 = hashtable;
            }
            return hashtable2;

        }

        public static Hashtable SimpleUpdate(string tableName, string whereClause, string columnsValues)
        {
            Hashtable hashtable2;
            Hashtable hashtable = new Hashtable();
            try
            {
                using (conn = new SqlConnection(System.Configuration.ConfigurationManager.ConnectionStrings["AJSGameConnectionString"].ConnectionString))
                {
                    conn.Open();
                    SqlCommand comm = new SqlCommand();
                    comm.Connection = conn;
                    string str = "";
                    str = columnsValues;
                    comm.CommandText = "UPDATE " + tableName + " SET " + str + " WHERE " + whereClause;
                    comm.ExecuteNonQuery();
                    conn.Close();
                    comm.Dispose();
                    hashtable2 = hashtable;
                }
            }
            catch (Exception e)
            {
                hashtable.Add("Error", e.Message);
                hashtable2 = hashtable;
            }
            return hashtable2;
        }
    }
}