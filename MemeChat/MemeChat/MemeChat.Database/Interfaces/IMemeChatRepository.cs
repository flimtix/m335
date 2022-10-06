using MemeChat.Models;

namespace MemeChat.Database.Interfaces
{
    public interface IMemeChatRepository
    {
        Task<bool> IsConnectedToServer();
        Task<bool> CreateDatabaseAsync();
        void SeedDatabase();
        Task<User> GetUserByNickname();
        Task<string> GetCurrentNickname();
        Task<User> GetCurrentUser();
        Task<bool> SaveUserAsync(User user);
        Task<bool> AreCredentialsValid(ILoginCredentials credentials);
    }
}
