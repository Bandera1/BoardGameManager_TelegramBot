using BoardGameManager_bot.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;

namespace BoardGameManager_bot.Utils
{
    public static class CommandUtils
    {
        public static string CutTheBotUsername(string command)
        {
            if(command == null)
            {
                return null;
            }

            return command.Replace(TelegramBotConstants.TELEGRAM_BOT_USERNAME, String.Empty);
        }
    }
}
