using System;
using MediaLibrarian.DB;
using SqlKata.Execution;

namespace MediaLibrarian.Models
{
    public class LibraryMeta
    {
        private const string TableName = "sqlite_library_meta";

        public int Id { get; set; }
        public string TblName { get; set; }
        public string Schema { get; set; }
        public string Meta { get; set; }
        public DateTime CreatedAt { get; set; }

        public static LibraryMeta Load(string id)
        {
            Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            try
            {
                var query = Database.GetQuery(TableName);
                var res = query.Where("id", id).First<LibraryMeta>();
                return res;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public int Delete()
        {
            return 1;
        }

        public int Save()
        {
            return 1;
        }
    }
}