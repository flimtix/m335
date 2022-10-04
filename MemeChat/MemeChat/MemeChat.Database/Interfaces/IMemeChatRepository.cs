namespace MemeChat.Database.Interfaces
{
    public interface IMemeChatRepository
    {
        bool CreateDatabase();
        void SeedDatabase();
    }
}
