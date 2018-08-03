namespace XamTest.Interfaces
{
    public interface IDatabase
    {
        SQLite.SQLiteAsyncConnection DbAsyncConnection();
        SQLite.SQLiteConnection DbConnection();
    }
}
