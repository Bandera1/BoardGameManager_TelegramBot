using BoardGameManager_bot.Constants;
using BoardGameManager_bot.ModelsAndButtons.Abstraction;

namespace BoardGameManager_bot.ModelsAndButtons.Misc
{
    public class BackButton : MenuObject
    {
        public BackButton()
        {
            this.Name = "Back 🔙";
            this.Query = $"{TelegramBotConstants.BACK_TO_PREVIOUS_MENU}";
        }
    }
}
