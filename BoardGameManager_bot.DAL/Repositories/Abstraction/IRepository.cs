using BoardGameManager_bot.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameManager_bot.DAL.Repositories.Abstraction
{
    public interface IRepository<T> where T : class
    {
        IEnumerable<T> GetByCondition(Func<T, bool> condition);
        Task InsertAsync(T Entity);
        Task DeleteAsync(string EntityId);
        Task DeleteAsync(T Entity);
        Task<int> GetCountAsync();
        Task SaveAsync();
    }
}
