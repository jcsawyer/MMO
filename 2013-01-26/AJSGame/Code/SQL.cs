using System;
using System.Collections;
using System.Data.SqlClient;

namespace AJSGame.Code
{
    public class SQL : IDisposable
    {
        private string _connectionString;
        private SqlConnection _connection;
        private SqlCommand _command;
        private Hashtable _response;

        public void Dispose()
        {
            _connection.Close();
            _connection.Dispose();
            _command.Dispose();
        }

        public SQL()
        {
            _connectionString = ""; // TODO Add connection string
            _connection = new SqlConnection(_connectionString);
            try
            {
                _connection.Open();
            }
            catch
            {
                throw new Exception("Error opening SQL connection ~ SQL.cs:SQL()");
            }
        }

        public bool Exists(string table, string where)
        {
            _command = new SqlCommand("SELECT COUNT(*) FROM " + table + " WHERE " + where, _connection);
            if (Convert.ToInt32(_command.ExecuteScalar().ToString()) >= 1)
                return true;
            else
                return false;

            throw new Exception("Unknown problem ~ SQL.cs:Exists(string,string)");
        }

        // SELECT

        // INSERT

        // UPDATE

        // DELETE
    }
}