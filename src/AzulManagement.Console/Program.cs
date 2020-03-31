using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR.Client;

namespace AzulManagement.Console
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

            HttpClient httpClient = new HttpClient();
            httpClient.BaseAddress = new Uri("https://localhost:44380/api/game/");

            System.Console.WriteLine($"Connection is in state '{connection.State}'");

            if (connection.State == HubConnectionState.Connected)
            {
                bool isProcessing = true;
                while (isProcessing)
                {
                    string actionCmd = System.Console.ReadLine();

                    switch (actionCmd)
                    {
                        case "q":
                        {
                            isProcessing = false;
                            break;
                        }
                        case "s":
                            string message = System.Console.ReadLine();
                            await SendMessage(message, connection);
                            break;
                        case "b":
                            await StartGame(httpClient);
                            break;
                        default: continue;
                    }
                }
            }
        }

        private static async Task StartGame(HttpClient httpClient)
        {
            throw new NotImplementedException();
        }

        private static async Task SendMessage(
            string message, HubConnection connection)
        {
            await connection.InvokeAsync("SendAdminMessage", message);
        }
    }
}
