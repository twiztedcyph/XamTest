using SQLite;
using System.IO;
using XamTest.Droid.Implementations;
using XamTest.Interfaces;

[assembly: Xamarin.Forms.Dependency(typeof(Database_Android))]
namespace XamTest.Droid.Implementations
{
    public class Database_Android : IDatabase
    {
        private const string dbName = "FCA.db3";

        public SQLiteAsyncConnection DbAsyncConnection()
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            return new SQLiteAsyncConnection(path);
        }

        public SQLiteConnection DbConnection()
        {
            var path = Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), dbName);
            return new SQLiteConnection(path);
        }
    }
}