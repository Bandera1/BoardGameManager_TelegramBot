using BoardGameManager_bot.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameManager_bot.Utils
{
    public static class CommandUtils
    {
        public static string CutTheBotUsername(string command)
        {
            return command.Replace(TelegramBotConstants.TELEGRAM_BOT_USERNAME, String.Empty);
        } 
    }
}
