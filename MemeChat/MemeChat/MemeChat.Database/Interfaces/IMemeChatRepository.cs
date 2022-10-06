using MemeChat.Models;

namespace MemeChat.Database.Interfaces
{
    public interface IMemeChatRepository
    {
        bool IsConnectedToServer();
        bool CreateDatabase();
        void SeedDatabase();
        Task<User> GetUserByNickname();
        Task<string> GetCurrentNickname();
        Task<User> GetCurrentUser();
        Task<bool> SaveUserAsync(User user);
    }
}
