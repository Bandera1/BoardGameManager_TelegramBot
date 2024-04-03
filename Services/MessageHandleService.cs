using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using BoardGameManager_bot.Utils;
using BoardGameManager_bot.Constants;
using BoardGameManager_bot.Menus.Games;
using BoardGameManager_bot.DAL.Models;
using BoardGameManager_bot.DAL.Repositories.Abstraction;
using BoardGameManager_bot.Business.Services;
using Microsoft.Extensions.DependencyInjection;

namespace BoardGames_TelegramBot
{
    public class QueryHandleService
    {
        private static readonly IRepository<Query> _queryRepository;

        static QueryHandleService()
        {
            _queryRepository = DependencyInjectionService.GetInstance().serviceProvider.GetRequiredService<IRepository<Query>>();
        }

        public static async Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            if (update?.Type == Telegram.Bot.Types.Enums.UpdateType.Message) // Check if it`s message
            {
                await CommandHandler(botClient, update, token);
            }
            else if (update?.Type == Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
            {
                await QueryHadler(botClient, update, token);
            }

            await _queryRepository.InsertAsync(new Query()
            {
                QueryText = CommandUtils.CutTheBotUsername(update?.Message?.Text) ?? update?.CallbackQuery?.Data,
                ExecutedBy = update?.Message?.From?.Username ?? update?.CallbackQuery?.From?.Username,
                Date = DateTime.Now
            });
        }

        public static async Task Error(ITelegramBotClient botClient, Exception exception, CancellationToken token)
        {
            Console.WriteLine($"Error: {exception.Message}");

            await Task.Delay(1500);
            botClient.StartReceiving(QueryHandleService.Update, QueryHandleService.Error);

            throw exception;
        }

        private static async Task QueryHadler(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken token)
        {
            var queryText = update?.CallbackQuery?.Data;

            if (queryText == null)
            {
                return;
            }

            Console.WriteLine($"Listen: Bot | Query: {queryText}");

            if (queryText == TelegramBotConstants.BACK_TO_PREVIOUS_MENU)
            {
                queryText = _queryRepository
                    .GetByCondition(x => x.ExecutedBy == update.CallbackQuery.From.Username && x.QueryText != TelegramBotConstants.BACK_TO_PREVIOUS_MENU)
                    .Reverse()
                    .Skip(1)
                    .Take(1)
                    .First()
                    .QueryText;

                Console.WriteLine($"Back to -> {queryText}");
            }


            if (update.CallbackQuery != null)
            {
                switch (queryText)
                {
                    case TelegramBotConstants.GAMES_LIST_COMMAND:
                        await GamesListMenu.DrawMenu(botClient, update, token);
                        break;
                    case TelegramBotConstants.START_COMMAND:
                        await DrawStartMenu(botClient, update, token, isEdited: true);
                        break;
                }
            }
        }

        private static async Task CommandHandler(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken token)
        {
            var messageText = CommandUtils.CutTheBotUsername(update.Message.Text);

            if (messageText == null)
            {
                return;
            }

            Console.WriteLine($"Listen: {update?.Message?.From?.Username} | Message: {messageText}");

            switch(messageText)
            {
                case TelegramBotConstants.START_COMMAND:
                    await DrawStartMenu(botClient, update, token);
                    break;
            }         
        }

        private static async Task<Message> DrawStartMenu(
            ITelegramBotClient botClient,
            Update update, CancellationToken token,
            bool isEdited = false
            )
        {
            var markup = new InlineKeyboardMarkup(new List<List<InlineKeyboardButton>>()
            {
                new List<InlineKeyboardButton>()
                {
                    InlineKeyboardButton.WithCallbackData(
                    text: "Games 🎲",
                    callbackData: "/game_list" 
                    ),
                     InlineKeyboardButton.WithCallbackData(
                    text: "Players 🤴",
                    callbackData: "/players_list"
                    ),

                },
                 new List<InlineKeyboardButton>()
                {
                    InlineKeyboardButton.WithCallbackData(
                    text: "Vote for game 🗳️",
                    callbackData: "/vote_for_game"
                    ),
                    InlineKeyboardButton.WithCallbackData(
                    text: "Stats 💾",
                    callbackData: "/stats"
                    )                
                }
            });

            if(isEdited)
            {
                return await botClient.EditMessageTextAsync(
                      chatId: update.CallbackQuery.Message.Chat.Id,
                      messageId: update.CallbackQuery.Message.MessageId,
                      text: "👋 Welcome in Board DbGame Manager. There is list of bot features",
                      replyMarkup: markup
                      );
            }

            return await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: "👋 Welcome in Board DbGame Manager. There is list of bot features",
                replyToMessageId: update?.Message?.MessageId ?? null,
                replyMarkup: markup
                );
        }
    }
}
