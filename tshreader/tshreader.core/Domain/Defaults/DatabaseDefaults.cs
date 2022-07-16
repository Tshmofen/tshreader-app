using SQLite;

namespace tshreader.core.Domain.Defaults;

public static class DatabaseDefaults
{
    public static async Task<int> GetInsertedRowIdAsync(this SQLiteAsyncConnection connection)
    {
        // ReSharper disable once StringLiteralTypo
        return await connection.ExecuteScalarAsync<int>("SELECT last_insert_rowid()");
    }

    public const string DatabaseFilename = "PromoStorage.db3";

    // create if doesn't exist
    // multi-threaded database access
    public const SQLiteOpenFlags DatabaseFlags =
        SQLiteOpenFlags.ReadWrite |
        SQLiteOpenFlags.Create |
        SQLiteOpenFlags.SharedCache;

    public const CreateFlags TableFlags =
        CreateFlags.AllImplicit |
        CreateFlags.AutoIncPK;

    public static string DatabasePath { get; }
    public static SQLiteAsyncConnection Connection { get; }

    static DatabaseDefaults()
    {
        var basePath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        DatabasePath = Path.Combine(basePath, DatabaseFilename);
        Connection = new SQLiteAsyncConnection(DatabasePath, DatabaseFlags);
    }
}