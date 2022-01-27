using System.Collections.Generic;
using System.Linq;
using FoodbodyApi.Models;
using FoodbodyApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FoodbodyApi
{

    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {

        private readonly IMenuService _menuService;
        private readonly IBlobService _blobService;

        public MenuController(IMenuService menuService, IBlobService blobService)
        {
            _menuService = menuService;
            _blobService = blobService;
        }

        /// <summary>
        /// เรียก menuList
        /// </summary> 
        [HttpGet]
        public ActionResult<List<Menu>> GetMenuList(int? queryPage)
        {
            var menuList = _menuService.GetMenuListAsync(queryPage).Result;

            return Ok(menuList);
        }

        /// <summary>
        /// เรียก menuDetail โดยชื่อ
        /// </summary>
        [HttpGet("{name}")]
        public ActionResult<MenuDetail> GetMenuDetailByName(string name)
        {
            var menu = _menuService.GetMenuDetailByNameAsync(name).Result;

            if (menu == null)
            {
                return NoContent();
            }

            return Ok(menu);
        }

        /// <summary>
        /// เรียก menuList โดยชื่อ, Category, หรือทั้งสอง
        /// </summary>
        /// <remarks>
        /// Sample request:
        ///
        ///    ค้นหาโดยชื่อ : api/Menu/name?name={..}
        ///
        ///    ค้นหาโดยcategory : api/Menu/name?c={..}
        ///
        ///    ค้นหาโดยชื่อและcategory : api/Menu/name?c={..}&amp;name={..}&amp;...
        /// </remarks>
        [HttpGet("name")]
        public ActionResult<List<Menu>> GetMenuListByName([FromQuery] List<string> c, string name, int? queryPage)
        {   
            if (name == null && !c.Any()) {
                var menu = new List<MenuDetail>();
                return Ok(menu);
            }
            var menuList = _menuService.GetMenuListByNameAsync(c, name, queryPage).Result;

            return Ok(menuList);
        }

        /// <summary>
        /// เรียก menuList จาก Category
        /// </summary>
        [HttpGet("name/category/")]
        public ActionResult<List<Menu>> GetMenuListByName([FromQuery] List<string> c, int? queryPage)
        {
            var menuList = _menuService.GetMenuListByCategory(c, queryPage);

            return Ok(menuList);
        }

        /// <summary>
        /// เพิ่มเมนู
        /// </summary>
        [HttpPost]
        public ActionResult<Menu> CreateMenu([FromForm] MenuDetail menu, IFormFile formFile)
        {
            var imageUrl = _blobService.UploadFoodImageFileAsync(formFile).Result;
            menu.ImageUrl = imageUrl;
            _menuService.CreateMenuAsync(menu);

            return CreatedAtAction(nameof(GetMenuDetailByName), new { name = menu.Name }, menu);
        }

    }
}