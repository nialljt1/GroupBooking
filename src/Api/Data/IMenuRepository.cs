using System.Collections.Generic;
using Api.Models;
using Api.ClientModels;

namespace Api.Data
{
    public interface IMenuRepository
    {
        IList<ClientMenuModel> GetMenus(int restaurantId);

        IList<ClientMenuSectionModel> GetMenuSections(int menuId);

        IList<ClientMenuItemModel> GetMenuItems(int menuId, int? menuSectionId);
    }
}