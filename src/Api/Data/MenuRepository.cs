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

        public IList<ClientModels.ClientMenuSectionModel> GetMenuSections(int menuId)
        {
            return _appContext.MenuSections
                .Where(s => s.MenuId == menuId)
                .OrderBy(s => s.DisplayOrder)
                .Select(s => new ClientModels.ClientMenuSectionModel
                    {
                        Id = s.Id,
                        Name = s.Name
                    }
                 )
                .ToList();
        }
    }
}