using BoardGameManager_bot.DAL.Models;
using BoardGameManager_bot.DAL.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;

namespace BoardGameManager_bot.DAL.Repositories
{
    public class GamesRepository : IRepository<DbGame>
    {
        private readonly EFDbContext _context;

        public GamesRepository(EFDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(string EntityId)
        {
            await _context.Games.Where(x => x.Id == EntityId).ExecuteDeleteAsync();
        }

        public async Task DeleteAsync(DbGame Entity)
        {
            await _context.Games.Where(x => x.Id == Entity.Id).ExecuteDeleteAsync();
        }

        public IEnumerable<DbGame> GetByCondition(Func<DbGame,bool> condition)
        {
            return _context.Games.Where(condition);
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Games.CountAsync();
        }

        public async Task InsertAsync(DbGame Entity)
        {          
            await _context.Games.AddAsync(Entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
