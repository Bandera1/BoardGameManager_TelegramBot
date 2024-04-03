using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BoardGameManager_bot.DAL.Models
{
    public class Player
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string? LastName { get; set; }
        public string? TelegramUsername { get; set; }
        public string? SessionCount { get; set; }
        public DateTime? LastSessionDate { get; set; }
        public int? Wins { get; set; }
    }
}
