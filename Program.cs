using BoardGameManager_bot.Business.Services;
using BoardGameManager_bot.Constants;
using BoardGames_TelegramBot;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

internal class Program
{
    static TelegramBotClient botClient = new TelegramBotClient("7018047162:AAGZcJIG34hRZkDm15xVlzUF0479eMvZVlo");

    private static async Task Main(string[] args)
    {
        DependencyInjectionService.GetInstance();

        //await botClient.DeleteMyCommandsAsync();
        //await botClient.SetMyCommandsAsync(GetMainCommands());

        await botClient.GetUpdatesAsync(limit: 1);

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