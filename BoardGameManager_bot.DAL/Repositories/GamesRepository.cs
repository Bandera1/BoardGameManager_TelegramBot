using BoardGameManager_bot.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardGameManager_bot.DAL.Repositories
{
    public class GamesRepository : IRepository<Game>
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

        public async Task DeleteAsync(Game Entity)
        {
            await _context.Games.Where(x => x.Id == Entity.Id).ExecuteDeleteAsync();
        }

        public async Task<IEnumerable<Game>> GetAllAsync()
        {
            return await _context.Games.ToListAsync();
        }

        public async Task<Game> GetByIdAsync(string EntityId)
        {
            return await _context.Games.FirstOrDefaultAsync(x => x.Id == EntityId);
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.Games.CountAsync();
        }

        public async Task InsertAsync(Game Entity)
        {
            await _context.Games.AddAsync(Entity);
            SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
