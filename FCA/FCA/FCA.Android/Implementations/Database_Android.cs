using FCA.Droid.Implementations;
using FCA.Interfaces;
using Plugin.Settings;
using SQLite;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(Database_Android))]
namespace FCA.Droid.Implementations
{
    class Database_Android : IDatabase
    {
        private const string DB_NAME = "FCA.db3";

        public SQLiteAsyncConnection DbAsyncConnection()
        {
            return new SQLiteAsyncConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), DB_NAME));
        }

        public SQLiteConnection DbConnection()
        {
            return new SQLiteConnection(Path.Combine(System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal), DB_NAME));
        }
    }
}