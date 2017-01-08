using System.Collections.Generic;
using Api.Models;

namespace Api.Data
{
    public interface IMenuRepository
    {
        IList<ClientModels.ClientMenuSectionModel> GetMenuSections(int menuId);
    }
}