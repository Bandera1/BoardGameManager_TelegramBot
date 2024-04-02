using Telegram.Bot.Types;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using BoardGameManager_bot.Utils;
using BoardGameManager_bot.Constants;
using BoardGameManager_bot.Menus.Games;

namespace BoardGames_TelegramBot
{
    public class QueryHandleService
    {
        public static async Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            // Draw start menu
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
                await QueryHadler(botClient, update, token);
            }       
        }

        public static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            return null;
        }

        private static async Task QueryHadler(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var queryText = update?.CallbackQuery?.Data;

            if (queryText == null)
            {
                return;
            }

            Console.WriteLine($"Listen: Bot | Query: {queryText}");

            if (update.CallbackQuery != null)
            {
                switch (queryText)
                {
                    case TelegramBotConstants.GAMES_LIST_COMMAND:
                        await GamesListMenu.DrawMenu(botClient, update, token, "");
                        break;
                    case TelegramBotConstants.START_COMMAND:
                        await DrawStartMenu(botClient, update, token, isEdited: true);
                        break;
                }
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
                      text: "👋 Welcome in Board Game Manager. There is list of bot features",
                      replyMarkup: markup
                      );
            }

            return await botClient.SendTextMessageAsync(
                chatId: update.Message.Chat.Id,
                text: "👋 Welcome in Board Game Manager. There is list of bot features",
                replyToMessageId: update?.Message?.MessageId,
                replyMarkup: markup
                );
        }
    }
}
