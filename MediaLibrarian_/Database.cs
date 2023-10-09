using System;
using System.Data;
using System.Data.SQLite;

namespace MediaLibrarian_
{
    #region TOUPPER

    [SQLiteFunction(Name = "TOUPPER", Arguments = 1, FuncType = FunctionType.Scalar)]
    public class TOUPPER : SQLiteFunction
    {
        public override object Invoke(object[] args) //characters for the growth of
        {
            return args[0].ToString().ToUpper();
        }
    }

    [SQLiteFunction(Name = "COLLATION_CASE_INSENSITIVE", FuncType = FunctionType.Collation)]
    internal class CollationCaseInsensitive : SQLiteFunction
    {
        public override int Compare(string param1, string param2) //According to Turkish character sorting to patch
        {
            return string.Compare(param1, param2, StringComparison.InvariantCulture);
        }
    }

    #endregion

    public static class Database
    {
        private const string DatabaseName = "baza.db";
        private static readonly string DataSource = string.Format("Data Source={0};", DatabaseName);

        public static SQLiteDataReader GetReader(string query)
        {
            SQLiteDataReader readerData;
            var connection = new SQLiteConnection(DataSource);
            try
            {
                connection.Open();
                var readReader = new SQLiteCommand(query, connection);
                var reader = readReader.ExecuteReader();
                readerData = reader;
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }

            connection.Close();
            return readerData;
        }

        public static DataTable GetTable(string query)
        {
            var dataTable = new DataTable();
            var connection = new SQLiteConnection(DataSource);
            try
            {
                connection.Open();
                var readTable = new SQLiteCommand(query, connection);
                var reader = readTable.ExecuteReader();
                dataTable.Load(reader);
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }

            connection.Close();
            return dataTable;
        }

        public static object GetScalar(string query)
        {
            object data;
            var connection = new SQLiteConnection(DataSource);
            try
            {
                connection.Open();
                var command = new SQLiteCommand(query, connection);
                data = command.ExecuteScalar();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }

            connection.Close();
            return data;
        }

        public static bool Execute(string query)
        {
            var connection = new SQLiteConnection(DataSource);
            var command = new SQLiteCommand(query, connection);
            try
            {
                connection.Open();
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                connection.Close();
                throw;
            }

            connection.Close();
            return true;
        }
    }
}