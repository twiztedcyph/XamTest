using System.IO;
using SQLite;
using Windows.Storage;
using Xamarin.Forms;
using XamTest.Shared;
using XamTest.UWP.Implementations;

[assembly: Dependency(typeof(Database_UWP))]
namespace XamTest.UWP.Implementations
{
    public class Database_UWP : IDatabase
    {
        private const string dbName = "FCA.db3";

        public SQLiteAsyncConnection DbAsyncConnection()
        {
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbName);
            return new SQLiteAsyncConnection(path);
        }

        public SQLiteConnection DbConnection()
        {
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbName);
            return new SQLiteConnection(path);
        }
    }
}
