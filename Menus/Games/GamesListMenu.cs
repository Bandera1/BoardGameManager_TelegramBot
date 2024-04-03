using BoardGameManager_bot.DAL.Repositories;
using BoardGameManager_bot.ModelsAndButtons.Abstraction;
using BoardGameManager_bot.ModelsAndButtons.Misc;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Game = BoardGameManager_bot.DAL.Models.Game;

namespace BoardGameManager_bot.Menus.Games
{
    public class GamesListMenu : BotMenu
    {
        //private readonly IRepository<Game> _repository;

        //public GamesListMenu(IRepository<Game> repository)
        //{
        //    _repository = repository;
        //}

        public static async Task<Message> DrawMenu(ITelegramBotClient botClient, Update update, CancellationToken token, string previouseMenu)
        {
            var menuObjects = new List<MenuObject>()
            {
                new AddNewGameButton()         
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

            menuObjects.Add(new BackButton(previouseMenu));

            return await botClient.EditMessageTextAsync(
                       chatId: update.CallbackQuery.Message.Chat.Id,
                       messageId: update.CallbackQuery.Message.MessageId,
                       text: "Game list: ",
                       replyMarkup: new InlineKeyboardMarkup(buttons)
                       );
        }
    }
}
