using BoardGames_TelegramBot;
using Telegram.Bot;
using Telegram.Bot.Types;

internal class Program
{
    static TelegramBotClient botClient = new TelegramBotClient("7018047162:AAGZcJIG34hRZkDm15xVlzUF0479eMvZVlo");

    private static async Task Main(string[] args)
    {
        await botClient.SetMyCommandsAsync(GetMainCommands());

        botClient.StartReceiving(MessageHandleService.Update, MessageHandleService.Error);

        Console.ReadLine();
    }

    private static IEnumerable<BotCommand> GetMainCommands()
    {
        return new List<BotCommand>()
        {
            new BotCommand()
            {
                Command = "/game_list",
                Description = "List of games 🎲"
            },
            new BotCommand()
            {
                Command = "/vote_for_game",
                Description = "Vote for game 🗳️"
            },
            new BotCommand()
            {
                Command = "/stats",
                Description = "Stats 💾️"
            },
            new BotCommand()
            {
                Command = "/ban_random_member",
                Description = "Ban random member 🐭️"
            },
        };
    }
}