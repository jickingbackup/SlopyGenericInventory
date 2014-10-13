using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;

using MySql.Data;
using MySql.Data.MySqlClient;
namespace InventoryView
{

    /// <summary>
    /// Abstracts database operations.
    /// </summary>
    public static class MySqlExpressDB
    {
        private static string servername = "localhost";
        private static string username = "root";
        private static string password ="toor";
        private static string database = "GenericInventory";
        private static bool security = true;
        

        #region Properties

        public static string ServerName
        {
            get
            {
                return servername;
            }
            set
            {
                servername = value;
            }
        }

        public static string Database
        {
            get
            {
                return database;
            }
            set
            {
                database = value;
            }
        }

        public static string Username
        {
            get
            {
                return username;
            }
            set
            {
                username = value;
            }
        }

        public static string Password
        {
            get
            {
                return password;
            }
            set
            {
                password = value;
            }
        }

        

        /// <summary>
        /// Gets the connection string.
        /// </summary>    
        public static string ConnectionString
        {
            get
            {
                string conTemp = string.Empty;

                conTemp = string.Format("SERVER= {0};DATABASE={1};UID={2};PASSWORD={3};",
                ServerName, Database, Username, Password);

                return conTemp;
            }
        }

#endregion

        /// <summary>
        /// Try to connect to the server if the connection details are correct.
        /// </summary>
        /// <returns>Returns boolean true if successfully connected. False otherwise.</returns>
        public static bool TryConnect()
        {
            bool isCon = false;
            try
            {
                using (MySqlConnection con = new MySqlConnection(ConnectionString))
                {
                    con.Open();
                    isCon = true;
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return isCon;
        }


        /// <summary>
        /// A method that selects a data from database.
        /// </summary>
        /// <param name="query">A string type query or the name of stored procedure.</param>
        /// <returns>Returns the result of the query as a DataTable type.</returns>
        public static DataTable Select(string query)
        {
            DataTable dt = new DataTable();

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }

        /// <summary>
        /// A method that executes the query or stored procedure to the
        /// database.
        /// </summary>
        /// <param name="commandType">The type of command.</param>
        /// <param name="query">The string query or stored procedure name</param>
        /// <param name="args">An object array containing zero or more objects to format.</param>
        /// <returns></returns>
        public static DataTable Select(string query, params object[] args)
        {
            DataTable dt = new DataTable();

            Regex RegexToExtractParam = new Regex(@"@\w*");
            var MatchedParameters = RegexToExtractParam.Matches(query);
            List<string> Matches = new List<string>();

            foreach (var match in MatchedParameters)
                Matches.Add(match.ToString().Trim('@'));

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);

                Matches.ForEach(str => cmd.Parameters.Add(
                    new MySqlParameter(str, args[Matches.IndexOf(str)])));

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            return dt;
        }


        /// <summary>
        /// A method that executes an insert query.
        /// </summary>
        /// <param name="query">A string type query.</param>
        /// <returns>Returns true if successfully inserted otherwise false.</returns>
        public static bool Insert(string query)
        {
            bool _isInserted = false;

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();
                _isInserted = true;
            }

            return _isInserted;

        }


        /// <summary>
        /// A method that executes an insert query.
        /// </summary>
        /// <param name="query">A composite format query string.</param>
        /// <param name="args">An object array containing zero or more objects to format.</param>
        /// <returns>Returns true if successfully inserted otherwise false.</returns>
        public static bool Insert(string query, params object[] args)
        {
            bool _isInserted = false;
            Regex RegexToExtractParam = new Regex(@"@\w*");
            MatchCollection MatchedParameters = RegexToExtractParam.Matches(query);
            List<string> Matches = new List<string>();

            foreach (Match match in MatchedParameters)
                Matches.Add(match.ToString().Trim('@'));

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);

                Matches.ForEach(str => cmd.Parameters.Add(
                    new MySqlParameter(str, args[Matches.IndexOf(str)])));

                cmd.ExecuteNonQuery();

                _isInserted = true;
            }

