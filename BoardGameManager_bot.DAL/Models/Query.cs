using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameManager_bot.DAL.Models
{
    public class Query
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string Id { get; set; }
        /// <summary>
        /// Query text
        /// </summary>
        public string QueryText { get; set; }
        /// <summary>
        /// Username of account who executed query
        /// </summary>
        public string ExecutedBy { get; set; }
        /// <summary>
        /// DateTime of executing
        /// </summary>
        public DateTime Date { get; set; }
    }
}
