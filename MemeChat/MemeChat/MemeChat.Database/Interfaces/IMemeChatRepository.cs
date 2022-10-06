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
        Task<bool> AreCredentialsValid(ILoginCredentials credentials);
    }
}
