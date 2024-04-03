using BoardGameManager_bot.Business;
using BoardGameManager_bot.Constants;
using BoardGameManager_bot.DAL;
using BoardGameManager_bot.DAL.Repositories;
using BoardGameManager_bot.Models;
using BoardGames_TelegramBot;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nelibur.ObjectMapper;
using System;
using Telegram.Bot;
using Telegram.Bot.Types;

using Game = BoardGameManager_bot.DAL.Models.Game;

internal class Program
{
    static TelegramBotClient botClient = new TelegramBotClient("7018047162:AAGZcJIG34hRZkDm15xVlzUF0479eMvZVlo");

    private static async Task Main(string[] args)
    {
        DependencyInjectionService.GetInstance();

        //await botClient.DeleteMyCommandsAsync();
        //await botClient.SetMyCommandsAsync(GetMainCommands());

        await botClient.GetUpdatesAsync();
        botClient.StartReceiving(QueryHandleService.Update, QueryHandleService.Error);

        Console.ReadLine();
    }

    private static IEnumerable<BotCommand> GetMainCommands()
    {
        return new List<BotCommand>()
        {
            new BotCommand()
            {
                Command = TelegramBotConstants.START_COMMAND,
                Description = "Manage games 🎲"
            }
        };
    }
}