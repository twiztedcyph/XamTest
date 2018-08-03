using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using XamTest.Shared;
using XamTest.Models;

namespace XamTest.Helpers
{
    public class Database
    {
        public SQLiteConnection nonAsyncDb { get; set; } = DependencyService.Get<IDatabase>().DbConnection();
        public SQLiteAsyncConnection db { get; set; } = DependencyService.Get<IDatabase>().DbAsyncConnection();

        public void CreateTables()
        {
            nonAsyncDb.CreateTable<DBCustomForm>();
            nonAsyncDb.CreateTable<DBCustomFormQuestion>();
        }

        public List<DBCustomForm> GetAllForms()
        {
            return nonAsyncDb.Table<DBCustomForm>().ToList();
        }
    }
}
