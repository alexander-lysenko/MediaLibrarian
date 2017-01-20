using System.Data;
using System.Data.SQLite;

namespace MediaLibrarian
{
    public static class Database
    {
        public static string DatabaseName = "baza.db";
        public static SQLiteConnection Connection = new SQLiteConnection(string.Format("Data Source={0};", DatabaseName));
        public string Query { get; set; }

        public Database();

        public DataTable ReaderQuery(string query)
        {
            var readTable = new SQLiteCommand(query, Connection);
            var dataTable = new DataTable();
            try
            {
                Connection.Open();
                var reader = readTable.ExecuteReader();
                dataTable.Load(reader);
            }
            catch (System.Exception)
            {                
                throw;
            }
            Connection.Close();
            return dataTable;
        }

        public bool ExecuteQuery(string query)
        {
            var command = new SQLiteCommand(query, Connection);
            try
            {
                Connection.Open();
                command.ExecuteNonQuery();
            }
            catch (System.Exception)
            {
                Connection.Close();
                return false;
            }
            Connection.Close();
            return true;
        }
    }
}
