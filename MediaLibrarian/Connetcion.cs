using System.Data.SQLite;

namespace MediaLibrarian
{
    public static class Connetcion
    {
        public static string DatabaseName = "baza.db";
        public static SQLiteConnection Connection = new SQLiteConnection(string.Format("Data Source={0};", DatabaseName));
    }
}
