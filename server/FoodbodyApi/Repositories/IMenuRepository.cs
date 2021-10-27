using System.Collections.Generic;
using System.Threading.Tasks;
using FoodbodyApi.Models;

namespace FoodbodyApi.Repositories
{
    public interface IMenuRepository
    {
        Task<List<MenuDetail>> GetMenuList();
        Task<List<MenuDetail>> GetMenuListByName(string name, int? queryPage);
        Task<MenuDetail> GetMenuDetailByName(string name);
        Task CreateMenu(MenuDetail menu);

    }
}
