using MemeChat.Database.Interfaces;
using MemeChat.Models;
using Microsoft.AspNetCore.Components;

namespace MemeChat.ViewModel
{
    public class IndexViewModel
    {
        private readonly NavigationManager navigationManager;
        private readonly IMemeChatRepository memeChatRepository;

        public IndexViewModel(NavigationManager navigationManager, IMemeChatRepository memeChatRepository)
        {
            this.navigationManager = navigationManager;
            this.memeChatRepository = memeChatRepository;
        }

        public string CurrentNickname { get; set; } = string.Empty;

        public string SearchName { get; set; } = string.Empty;
        public ICollection<User> Users => FilterUsers();
        public Dictionary<string, Chat> Chats { get; private set; } = new();

        public async Task LoadData()
        {
            // Sync database
            try
            {
                await memeChatRepository.SyncDatabase();
            }
            catch { /* Databse error */ }

            // User must login first
            if (await memeChatRepository.GetCurrentUser() == null)
            {
                navigationManager.NavigateTo("start");
            }

            CurrentNickname = await memeChatRepository.GetCurrentNickname();

            // Load users
            Chats = await memeChatRepository.GetChatsWithUser();
        }

        private ICollection<User> FilterUsers()
        {
            return Chats.OrderBy(c => c.Value.Messages.Last().SendAt)
            .Select(c => c.Value.User_1.Nickname == CurrentNickname ? c.Value.User_2 : c.Value.User_1)
            .Where(s => s.Name.Contains(SearchName, StringComparison.OrdinalIgnoreCase))
            .ToList();
        }

        public void NavigateToChat(string nickname)
        {
            navigationManager.NavigateTo("chat/" + nickname);
        }

        public bool DoesUserWithNicknameExist(string nickname)
        {
            if (nickname == CurrentNickname)
            {
                return false;
            }

            return Task.Run(() => memeChatRepository.GetUserByNickname(nickname)).Result != null;
        }
    }
}
