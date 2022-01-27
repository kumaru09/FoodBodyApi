using System.Collections.Generic;
using System.Threading.Tasks;
using FoodbodyApi.Models;

namespace FoodbodyApi.Services {
    public interface IMenuService
    {
        Task<List<Menu>> GetMenuListAsync(int? queryPage);
        Task<List<Menu>> GetMenuListByNameAsync(List<string> c, string name, int? queryPage);
        Task<MenuDetail> GetMenuDetailByNameAsync(string name);
        List<Menu> GetMenuListByCategory(List<string> name, int? queryPage);
        Task CreateMenuAsync(MenuDetail menu);
    }
}