using BoardGameManager_bot.Constants;
using BoardGameManager_bot.Models;
using BoardGameManager_bot.ModelsAndButtons.Abstraction;
using BoardGameManager_bot.ModelsAndButtons.Misc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace BoardGameManager_bot.Menus.Games
{
    public class GamesListMenu : BotMenu
    {
        public static async Task<Message> DrawMenu(ITelegramBotClient botClient, Update update, CancellationToken token, string previouseMenu)
        {
            var menuObjects = new List<MenuObject>()
            {
                new AddNewGameButton(),
                new BotGame()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = ""
                },
                new BotGame()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Кіклади"
                },
                new BotGame()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Екліпс"
                },
                new BotGame()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Прадавній жах"
                },
                new BotGame()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Істота"
                },
                new BackButton(previouseMenu)
            };

            var buttons = new List<List<InlineKeyboardButton>>();

            foreach (var menuObject in menuObjects)
            {
                buttons.Add(new List<InlineKeyboardButton>()
                {
                   InlineKeyboardButton.WithCallbackData(
                   text: menuObject.Name,
                   callbackData: menuObject.Query
                 )
                });
            }

            return await botClient.EditMessageTextAsync(
                       chatId: update.CallbackQuery.Message.Chat.Id,
                       messageId: update.CallbackQuery.Message.MessageId,
                       text: "Game list: ",
                       replyMarkup: new InlineKeyboardMarkup(buttons)
                       );
        }
    }
}
