using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BoardGameManager_bot.DAL.Models
{
    public class Game
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        public string Name { get; set; }
        public int? MinPeople { get; set; }
        public int? MaxPeople { get; set; }
        public int? SessionCount { get; set; }
        public DateTime? LastPlayed { get; set; }
        public string? LastEdited { get; set; }
    }
}
