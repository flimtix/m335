namespace MemeChat
{
    public static class Constants
    {
        public static string LocalDatabasePath => "Data Source=" + Path.Combine(FileSystem.AppDataDirectory, "MemeChatCache.db3");

        public const string ServerDbConnectionString = "Data Source=153.92.6.106;Port=3306;Initial Catalog=u166616309_MemeChat;User ID=u166616309_MemeChatUser;Password=1b&mhtTNELnA";
    }
}
