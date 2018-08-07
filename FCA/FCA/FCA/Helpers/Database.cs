using FCA.Interfaces;
using FCA.Models;
using SQLite;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace FCA.Helpers
{
    public class Database
    {
        public SQLiteConnection NonAsyncDb { get; set; } = DependencyService.Get<IDatabase>().DbConnection();
        public SQLiteAsyncConnection AsyncDb { get; set; } = DependencyService.Get<IDatabase>().DbAsyncConnection();

        public void CreateTables()
        {
            NonAsyncDb.CreateTable<DBCustomForm>();
            NonAsyncDb.CreateTable<DBCustomFormQuestion>();
        }

        public List<DBCustomForm> GetAllForms()
        {
            return NonAsyncDb.Table<DBCustomForm>().ToList();
        }
    }
}
