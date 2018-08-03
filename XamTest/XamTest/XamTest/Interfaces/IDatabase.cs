namespace XamTest.Shared
{
    public interface IDatabase
    {
        SQLite.SQLiteAsyncConnection DbAsyncConnection();
        SQLite.SQLiteConnection DbConnection();
    }
}
