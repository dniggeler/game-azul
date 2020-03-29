using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace TestClient.Console
{
    class Program
    {
        private static string chatHubName = "chatHub";
        static async Task Main(string[] args)
        {
            string url = $"https://localhost:44380/{chatHubName}";

            HubConnection connection = new HubConnectionBuilder()
                .WithUrl(url)
                .Build();

            await connection.StartAsync();

            connection.On<string, string>("NewMessage", (playerName, message) =>
            {
                System.Console.WriteLine($"{playerName}: {message}");
            });

            connection.On<string>("NewPlayer", (playerName) =>
            {
                System.Console.WriteLine($"New player {playerName} joined the game.");
            });

            System.Console.WriteLine($"Connection is in state '{connection.State}'");

            if (connection.State == HubConnectionState.Connected)
            {
                Random rnd = new Random();

                string playerName = $"toni-{rnd.Next(100)}";

                while (true)
                {
                    Command cmd = Command.For(System.Console.ReadLine());

                    switch (cmd.ClientAction)
                    {
                        case ClientAction.Quit: break;
                        case ClientAction.Send:
                            await SendMessage(playerName, cmd, connection);
                            break;
                        default: continue;
                    }
                    
                }
            }
        }

        private static async Task SendMessage(
            string playerName, Command command, HubConnection connection)
        {
            await command.Option1
                .IfSomeAsync(msg => connection.InvokeAsync("SendMessage", playerName, msg));
        }
    }
}
