using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameManager_bot.DAL.Models
{
    public class GameSession
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string GameId { get; set; }
        public DateTime? Date { get; set; }
        public int? PlayersCount { get; set; }
        public string? WinnerId { get; set; }
        public string? TimeTakenInHour { get; set; }

        public DbGame? Game { get; set; }
        public Player? Winner { get; set; }
    }
}
