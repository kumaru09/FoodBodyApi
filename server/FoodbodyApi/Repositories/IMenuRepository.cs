using System.Collections.Generic;
using System.Threading.Tasks;
using FoodbodyApi.Models;

namespace FoodbodyApi.Repositories
{
    public interface IMenuRepository
    {
        Task<List<MenuDetail>> GetMenuList(int? queryPage);
        Task<List<MenuDetail>> GetMenuListByName(List<string> c, string name, int? queryPage);
        Task<MenuDetail> GetMenuDetailByName(string name);
        List<MenuDetail> GetMenuListByCategory(List<string> name, int? queryPage);
        Task CreateMenu(MenuDetail menu);

    }
}
