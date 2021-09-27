using System.Collections.Generic;
using FoodbodyApi.Models;
using FoodbodyApi.Services;
using Microsoft.AspNetCore.Mvc;

namespace FoodbodyApi {

    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase {

        private readonly IMenuService _menuService;

        public MenuController(IMenuService menuService) {
            _menuService = menuService;
        }

        [HttpGet("id/{id}")]
        public ActionResult<Menu> GetMenuById(string id) {
            var menu = _menuService.GetMenuById(id).Result;
            if (menu == null) {
                return NoContent();
            }

            return menu;
        }

        [HttpGet]
        public ActionResult<List<Menu>> GetMenuList() {
            var menuList = _menuService.GetMenuList().Result;

            return menuList;
        }

        [HttpGet("name/{name}")]
        public ActionResult<List<Menu>> GetMenuListByName(string name) {
            var menuList = _menuService.GetMenuListByName(name).Result;

            return menuList;
        }

    }
}