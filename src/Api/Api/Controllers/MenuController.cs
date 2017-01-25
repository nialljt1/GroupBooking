using Api.ClientModels;
using Api.Data;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api/v1/Menu")]
    ////[Authorize]
    public class MenuController : ApiController
    {
        private readonly AppContext _appContext;
        public MenuController()
            : this(new AppContext())
        {
        }
        public MenuController(
            AppContext appContext)
        {
            _appContext = appContext;
        }

        // GET GetMenus/1
        [HttpGet]
        [Route("GetMenus")]
        public IEnumerable<ClientMenuModel> GetMenus()
        {
            // TODO: Remove hardcoded restaurant id
            return _appContext.Menus
            .Where(s => s.RestaurantId == 1)
            .OrderBy(s => s.Name)
            .Select(s => new ClientMenuModel
            {
                Id = s.Id,
                Name = s.Name
            }
             )
            .ToList();
        }

        // GET GetMenuSections/1
        [HttpGet]
        [Route("GetMenuSections/{menuId}")]
        public IEnumerable<ClientMenuSectionModel> GetMenuSections(int menuId)
        {
            return _appContext.MenuSections
            .Where(s => s.MenuId == menuId)
            .OrderBy(s => s.DisplayOrder)
            .Select(s => new ClientMenuSectionModel
            {
                Id = s.Id,
                Name = s.Name
            }
                )
            .ToList();
        }

        // GET GetMenuItems/1
        [HttpGet]
        [Route("GetMenuItems/{menuId}/{menuSectionId:int?}")]
        public IEnumerable<ClientMenuItemModel> GetMenuItems(int menuId, int menuSectionId = 0)
        {
            var menuItems = _appContext.MenuItems.Where(i => i.MenuSection.MenuId == menuId);

            if (menuSectionId != 0)
            {
                menuItems = menuItems.Where(i => i.MenuSectionId == menuSectionId);
            }

            return menuItems
            .OrderBy(i => i.MenuSection.DisplayOrder)
            .ThenBy(i => i.DisplayOrder)
            .Select(i => new ClientMenuItemModel
            {
                Id = i.Id,
                Name = i.Name,
                Description = i.Description,
                DisplayOrder = i.DisplayOrder,
                MenuSectionId = i.MenuSectionId,
                Number = i.Number
            })
            .ToList();
        }
    }
}