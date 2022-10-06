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

        public bool IsConnectedToServer()
        {
            var accessType = Connectivity.Current.NetworkAccess;

            return (accessType == NetworkAccess.Internet || accessType == NetworkAccess.ConstrainedInternet) && serverDbContext != null && serverDbContext.Database.CanConnect();
        }

        public bool CreateDatabase()
        {
            return clientDbContext.Database.EnsureCreated() && IsConnectedToServer() && serverDbContext.Database.EnsureCreated();
        }

        public void SeedDatabase()
        {
            throw new NotImplementedException();
        }

        private async Task SyncUserToLocal(User user)
        {
            if (user == null)
            {
                return;
            }

            var localUser = await clientDbContext.Users.FirstOrDefaultAsync(u => u.Nickname == user.Nickname);

            if (localUser == null)
            {
                localUser = new();
                localUser.Map(user);
                await clientDbContext.Users.AddAsync(user);
            }
            else
            {
                localUser.Map(user);
                clientDbContext.Users.Update(localUser);
            }
        }

        public Task<User> GetUserByNickname()
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetCurrentNickname()
        {
            return await SecureStorage.Default.GetAsync(Constants.SecureStorage_Nickname);
        }

        public async Task<User> GetCurrentUser()
        {
            string nickname = await GetCurrentNickname();

            User user = null;

            if (IsConnectedToServer())
            {
                user = await serverDbContext.Users.FirstOrDefaultAsync(u => u.Nickname == nickname);
                await SyncUserToLocal(user);
            }
            else
            {
                user = await clientDbContext.Users.FirstOrDefaultAsync(u => u.Nickname == nickname);
            }

            return user;
        }

        public async Task<bool> SaveUserAsync(User user)
        {
            if(user == null)
            {
                return false;
            }

            if (IsConnectedToServer())
            {
                await serverDbContext.Users.AddAsync(user);
                await clientDbContext.Users.AddAsync(user);
                await serverDbContext.SaveChangesAsync();
                await clientDbContext.SaveChangesAsync();
            
                return true;
            }
            
            return false;
        }
    }
}
