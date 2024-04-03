using BoardGameManager_bot.DAL.Repositories;
using BoardGameManager_bot.DAL;
using BoardGameManager_bot.Models;
using Microsoft.Extensions.DependencyInjection;
using Nelibur.ObjectMapper;
using BoardGameManager_bot.DAL.Models;
using Microsoft.EntityFrameworkCore;

namespace BoardGameManager_bot.Business
{
    // Implement Singltone pattern
    public class DependencyInjectionService
    {
        private static DependencyInjectionService _instance;
        public ServiceCollection services;

        private DependencyInjectionService()
        {

        }

        public static DependencyInjectionService GetInstance()
        {
            if (_instance == null)
            {
                _instance = new DependencyInjectionService();
                _instance.ConfigureService();
            }
            return _instance;
        }

        private async Task<ServiceProvider> ConfigureService()
        {
            #region DI
            services = new();
            services.AddTransient<IRepository<Game>, GamesRepository>();
            services.AddDbContext<EFDbContext>(options =>
                        options.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=BoardGameManager_DB;Trusted_Connection=True;"));
            #endregion

            #region TinyMapper
            TinyMapper.Bind<Game, BotGame>();
            #endregion

            return services.BuildServiceProvider();
        }
    }
}
