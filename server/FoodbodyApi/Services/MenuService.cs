
using System.Collections.Generic;
using System.Threading.Tasks;
using FoodbodyApi.Models;
using FoodbodyApi.Repositories;

namespace FoodbodyApi.Services {
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;

        public MenuService(IMenuRepository menuRepository) {
            _menuRepository = menuRepository;
        }

        public async Task<Menu> GetMenuById(string id)
        {
            return await _menuRepository.GetMenuById(id);
        }

        public async Task<List<Menu>> GetMenuList()
        {
            return await _menuRepository.GetMenuList();
        }

        public async Task<List<Menu>> GetMenuListByName(string name)
        {
            return await _menuRepository.GetMenuListByName(name);
        }
    }
}