using BoardGameManager_bot.Constants;
using BoardGameManager_bot.ModelsAndButtons.Abstraction;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameManager_bot.Models
{
    public class BotGame : MenuObject
    {
        public BotGame()
        {
            this.Query = $"{TelegramBotConstants.GET_GAME_INFO}@{this.Id}";
        }

        public int MinPeople { get; set; } = 0;

        public int MaxPeople { get; set; } = 100;
    }
}
