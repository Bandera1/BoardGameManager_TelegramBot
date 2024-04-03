using BoardGameManager_bot.DAL.Models;
using BoardGameManager_bot.DAL.Repositories.Abstraction;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameManager_bot.DAL.Repositories
{
    public class QueryRepository : IRepository<Query>
    {
        private readonly EFDbContext _context;

        public QueryRepository(EFDbContext context)
        {
            _context = context;
        }

        public async Task DeleteAsync(string EntityId)
        {
            await _context.QueryHistory.Where(x => x.Id == EntityId).ExecuteDeleteAsync();
        }

        public async Task DeleteAsync(Query Entity)
        {
            await _context.QueryHistory.Where(x => x.Id == Entity.Id).ExecuteDeleteAsync();
        }

        public IEnumerable<Query> GetByCondition(Func<Query, bool> condition)
        {
            return _context.QueryHistory.Where(condition);
        }

        public async Task<int> GetCountAsync()
        {
            return await _context.QueryHistory.CountAsync();
        }

        public async Task InsertAsync(Query Entity)
        {
            await _context.QueryHistory.AddAsync(Entity);
            await SaveAsync();
        }

        public async Task SaveAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
