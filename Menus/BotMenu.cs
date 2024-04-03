using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace BoardGameManager_bot.Menus
{
    public abstract class BotMenu
    {
        public static Task<Message> DrawMenu(ITelegramBotClient botClient, Update update, CancellationToken token)
        {
            return null;
        }
       
    }
}
