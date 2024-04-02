using BoardGameManager_bot.Constants;
using BoardGameManager_bot.ModelsAndButtons.Abstraction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameManager_bot.ModelsAndButtons.Misc
{
    public class AddNewGameButton : MenuObject
    {
        public AddNewGameButton()
        {
            this.Name = "Add new game ➕";
            this.Query = TelegramBotConstants.ADD_NEW_GAME;
        }
    }
}
