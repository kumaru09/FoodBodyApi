using System.Collections.Generic;
using System.Threading.Tasks;
using FoodbodyApi.Models;
using FoodbodyApi.Services;
using MongoDB.Driver;

namespace FoodbodyApi.Repositories {
    public class MenuRepository : IMenuRepository
    {
        private readonly IMongoCollection<MenuDetail> _menu;

        public MenuRepository(MongoService mongo, IDatabaseSettings settings) {
            var db = mongo.GetClient().GetDatabase(settings.DatabaseName);
            _menu = db.GetCollection<MenuDetail>(settings.ProductCollectionName);
        }

        public async Task CreateMenu(MenuDetail menu)
        {
            await _menu.InsertOneAsync(menu);
        }

        public async Task<MenuDetail> GetMenuDetailByName(string name)
        {
            return await _menu.FindAsync(menu => menu.Name == name).Result.FirstOrDefaultAsync();
        }

        public async Task<List<MenuDetail>> GetMenuList()
        {
            return await _menu.Find(menu => true).ToListAsync();
        }

        public async Task<List<MenuDetail>> GetMenuListByName(string name)
        {
            return await _menu.FindAsync(m => m.Name.Contains(name)).Result.ToListAsync();
        }

    }
}