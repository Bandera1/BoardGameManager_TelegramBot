using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace BoardGames_TelegramBot
{
    public class MessageHandleService
    {
        public static async Task Update(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            var message = update.Message;
            if (message?.Text == null)
            {
                return;
            }

            Console.WriteLine($"Listen: {message.Chat.Username} | Message: {message.Text}");

            if (message.Text.Equals("/game_list"))
            {
                await botClient.SendTextMessageAsync(
               message.Chat.Id,
               "Game list");
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

            await botClient.SendTextMessageAsync(
                message.Chat.Id,
                "Підарас",
                replyToMessageId: update.Message.MessageId);

            return;
        }

        public static Task Error(ITelegramBotClient arg1, Exception arg2, CancellationToken arg3)
        {
            return null;
        }
    }
}
