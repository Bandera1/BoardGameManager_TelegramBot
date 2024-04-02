using BoardGameManager_bot.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace BoardGameManager_bot.DAL
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptionsBuilder options)
        {
            options.UseSqlServer(@"Server=(localdb)\\mssqllocaldb;Database=BoardGameManager_DB;Trusted_Connection=True;");
            Database.EnsureCreated();
        }

        public DbSet<Game> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<GameSession> GameSessions { get; set; }

        //protected override async void OnModelCreating(ModelBuilder builder)
        //{
        //    base.OnModelCreating(builder);

        //    // Roles - 1
        //    builder.Entity<Game>().HasData(new List<Game>() {
        //        new Game()
        //        {
        //            Name = "Кіклади"
        //        },
        //        new Game()
        //        {
        //            Name = "Екліпс"
        //        },
        //        new Game()
        //        {
        //            Name = "Прадавній жах"
        //        },
        //        new Game()
        //        {
        //            Name = "Істота"
        //        }
        //    });

        //}
    }
}
