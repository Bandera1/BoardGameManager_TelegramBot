using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameManager_bot.Constants
{
    public static class TelegramBotConstants
    {
        #region Default
        public const string TELEGRAM_BOT_USERNAME = "@boardGames_pollManager_bot";
        public const string START_COMMAND = "/show_bot";
        #endregion

        #region GameCommands
        public const string GAMES_LIST_COMMAND = "/game_list";
        public const string ADD_NEW_GAME = "/add_new_game";
        public const string GET_GAME_INFO = "/gameInfo";
        #endregion

        #region Misc
        public const string BACK_TO_PREVIOUS_MENU = "/back";
        #endregion
    }
}
