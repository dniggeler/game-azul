using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using AzulGameEngine.ChatHub.Models;
using Microsoft.AspNetCore.SignalR;

namespace AzulGameEngine.ChatHub
{
    public class ChatHub : Hub
    {
        private const int MaxMessageLength = 60;

        private readonly ChatThread _chatThread;

        public ChatHub(ChatThread chatThread)
        {
            _chatThread = chatThread;
        }

        public async Task SendMessage(string playerName, string message)
        {
            string cleanMessage = Regex.Replace(message, @"\s+", "")
                .Substring(0, MaxMessageLength);
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
