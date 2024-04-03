using BoardGameManager_bot.Constants;
using BoardGameManager_bot.DAL;
using BoardGameManager_bot.DAL.Repositories;
using BoardGames_TelegramBot;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Telegram.Bot;
using Telegram.Bot.Types;

using Game = BoardGameManager_bot.DAL.Models.Game;

internal class Program
{
    static TelegramBotClient botClient = new TelegramBotClient("7018047162:AAGZcJIG34hRZkDm15xVlzUF0479eMvZVlo");

    private static async Task Main(string[] args)
    {
        await ConfigureService();

        //await botClient.DeleteMyCommandsAsync();
        //await botClient.SetMyCommandsAsync(GetMainCommands());

        await botClient.GetUpdatesAsync();
        botClient.StartReceiving(QueryHandleService.Update, QueryHandleService.Error);

        Console.ReadLine();
    }

    private static async Task ConfigureService()
    {
        ServiceCollection services = new();
        services.AddTransient<IRepository<Game>, GamesRepository>();
        services.AddDbContext<EFDbContext>(options =>
                    options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BoardGameManager_DB;Trusted_Connection=True;"));

        var provider = services.BuildServiceProvider();
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