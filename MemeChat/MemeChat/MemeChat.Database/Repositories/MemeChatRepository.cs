using MemeChat.Database.Context;
using MemeChat.Database.Interfaces;

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

        public bool CreateDatabase()
        {
            return clientDbContext.Database.EnsureCreated() && serverDbContext.Database.EnsureCreated();
        }

        public void SeedDatabase()
        {
            throw new NotImplementedException();
        }
    }
}
