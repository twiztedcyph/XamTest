using System.IO;
using SQLite;
using Windows.Storage;
using Xamarin.Forms;
using XamTest.Interfaces;
using XamTest.UWP.Implementations;

[assembly: Dependency(typeof(Database_UWP))]
namespace XamTest.UWP.Implementations
{
    public class Database_UWP : IDatabase
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "CustomersDb.db3";
            var path = Path.Combine(ApplicationData.Current.LocalFolder.Path, dbName);
            return new SQLiteConnection(path);
        }
    }
}
