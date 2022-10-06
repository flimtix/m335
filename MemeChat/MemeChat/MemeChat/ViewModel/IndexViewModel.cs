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

        public bool IsConnected { get; private set; }
        public string SearchName { get; set; } = string.Empty;
        public HashSet<User> Users => Chats.Select(c => c.Value.User_1.Nickname == CurrentNickname ? c.Value.User_2 : c.Value.User_1)
                                                .Where(s => s.Name.Contains(SearchName, StringComparison.OrdinalIgnoreCase))
                                                .ToHashSet();
        public Dictionary<string, Chat> Chats { get; private set; } = new();

        public async Task LoadData()
        {
            IsConnected = await memeChatRepository.IsConnectedToServer();

            // Sync database
            await memeChatRepository.SyncDatabase();

            // User must login first
            if (await memeChatRepository.GetCurrentUser() == null)
            {
                navigationManager.NavigateTo("start");
            }

            CurrentNickname = await memeChatRepository.GetCurrentNickname();

            // Load users
            Chats = await memeChatRepository.GetChatsWithUser();
        }

        public void NavigateToChat(string nickname)
        {
            navigationManager.NavigateTo("/chat/" + nickname);
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
