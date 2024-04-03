using BoardGameManager_bot.ModelsAndButtons.Abstraction;
using BoardGameManager_bot.ModelsAndButtons.Misc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.ReplyMarkups;

namespace BoardGameManager_bot.Business.Utils
{
    public static class MenuUtils
    {
        public static async Task<List<List<InlineKeyboardButton>>> GenerateInlineColumnKeyboard(
            MenuObject[] buttons,
            MenuObject firsButton = null,
            bool addBackButton = true
            )
        {
            var menuObjects = new List<MenuObject>();
            
            if(firsButton != null)
            {
                menuObjects.Add(firsButton);
            }
            menuObjects.AddRange(buttons);

            if(addBackButton)
            {
                menuObjects.Add(new BackButton());
            }

            var buttonsList = new List<List<InlineKeyboardButton>>();
            foreach (var menuObject in menuObjects)
            {
                buttonsList.Add(new List<InlineKeyboardButton>()
                {
                   InlineKeyboardButton.WithCallbackData(
                   text: menuObject.Name,
                   callbackData: menuObject.Query
                 )
                });
            }

            return buttonsList;
        }
    }
}
