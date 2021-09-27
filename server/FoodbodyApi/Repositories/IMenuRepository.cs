using System.Collections.Generic;
using System.Threading.Tasks;
using FoodbodyApi.Models;

namespace FoodbodyApi.Repositories
{
    public interface IMenuRepository
    {
        Task<Menu> GetMenuById(string id);
        Task<List<Menu>> GetMenuList();
        Task<List<Menu>> GetMenuListByName(string name);

    }
}
