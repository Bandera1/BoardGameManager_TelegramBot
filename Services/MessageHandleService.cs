using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;
using BoardGameManager_bot.Utils;

namespace BoardGames_TelegramBot
{
    public class MessageHandleService
    {
        public static async Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            var messageText = CommandUtils.CutTheBotUsername(update?.Message?.Text);

            if (messageText == null)
            {
                return;
            }

            Console.WriteLine($"Listen: {message.Chat.Username} | Message: {messageText}");

            if (messageText.Equals("/game_list"))
            {
               await botClient.SendTextMessageAsync(
               message.Chat.Id,
               "Game list",
               replyToMessageId: update.Message.MessageId);
            }

            //await botClient.SendTextMessageAsync(
            //    message.Chat.Id,
            //    "Test text",
            //    parseMode: ParseMode.MarkdownV2,
            //    disableNotification: false,
            //    replyToMessageId: update.Message.MessageId,
            //    replyMarkup: new InlineKeyboardMarkup(
            //    InlineKeyboardButton.WithUrl(
            //        text: "Check sendMessage method",
            //        url: "https://core.telegram.org/bots/api#sendmessage")
            //    ));

            return;
        }

        public static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            return null;
        }
    }
}