            return _isInserted;
        }

        /// <summary>
        /// A method that executes a delete query.
        /// </summary>
        /// <param name="query">A string type query.</param>
        /// <returns>Returns true if successfully deleted otherwise false.</returns>
        public static bool Delete(string query)
        {
            bool _isInserted = false;
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                cmd.ExecuteNonQuery();

                _isInserted = true;
            }

            return _isInserted;
        }

        /// <summary>
        /// A method that executes a delete query.
        /// </summary>
        /// <param name="query">A composite format query string.</param>
        /// <param name="args">An object array containing zero or more objects to format.</param>
        /// <returns>Returns true if successfully deleted otherwise false.</returns>
        public static bool Delete(string query, params object[] args)
        {
            bool _isDeleted = false;

            Regex RegexToExtractParam = new Regex(@"@\w*");
            MatchCollection MatchedParameters = RegexToExtractParam.Matches(query);
            List<string> Matches = new List<string>();

            foreach (Match match in MatchedParameters)
                Matches.Add(match.ToString().Trim('@'));

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);

                Matches.ForEach(str => cmd.Parameters.Add(
                    new MySqlParameter(str, args[Matches.IndexOf(str)])));

                cmd.ExecuteNonQuery();

                _isDeleted = true;
            }

            return _isDeleted;

        }

        /// <summary>
        /// A method that executes an update query.
        /// </summary>
        /// <param name="query">A string type query.</param>
        /// <returns>Returns true if successfully updated otherwise false.</returns>
        public static bool Update(string query)
        {
            bool _isUpdated = false;
            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.ExecuteNonQuery();

                _isUpdated = true;
            }


            return _isUpdated;
        }

        /// <summary>
        /// A method that executes an update query.
        /// </summary>
        /// <param name="query">A composite format query string.</param>
        /// <param name="args">An object array containing zero or more objects to format.</param>
        /// <returns>Returns true if successfully updated otherwise false.</returns>
        public static bool Update(string query, params object[] args)
        {
            bool _isUpdated = false;
            Regex RegexToExtractParam = new Regex(@"@\w*");
            MatchCollection MatchedParameters = RegexToExtractParam.Matches(query);
            List<string> Matches = new List<string>();

            foreach (Match match in MatchedParameters)
                Matches.Add(match.ToString().Trim('@'));

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);

                Matches.ForEach(str => cmd.Parameters.Add(
                    new MySqlParameter(str, args[Matches.IndexOf(str)])));

                cmd.ExecuteNonQuery();

                _isUpdated = true;
            }

            return _isUpdated;
        }

        /// <summary>
        /// Gets a single value from database and returns a boolean result.
        /// </summary>
        /// <param name="query">The query to execute</param>
        /// <returns>Returns a boolean value as result.</returns>
        public static bool BooleanScalar(string query)
        {
            bool returnBool = false;

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                returnBool = Convert.ToBoolean(cmd.ExecuteScalar());
            }

            return returnBool;
        }

        /// <summary>
        /// Gets a single value from database and returns a boolean result.
        /// </summary>
        /// <param name="query">A composite format query string.</param>
        /// <param name="args">An object array containing zero or more objects to format.</param>
        /// <returns>Returns a boolean value as result.</returns>
        public static bool BooleanScalar(string query, params object[] args)
        {
            bool returnBool = false;

            Regex RegexToExtractParam = new Regex(@"@\w*");
            var MatchedParameters = RegexToExtractParam.Matches(query);
            List<string> Matches = new List<string>();

            foreach (var match in MatchedParameters)
                Matches.Add(match.ToString().Trim('@'));

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);

                Matches.ForEach(str => cmd.Parameters.Add(
                    new MySqlParameter(str, args[Matches.IndexOf(str)])));

                returnBool = Convert.ToBoolean(cmd.ExecuteScalar());
            }

            return returnBool;
        }

        /// <summary>
        /// Gets a single value from database and returns an object as result.
        /// </summary>
        /// <param name="query">The query to execute</param>
        /// <returns>Returns an object value as result.</returns>
        public static object ObjectScalar(string query)
        {
            object returnObj = null;

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                returnObj = cmd.ExecuteScalar();
            }

            return returnObj;
        }

        /// <summary>
        /// Gets a single value from database and returns an object as result.
        /// </summary>
        /// <param name="query">A composite format query string.</param>
        /// <param name="args">An object array containing zero or more objects to format.</param>
        /// <returns>Returns an object value as result.</returns>
        public static object ObjectScalar(string query, params object[] args)
        {
            object returnObj = null;

            Regex RegexToExtractParam = new Regex(@"@\w*");
            var MatchedParameters = RegexToExtractParam.Matches(query);
            List<string> Matches = new List<string>();

            foreach (var match in MatchedParameters)
                Matches.Add(match.ToString().Trim('@'));

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                Matches.ForEach(str => cmd.Parameters.Add(new MySqlParameter(str, args[Matches.IndexOf(str)])));
                returnObj = cmd.ExecuteScalar();
            }

            return returnObj;
        }

        /// <summary>
        /// A method that executes any query.
        /// </summary>
        /// <param name="query">The query to execute.</param>
        /// <returns>Returns boolean true if successfully executed.</returns>
        public static bool Execute(string query)
        {
            bool _isExecuted = false;

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);

                cmd.ExecuteNonQuery();

                _isExecuted = true;
            }

            return _isExecuted;

        }

        /// <summary>
        /// A method that executes any query.
        /// </summary>
        /// <param name="query">A composite format query string.</param>
        /// <param name="args">An object array containing zero or more objects to format.</param>
        /// <returns>Returns boolean true if successfully executed.</returns>
        public static bool Execute(string query, params object[] args)
        {
            bool _isExecuted = false;

            Regex RegexToExtractParam = new Regex(@"@\w*");
            var MatchedParameters = RegexToExtractParam.Matches(query);
            List<string> Matches = new List<string>();

            foreach (var match in MatchedParameters)
                Matches.Add(match.ToString().Trim('@'));

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);
                Matches.ForEach(str => cmd.Parameters.Add(new MySqlParameter(str, args[Matches.IndexOf(str)])));

                cmd.ExecuteNonQuery();

                _isExecuted = true;
            }

            return _isExecuted;
        }

        public static bool ExecuteProcedure(string query)
        {
            const string _procNamePattern = @"\w*";
            string _procedureName = string.Empty;

            var _matchedProcName = new Regex(_procNamePattern).Matches(query);

            _procedureName = _matchedProcName[0].ToString();

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(_procedureName, con);
                cmd.CommandType = CommandType.StoredProcedure;

                cmd.ExecuteNonQuery();
            }

            return true;
        }

        public static bool ExecuteProcedure(string query, params object[] args)
        {
            const string _paramPattern = @"@\w*";
            const string _procNamePattern = @"\w*";
            string _procedureName = string.Empty;

            var _matchedParameters = new Regex(_paramPattern).Matches(query);
            var _matchedProcName = new Regex(_procNamePattern).Matches(query);

            _procedureName = _matchedProcName[0].ToString();

            List<string> _parameters = new List<string>();

            foreach (var match in _matchedParameters)
                _parameters.Add(match.ToString().Trim('@'));

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(_procedureName, con);
                cmd.CommandType = CommandType.StoredProcedure;

                _parameters.ForEach(str => cmd.Parameters.Add(
                    new MySqlParameter(str, args[_parameters.IndexOf(str)])));

                cmd.ExecuteNonQuery();
            }

            return true;
        }

        public static bool ExecuteProcedure(ref DataTable dataTable, string query)
        {
            const string _procNamePattern = @"\w*";
            string _procedureName = string.Empty;

            var _matchedProcName = new Regex(_procNamePattern).Matches(query);

            _procedureName = _matchedProcName[0].ToString();

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(_procedureName, con);
                cmd.CommandType = CommandType.StoredProcedure;

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                }
            }

            return true;
        }

        public static bool ExecuteProcedure(ref DataTable dataTable, string query, params object[] args)
        {
            const string _paramPattern = @"@\w*";
            const string _procNamePattern = @"\w*";
            string _procedureName = string.Empty;

            var _matchedParameters = new Regex(_paramPattern).Matches(query);
            var _matchedProcName = new Regex(_procNamePattern).Matches(query);

            _procedureName = _matchedProcName[0].ToString();

            List<string> _parameters = new List<string>();

            foreach (var match in _matchedParameters)
                _parameters.Add(match.ToString().Trim('@'));

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(_procedureName, con);
                cmd.CommandType = CommandType.StoredProcedure;

                _parameters.ForEach(str => cmd.Parameters.Add(
                    new MySqlParameter(str, args[_parameters.IndexOf(str)])));

                using (MySqlDataAdapter da = new MySqlDataAdapter(cmd))
                {
                    da.Fill(dataTable);
                }
            }

            return true;
        }

        /// <summary>
        /// Gets all the database that has tables from the database.
        /// </summary>
        /// <returns>Returns an array of string as database list.</returns>
        public static string[] GetDatabaseNames()
        {
            List<string> _temp = new List<string>();

            string query = "SELECT DISTINCT(TABLE_SCHEMA) FROM INFORMATION_SCHEMA.COLUMNS";

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _temp.Add(reader["TABLE_SCHEMA"].ToString());
                    }
                }

            }

            return _temp.ToArray();
        }

        /// <summary>
        /// Gets all the tables from the specific database.
        /// </summary>
        /// <param name="database">A string database name.</param>
        /// <returns>Returns an array of string as tables from the selected database.</returns>
        public static string[] GetTableNames(string database)
        {
            List<string> _temp = new List<string>();

            string query = string.Format("SELECT DISTINCT(TABLE_NAME) FROM INFORMATION_SCHEMA.COLUMNS WHERE TABLE_SCHEMA = '{0}'", database);

            using (MySqlConnection con = new MySqlConnection(ConnectionString))
            {
                con.Open();
                MySqlCommand cmd = new MySqlCommand(query, con);

                using (MySqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        _temp.Add(reader[0].ToString());
                    }
                }
            }

            return _temp.ToArray();
        }
    }
}
