using System;
using System.Threading.Tasks;
using AzulGameEngine.ChatHub.Models;
using Microsoft.AspNetCore.SignalR;

namespace AzulGameEngine.ChatHub
{
    public class ChatHub : Hub
    {
        private readonly ChatThread _chatThread;

        public ChatHub(ChatThread chatThread)
        {
            _chatThread = chatThread;
        }

        public async Task SendMessage(string playerName, string message)
        {
            _chatThread.AddMessage(new ChatMessage
            {
                ClientId = 0,
                Message = message,
                PlayerName = playerName,
                CreatedAt = DateTime.Now
            });

            await Clients.All.SendAsync("NewMessage", playerName, message);
        }
    }
}
