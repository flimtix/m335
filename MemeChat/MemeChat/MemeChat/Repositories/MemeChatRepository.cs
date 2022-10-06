using MemeChat.Database.Context;
using MemeChat.Database.Interfaces;
using MemeChat.Models;
using Microsoft.EntityFrameworkCore;

namespace MemeChat.Database.Repositories
{
    public class MemeChatRepository : IMemeChatRepository
    {
        private readonly ClientDbContext clientDbContext;
        private readonly ServerDbContext serverDbContext;

        public MemeChatRepository(ClientDbContext clientDbContext, ServerDbContext serverDbContext)
        {
            this.clientDbContext = clientDbContext;
            this.serverDbContext = serverDbContext;
        }

        public async Task<bool> IsConnectedToServer()
        {
            var accessType = Connectivity.Current.NetworkAccess;

            // Check if the user is connected to the internet and has a connection to the server
            return (accessType == NetworkAccess.Internet || accessType == NetworkAccess.ConstrainedInternet)
                && serverDbContext != null
                && await serverDbContext.Database.CanConnectAsync();
        }

        public bool CreateDatabase()
        {
            try
            {
                clientDbContext.Database.EnsureCreated();

                bool isConnected = Task.Run(() => IsConnectedToServer()).Result;
                if (isConnected)
                {
                    serverDbContext.Database.EnsureCreated();
                }

                return isConnected;
            }
            catch
            {
                return false;
            }
        }

        public async Task SyncDatabase()
        {
            // Sync is only available when the user is connected to the internet
            if (!await IsConnectedToServer())
            {
                return;
            }

            // Get chats with all data from the server
            var users = await serverDbContext.Users.ToListAsync();
            var chats = await serverDbContext.Chats
                .Include(u => u.User_1)
                .Include(u => u.User_2)
                .Include(m => m.Messages)
                .ToListAsync();

            // Delte local database
            await clientDbContext.Database.EnsureDeletedAsync();
            await clientDbContext.Database.EnsureCreatedAsync();

            // Add users to the client database
            await clientDbContext.Users.AddRangeAsync(users);
            await clientDbContext.Chats.AddRangeAsync(chats);

            // Save changes
            await clientDbContext.SaveChangesAsync();
        }

        public async Task<User> GetUserByNickname(string nickname)
        {
            return await clientDbContext.Users.FirstOrDefaultAsync(u => u.Nickname == nickname);
        }

        public async Task<string> GetCurrentNickname()
        {
            // Get the current nickname from the device storage
            string nickname = await SecureStorage.Default.GetAsync(Constants.SecureStorage_Nickname);

            return string.IsNullOrWhiteSpace(nickname) ? string.Empty : nickname;
        }

        public async Task<User> GetCurrentUser()
        {
            return await GetUserByNickname(await GetCurrentNickname());
        }

        public async Task<bool> SaveUserAsync(User user)
        {
            if (user == null)
            {
                return false;
            }

            if (await IsConnectedToServer())
            {
                await serverDbContext.Users.AddAsync(user);
                await clientDbContext.Users.AddAsync(user);
                await serverDbContext.SaveChangesAsync();
                await clientDbContext.SaveChangesAsync();

                return true;
            }

            return false;
        }

        public async Task<Dictionary<string, Chat>> GetChatsWithUser()
        {
            var chats = new Dictionary<string, Chat>();

            try
            {
                var nickname = await GetCurrentNickname();

                clientDbContext.Chats.Where(u => u.User_1.Nickname == nickname || u.User_2.Nickname == nickname);

            }
            catch { /* Database error */ }

            return chats;
        }

        public async Task<bool> AreCredentialsValid(ILoginCredentials credentials)
        {
            return await IsConnectedToServer() && await serverDbContext.Users.AnyAsync(u => u.Nickname == credentials.Nickname && u.Password == credentials.Password);
        }

    }
}
