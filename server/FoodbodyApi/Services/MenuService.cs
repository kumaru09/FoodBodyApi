
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using FoodbodyApi.Models;
using FoodbodyApi.Repositories;

namespace FoodbodyApi.Services {
    public class MenuService : IMenuService
    {
        private readonly IMenuRepository _menuRepository;
        private readonly IMapper _mapper;

        public MenuService(IMenuRepository menuRepository, IMapper mapper) {
            _menuRepository = menuRepository;
            _mapper = mapper;
        }

        public async Task CreateMenuAsync(MenuDetail menu)
        {
            await _menuRepository.CreateMenu(menu);
        }

        public Task<MenuDetail> GetMenuDetailByNameAsync(string name)
        {
            return _menuRepository.GetMenuDetailByName(name);
        }

        public async Task<List<Menu>> GetMenuListAsync()
        {
            return _mapper.Map<List<MenuDetail>, List<Menu>>(await _menuRepository.GetMenuList());
        }

        public async Task<List<Menu>> GetMenuListByNameAsync(string name)
        {
            var menuList = await _menuRepository.GetMenuListByName(name);
            return _mapper.Map<List<MenuDetail>, List<Menu>>(menuList);
        }
    }
}