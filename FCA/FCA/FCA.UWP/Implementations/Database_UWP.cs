using FCA.Interfaces;
using FCA.UWP.Implementations;
using SQLite;
using System.IO;
using Windows.Storage;
using Xamarin.Forms;

[assembly: Dependency(typeof(Database_UWP))]
namespace FCA.UWP.Implementations
{
    class Database_UWP : IDatabase
    {
        private const string DB_NAME = "FCA.db3";

        public SQLiteAsyncConnection DbAsyncConnection()
        {
            return new SQLiteAsyncConnection(Path.Combine(ApplicationData.Current.LocalFolder.Path, DB_NAME));
        }

        public SQLiteConnection DbConnection()
        {
            return new SQLiteConnection(Path.Combine(ApplicationData.Current.LocalFolder.Path, DB_NAME));
        }
    }
}
