using FCA.Interfaces;
using FCA.iOS.Implementations;
using SQLite;
using System;
using System.IO;
using Xamarin.Forms;

[assembly: Dependency(typeof(Database_iOS))]
namespace FCA.iOS.Implementations
{
    class Database_iOS : IDatabase
    {
        private const string DB_NAME = "FCA.db3";
        private readonly string personalFolder = Environment.GetFolderPath(Environment.SpecialFolder.Personal);

        public SQLiteAsyncConnection DbAsyncConnection()
        {
            return new SQLiteAsyncConnection(Path.Combine(personalFolder, "..", "Library", DB_NAME));
        }

        public SQLiteConnection DbConnection()
        {
            return new SQLiteConnection(Path.Combine(personalFolder, "..", "Library", DB_NAME));
        }
    }
}