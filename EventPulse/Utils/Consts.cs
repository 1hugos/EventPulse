namespace EventPulse.Utils;

public static class Consts
{
	public const string DbFilename = "EventsSQLite.db3";

	public static string DbPath =>
		Path.Combine(FileSystem.AppDataDirectory, DbFilename);

	public const SQLite.SQLiteOpenFlags Flags =
		SQLite.SQLiteOpenFlags.ReadWrite |
		SQLite.SQLiteOpenFlags.Create |
		SQLite.SQLiteOpenFlags.SharedCache;
}
