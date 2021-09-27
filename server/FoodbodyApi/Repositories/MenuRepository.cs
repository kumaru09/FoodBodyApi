using System.Collections.Generic;
using System.Threading.Tasks;
using FoodbodyApi.Models;
using FoodbodyApi.Services;
using MongoDB.Driver;

namespace FoodbodyApi.Repositories {
    public class MenuRepository : IMenuRepository
    {
        private readonly IMongoCollection<Menu> _menu;

        public MenuRepository(MongoService mongo, IDatabaseSettings settings) {
            var db = mongo.GetClient().GetDatabase(settings.DatabaseName);
            _menu = db.GetCollection<Menu>(settings.ProductCollectionName);
        }

        public async Task<Menu> GetMenuById(string id) 
        {
            return await _menu.Find(m => m.menu_id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Menu>> GetMenuList()
        {
            return await _menu.Find(menu => true).ToListAsync();
        }

        public async Task<List<Menu>> GetMenuListByName(string name)
        {
            return await _menu.FindAsync(m => m.name.Contains(name)).Result.ToListAsync();
        }
    }
}