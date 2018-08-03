using SQLite;
using System;
using System.IO;
using XamTest.Shared;
using XamTest.iOS.Implementations;

[assembly: Xamarin.Forms.Dependency(typeof(Database_iOS))]
namespace XamTest.iOS.Implementations
{
    public class Database_iOS : IDatabase
    {
        private const string dbName = "FCA.db3";

        public SQLiteAsyncConnection DbAsyncConnection()
        {
            
            string personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            return new SQLiteAsyncConnection(path);
        }

        public SQLiteConnection DbConnection()
        {
            string personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            return new SQLiteConnection(path);
        }
    }
}