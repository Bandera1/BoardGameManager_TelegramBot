using BoardGameManager_bot.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardGameManager_bot.DAL
{
    public class EFDbContext : DbContext
    {
        public EFDbContext(DbContextOptions<EFDbContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<DbGame> Games { get; set; }
        public DbSet<Player> Players { get; set; }
        public DbSet<GameSession> GameSessions { get; set; }
        public DbSet<Query> QueryHistory { get; set; }

        //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        //{
        //    optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BoardGameManager_DB;Trusted_Connection=True;");
        //}

        protected override async void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Roles - 1
            builder.Entity<DbGame>().HasData(new List<DbGame>() {
                new DbGame()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Кіклади"
                },
                new DbGame()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Екліпс"
                },
                new DbGame()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Прадавній жах"
                },
                new DbGame()
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Істота"
                }
            });

        }
    }
}
