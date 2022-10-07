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
            return (accessType == NetworkAccess.Internet || accessType == NetworkAccess.ConstrainedInternet || accessType == NetworkAccess.Unknown)
                && serverDbContext != null
                && await serverDbContext.Database.CanConnectAsync();
        }

        public bool CreateDatabase()
        {
            try
            {
                clientDbContext.Database.EnsureCreated();
                serverDbContext.Database.EnsureCreated();

                return true;
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
            if (string.IsNullOrWhiteSpace(nickname))
            {
                return null;
            }

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

        public async Task<Dictionary<string, Chat>> GetChatsWithUser()
        {
            var chats = new Dictionary<string, Chat>();

            try
            {
                var nickname = await GetCurrentNickname();

                var dbChats = await clientDbContext.Chats
                    .Include(u => u.User_1)
                    .Include(u => u.User_2)
                    .Where(u => u.User_1.Nickname == nickname || u.User_2.Nickname == nickname)
                    .ToListAsync();

                foreach (var chat in dbChats)
                {
                    chats.Add(chat.User_1.Nickname == nickname ? chat.User_2.Nickname : chat.User_1.Nickname, chat);
                }
            }
            catch { /* Database error */ }

            return chats;
        }

        public async Task<bool> SaveUserAsync(User user)
        {
            if (user == null && !await IsConnectedToServer())
            {
                return false;
            }

            await serverDbContext.Users.AddAsync(user);
            await clientDbContext.Users.AddAsync(user);
            await serverDbContext.SaveChangesAsync();
            await clientDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> SaveMessageAsync(Message message, User sender, User current)
        {
            if (message == null || sender == null || current == null || !await IsConnectedToServer())
            {
                return false;
            }

            var dbServerChat = await serverDbContext.Chats.FirstOrDefaultAsync(u => u.User_1 == sender && u.User_2 == current || u.User_1 == current && u.User_2 == sender);

            if (dbServerChat == null)
            {
                var dbChat = new Chat()
                {
                    User_1 = sender,
                    User_2 = current,
                    Messages = new List<Message>() { message }
                };

                await serverDbContext.Chats.AddAsync(dbChat.Clone());
                await clientDbContext.Chats.AddAsync(dbChat.Clone());
            }
            else
            {
                dbServerChat.Messages.Add(message.Clone());
            }

            await serverDbContext.SaveChangesAsync();

            return true;
        }

        public async Task<Chat> GetChat(User sender, User current)
        {
            if (!await IsConnectedToServer())
            {
                return await clientDbContext.Chats.FirstOrDefaultAsync(u => u.User_1 == sender && u.User_2 == current || u.User_1 == current && u.User_2 == sender);
            }

            return await serverDbContext.Chats.FirstOrDefaultAsync(u => u.User_1 == sender && u.User_2 == current || u.User_1 == current && u.User_2 == sender);
        }

        public async Task<bool> AreCredentialsValid(ILoginCredentials credentials)
        {
            return await IsConnectedToServer() && await serverDbContext.Users.AnyAsync(u => u.Nickname == credentials.Nickname && u.Password == credentials.Password);
        }
    }
}
