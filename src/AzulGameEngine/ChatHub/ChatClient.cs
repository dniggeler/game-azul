using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;


namespace AzulGameEngine.ChatHub
{
    public class ChatClient : IChatClient
    {
        private readonly IHubContext<ChatHub> hubContext;

        public ChatClient(IHubContext<ChatHub> hubContext)
        {
            this.hubContext = hubContext;
        }

        public Task SendNewPlayerMessage(string playerName)
        {
            string message = $"Player {playerName} joined the game";

            return hubContext.Clients.All.SendAsync("NewPlayer", playerName, message);
        }
    }
}