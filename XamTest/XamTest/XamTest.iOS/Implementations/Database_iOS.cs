using SQLite;
using System;
using System.IO;
using XamTest.Interfaces;
using XamTest.iOS.Implementations;

[assembly: Xamarin.Forms.Dependency(typeof(Database_iOS))]
namespace XamTest.iOS.Implementations
{
    public class Database_iOS : IDatabase
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "FCA.db3";
            string personalFolder = System.Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder = Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            return new SQLiteConnection(path);
        }
    }
}