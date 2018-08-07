namespace FCA.Interfaces
{
    public interface IDatabase
    {
        SQLite.SQLiteAsyncConnection DbAsyncConnection();
        SQLite.SQLiteConnection DbConnection();
    }
}
