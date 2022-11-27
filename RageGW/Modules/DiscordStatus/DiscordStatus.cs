using System;
using Discord;
using Discord.WebSocket;
using Discord.Commands;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using GTANetworkAPI;
using Discord.Net;
using Newtonsoft.Json;
using Color = Discord.Color;
using RageGW.Modules.Logger;

namespace RageGW.Modules.Discord
{
    class DiscordStatus : Script
    {
        [ServerEvent(Event.ResourceStart)]
        public void OnResourceStart()
        {
            Logger.Logger.Write("Module: DiscordStatus geladen", LoggerEnums.LogType.Info);
        }

        [ServerEvent(Event.ResourceStop)]
        public void OnResourceStop()
        {
            Logger.Logger.Write("Module: DiscordStatus entladen", LoggerEnums.LogType.Info);
        }

        public DiscordStatus() { }

        private static DiscordSocketClient client;
        private static CommandService commands;
        private static IServiceProvider services;
        private static string token = "";

        public static async Task StartDiscordBot()
        {
            try
            {
                client = new DiscordSocketClient();
                commands = new CommandService();
                services = new ServiceCollection()
                    .AddSingleton(client)
                    .AddSingleton(commands)
                    .BuildServiceProvider();

                client.Log += DiscordBotLog;

                client.Ready += BotIsReady;

                await client.LoginAsync(TokenType.Bot, token);

                await client.StartAsync();

                await Task.Delay(-1);

            }
            catch (Exception) { }
        }

        public async static Task BotIsReady()
        {
            int count = 0;

            foreach (Player player in NAPI.Pools.GetAllPlayers())
            {
                if (player.Exists)
                {
                    count++;
                }
            }

            await client.SetGameAsync(count + " Players Online");
        }

        public async static Task BotIsReady2()
        {
            int count = 0;

            foreach (Player player in NAPI.Pools.GetAllPlayers())
            {
                count--;
            }

            await client.SetGameAsync(count + " Players Online");
        }

        public static Task DiscordBotLog(LogMessage message)
        {
            NAPI.Util.ConsoleOutput("DiscordBot: " + message.ToString());
            return Task.CompletedTask;
        }
    }
}
