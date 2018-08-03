using System.Collections.Generic;
using System.Linq;
using SQLite;
using Xamarin.Forms;
using XamTest.Interfaces;
using XamTest.Models;

namespace XamTest.Helpers
{
    public class Database
    {
        public SQLiteConnection DbConnection { get; set; } = DependencyService.Get<IDatabase>().DbConnection();
        public SQLiteAsyncConnection DbAyncConnection { get; set; } = DependencyService.Get<IDatabase>().DbAsyncConnection();

        public Database()
        {
            CreateTables();
        }

        private void CreateTables()
        {
            DbConnection.CreateTable<DBCustomForm>();

            for (int i = 0; i < 10; i++)
            {
                DbConnection.Insert(new DBCustomForm() { FormID = i.ToString(), Title = i.ToString() });
            }

            DbConnection.CreateTable<DBCustomFormQuestion>();
        }

        public List<DBCustomForm> GetAllForms()
        {
            return DbConnection.Table<DBCustomForm>().ToList();
        }
    }
}
