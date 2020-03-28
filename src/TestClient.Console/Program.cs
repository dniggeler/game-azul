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

            connection.On<string, string>("NewPlayer", (playerName, message) =>
            {
                System.Console.WriteLine($"{playerName}: {message}");
            });

            System.Console.WriteLine($"Connection is in state '{connection.State}'");

            if (connection.State == HubConnectionState.Connected)
            {
                Random rnd = new Random();
                int playerId = rnd.Next(1, 10);
                string playerName = $"{playerId}";

                while (true)
                {
                    string input = System.Console.ReadLine();

                    if (!string.IsNullOrEmpty(input))
                    {
                        if ("q".Equals(input))
                        {
                            break;
                        }

                        await connection.InvokeAsync("SendMessage", playerName, input);
                    }
                }
            }

        }
    }
}
