using System.Collections.Generic;
using System.Threading.Tasks;
using FoodbodyApi.Models;

namespace FoodbodyApi.Services {
    public interface IMenuService
    {
        Task<List<Menu>> GetMenuListAsync();
        Task<List<Menu>> GetMenuListByNameAsync(string name, int? queryPage);
        Task<MenuDetail> GetMenuDetailByNameAsync(string name);
        Task CreateMenuAsync(MenuDetail menu);
    }
}