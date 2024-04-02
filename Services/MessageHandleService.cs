using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.InlineQueryResults;
using BoardGameManager_bot.Utils;
using BoardGameManager_bot.Constants;

namespace BoardGames_TelegramBot
{
    public class QueryHandleService
    {
        public static async Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            if (update?.Type == Telegram.Bot.Types.Enums.UpdateType.Message) // Check if it`s message
            {
                var messageText = CommandUtils.CutTheBotUsername(update.Message.Text);

                if(messageText == null)
                {
                    return;
                }

                Console.WriteLine($"Listen: {update.Message.From.Username} | Message: {messageText}");


                if (messageText == TelegramBotConstants.START_COMMAND)
                {
                    await DrawStartMenu(botClient, update, token);
                    return;
                }
            } else if (update?.Type == Telegram.Bot.Types.Enums.UpdateType.CallbackQuery)
            {
                var queryText = update?.CallbackQuery?.Data;

                if (queryText == null)
                {
                    return;
                }

                Console.WriteLine($"Lister: Bot | Query: {queryText}");

                if (update.CallbackQuery != null)
                {
                    await botClient.EditMessageTextAsync(
                        update.CallbackQuery.Message.Chat.Id,
                        update.CallbackQuery.Message.MessageId,
                        "New message");
                    return;
                }
            }       
        }

        public static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            return null;
        }

        private static async Task<Message> DrawStartMenu(ITelegramBotClient botClient, Update update, CancellationToken token)
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

            return await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: "👋 Welcome in Board Game Manager. There is list of bot features",
                replyToMessageId: update?.Message?.MessageId,
                replyMarkup: markup
                );
        }
    }
}
