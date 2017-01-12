using Api.ClientModels;
using System.Collections.Generic;
using System.Linq;

namespace Api.Data
{
    public class MenuRepository : IMenuRepository
    {
        private readonly AppContext _appContext;
        public MenuRepository(
            AppContext appContext)
        {
            _appContext = appContext;
        }
        
        public IList<ClientMenuModel> GetMenus(int restaurantId)
        {
            return _appContext.Menus
            .Where(s => s.RestaurantId == restaurantId)
            .OrderBy(s => s.Name)
            .Select(s => new ClientMenuModel
            {
                Id = s.Id,
                Name = s.Name
            }
             )
            .ToList();
        }            

        public IList<ClientMenuSectionModel> GetMenuSections(int menuId)
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

        public IList<ClientMenuItemModel> GetMenuItems(int menuId, int? menuSectionId)
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