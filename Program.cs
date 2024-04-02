﻿using BoardGameManager_bot.Constants;
using BoardGames_TelegramBot;
using Telegram.Bot;
using Telegram.Bot.Types;

internal class Program
{
    static TelegramBotClient botClient = new TelegramBotClient("7018047162:AAGZcJIG34hRZkDm15xVlzUF0479eMvZVlo");

    private static async Task Main(string[] args)
    {
        //await botClient.DeleteMyCommandsAsync();
        //await botClient.SetMyCommandsAsync(GetMainCommands());

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