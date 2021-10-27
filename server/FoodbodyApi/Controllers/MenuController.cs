using System.Collections.Generic;
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
        public ActionResult<List<Menu>> GetMenuList()
        {
            var menuList = _menuService.GetMenuListAsync().Result;

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
        /// เรียก menuList ที่มีชื่อตรงกับที่ใส่
        /// </summary>
        [HttpGet("name/{name}")]
        public ActionResult<List<Menu>> GetMenuListByName(string name, int? queryPage)
        {
            var menuList = _menuService.GetMenuListByNameAsync(name, queryPage).Result;

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