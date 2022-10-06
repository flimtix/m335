using MemeChat.Models;

namespace MemeChat.Database.Interfaces
{
    public interface IMemeChatRepository
    {
        Task<bool> IsConnectedToServer();
        bool CreateDatabase();
        Task SyncDatabase();
        Task<User> GetUserByNickname(string nickname);
        Task<string> GetCurrentNickname();
        Task<User> GetCurrentUser();
        Task<bool> SaveUserAsync(User user);
        Task<Dictionary<string, Chat>> GetChatsWithUser();
        Task<Chat> GetChat(User sender, User current);
        Task<bool> SaveMessageAsync(Message message, User sender, User current);
        Task<bool> AreCredentialsValid(ILoginCredentials credentials);
    }
}
