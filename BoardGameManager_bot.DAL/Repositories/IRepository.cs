using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BoardGameManager_bot.DAL.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(string EntityId);
        Task InsertAsync(T Entity);
        Task DeleteAsync(string EntityId);
        Task DeleteAsync(T Entity);
        Task<int> GetCountAsync();
        Task SaveAsync();
    }
}
