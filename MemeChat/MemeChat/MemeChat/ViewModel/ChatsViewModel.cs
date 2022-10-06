using MemeChat.Database.Interfaces;
using MemeChat.Models;
using MemeChat.Service;

namespace MemeChat.ViewModel
{
    public class ChatsViewModel : IDisposable
    {
        private const int Delay = 3;
        private readonly IMemeChatRepository memeChatRepository;
        private CancellationTokenSource pollingTask;
        private Action refreshUi;

        public ChatsViewModel(IMemeChatRepository memeChatRepository)
        {
            this.memeChatRepository = memeChatRepository;
        }

        public bool IsConnected { get; private set; }

        public User Sender { get; set; }
        public User CurrentUser { get; set; }
        public Chat Chat { get; set; }
        public ICollection<Message> Messages => GetMessages();

        public async Task LoadData(string senderNickname, Action refreshUi)
        {
            // Checks if memes can be send
            IsConnected = await memeChatRepository.IsConnectedToServer();

            // Update List
            this.refreshUi = refreshUi;

            // Load Users
            Sender = await memeChatRepository.GetUserByNickname(senderNickname);
            CurrentUser = await memeChatRepository.GetCurrentUser();

            // Set up polling
            PolleChats();
        }

        private ICollection<Message> GetMessages()
        {
            return Chat?.Messages?.OrderByDescending(m => m.SendAt)?.ToList() ?? new List<Message>();
        }

        public async Task SendMeme()
        {
            if (!IsConnected)
            {
                return;
            }

            string meme = await SensorService.PickPhoto();

            if (!string.IsNullOrWhiteSpace(meme))
            {
                var message = new Message
                {
                    URL = meme,
                    SendAt = DateTime.UtcNow,
                    SendBy = CurrentUser,
                };

                if (Chat != null && Chat.Messages != null)
                {
                    Chat.Messages.Add(message);
                }

                try
                {
                    await memeChatRepository.SaveMessageAsync(message, Sender, CurrentUser);
                }
                catch { /* Database error */ }
            }
        }

        public void PolleChats()
        {
            // Continously pole tasks to load chats
            pollingTask = new CancellationTokenSource();
            Task.Factory.StartNew(async () =>
            {
                int last = 0;
                while (!pollingTask.IsCancellationRequested)
                {
                    try
                    {
                        Chat = await memeChatRepository.GetChat(Sender, CurrentUser);

                        if (Chat != null && last != Chat.Messages.Count)
                        {
                            refreshUi.Invoke();
                            last = Chat.Messages.Count;
                        }
                        Thread.Sleep(Delay * 1000);
                    }
                    catch { /* Ignore error */ }
                }
            }, pollingTask.Token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }

        public void Dispose()
        {
            if (pollingTask != null && !pollingTask.IsCancellationRequested)
            {
                pollingTask.Cancel();
            }

            GC.SuppressFinalize(this);
        }
    }
}
