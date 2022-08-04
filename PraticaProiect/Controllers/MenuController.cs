using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PracticaProiect.Entities;
using PracticaProiect.ExternalModels;
using PracticaProiect.Services.UnitsOfWork;

namespace PraticaProiect.Controllers
{
    [Route("menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IMenuUnitOfWork _menuUnit;
        private readonly IMapper _mapper;
        public MenuController(IMenuUnitOfWork menuUnit, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(menuUnit));
            _menuUnit = menuUnit ?? throw new ArgumentNullException(nameof(mapper));
        }

        [HttpGet, Authorize]
        [Route("{id}", Name = "GetMenu")]
        public IActionResult GetMenu(Guid id)
        {
            var menuEntity = _menuUnit.Menus.Get(id);
            if (menuEntity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<MenuDTO>(menuEntity));
        }
        [HttpGet, Authorize]
        [Route("", Name = "GetAllMenus")]
        public IActionResult GetAllMenus()
        {
            var menuEntities = _menuUnit.Menus.Find(o => o.Deleted == false || o.Deleted == null);
            if (menuEntities == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<List<MenuDTO>>(menuEntities));
        }

        [HttpGet, Authorize]
        [Route("details/{id}", Name = "GetMenuDetails")]
        public IActionResult GetMenuDetails(Guid id)
        {
            var menuEntity = _menuUnit.Menus.GetMenuDetails(id);
            if (menuEntity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<MenuDTO>(menuEntity));
        }

        [HttpPost, Authorize]
        [Route("add", Name = "AddMenu")]
        public IActionResult AddMenu([FromBody] MenuDTO menu)
        {
            var menuEntity = _mapper.Map<Menu>(menu);
            _menuUnit.Menus.Add(menuEntity);
            _menuUnit.Complete();
            _menuUnit.Menus.Get(menu.ID);
            return CreatedAtRoute("GetMenu", new { id = menu.ID }, _mapper.Map<MenuDTO>(menuEntity));
        }

        [HttpGet, Authorize]
        [Route("category/{categoryId}", Name = "GetCategoryDetails")]
        public IActionResult GetCategoryDetails(Guid categoryId)
        {
            var categoryEntity = _menuUnit.Categories.GetCategoryDetails(categoryId);
            if (categoryEntity == null)
            {
                return NotFound();
            }
            return Ok(_mapper.Map<CategoryDTO>(categoryEntity));
        }
        [HttpDelete, Authorize]
        [Route("delete/{id}", Name = "DeleteMenu")]
        public IActionResult DeleteMenu(Guid id)
        {
            var menuEntity = _menuUnit.Menus.Get(id);
            if (menuEntity == null)
            {
                return NotFound();
            }
            menuEntity.Deleted = true;
            _menuUnit.Menus.Remove(menuEntity);
            _menuUnit.Complete();
            return NoContent();
        }
    }
}
