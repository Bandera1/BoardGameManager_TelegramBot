using BoardGameManager_bot.Business.Services;
using BoardGameManager_bot.Business.Utils;
using BoardGameManager_bot.DAL.Repositories.Abstraction;
using BoardGameManager_bot.Models;
using BoardGameManager_bot.ModelsAndButtons.Abstraction;
using BoardGameManager_bot.ModelsAndButtons.Misc;
using Microsoft.Extensions.DependencyInjection;
using Nelibur.ObjectMapper;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using DbGame = BoardGameManager_bot.DAL.Models.DbGame;

namespace BoardGameManager_bot.Menus.Games
{
    public class GamesListMenu : BotMenu
    {
        private static readonly IRepository<DbGame> _repository;

        static GamesListMenu()
        {
            _repository = DependencyInjectionService.GetInstance().serviceProvider.GetRequiredService<IRepository<DbGame>>();
        }

        public static async Task<Message> DrawMenu(
            ITelegramBotClient botClient,
            Update update,
            CancellationToken token
            )
        {
            var gamesList = new List<MenuObject>();

            var games = _repository.GetByCondition(x => 1 == 1);
            gamesList.AddRange(games.Select(dbGame =>
            {
                return TinyMapper.Map<BotGame>(dbGame);
            }));

            var inlineButtons = await MenuUtils.GenerateInlineColumnKeyboard(gamesList.ToArray(), new AddNewGameButton(), true);

            return await botClient.EditMessageTextAsync(
                       chatId: update.CallbackQuery.Message.Chat.Id,
                       messageId: update.CallbackQuery.Message.MessageId,
                       text: "Games list:",
                       replyMarkup: new InlineKeyboardMarkup(inlineButtons)
                       );
        }
    }
}
