namespace MemeChat
{
    public static class Constants
    {
        public static string LocalDatabasePath => "Data Source=" + Path.Combine(FileSystem.AppDataDirectory, "MemeChatCache.db3");
        public const string ServerDbConnectionString = "Data Source";
        public const string SecureStorage_Nickname = "nickname";
    }
}
