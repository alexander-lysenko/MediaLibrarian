using System.Data.SQLite;
using SqlKata;
using SqlKata.Compilers;
using SqlKata.Execution;
using System.Data.Linq;

namespace MediaLibrarian.DB
{
    public static class Database
    {
        private const string DatabaseName = "storage.db";
        private static readonly string DataSource = $"Data Source=file:{DatabaseName};";

        public static Query GetQuery(string tableName)
        {
            var connection = new SQLiteConnection(DataSource);
            var compiler = new SqliteCompiler();

            var db = new QueryFactory(connection, compiler);

            return db.Query(tableName);
        }

        private static void CheckDatabase()
        {
            var connection = new SQLiteConnection(DataSource);
            var compiler = new SqliteCompiler();

            // var transaction = connection.BeginTransaction();
            // using (transaction)
            // {
            //     try
            //     {
            //         transaction.Commit();
            //     }
            //     catch (Exception e)
            //     {
            //         Console.WriteLine(e);
            //         transaction.Rollback();
            //         throw;
            //     }
            // }

            var db = new QueryFactory(connection, compiler);
            var ctx = new DataContext(DataSource);
            // var tre = ctx.GetTable().First((q) => q.Id == "1");
            // var dbset = new DataSet();
            // dbset.dbset.Tables.Add();
            // dbset.AcceptChanges();
            // ctx.
            // check for sqlitelibrarymeta
            //if not exist, create table
            // use pragma writableschema
        }
    }
}