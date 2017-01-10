using Api.ClientModels;
using Api.Models;

namespace Api.Data
{
    public class DinerMenuItemsRepository : IDinerMenuItemsRepository
    {
        private readonly AppContext _appContext;
        public DinerMenuItemsRepository(
            AppContext appContext)
        {
            _appContext = appContext;
        }

        public void AddDinerMenuItem(ClientDinerMenuItemModel dinerMenuItemModel)
        {
            var dinerMenuItem = new DinerMenuItem();
            dinerMenuItem.DinerId = dinerMenuItemModel.DinerId;
            dinerMenuItem.MenuItemId = dinerMenuItemModel.MenuItemId;
            dinerMenuItem.Note = dinerMenuItemModel.DinerMenuItemNote;
            _appContext.DinerMenuItems.Add(dinerMenuItem);
            _appContext.SaveChanges();
        }

        public void DeleteDinerMenuItem(int id)
        {
            var dinerMenuItem = _appContext.DinerMenuItems.Find(id);
            _appContext.DinerMenuItems.Remove(dinerMenuItem);
            _appContext.SaveChanges();
        }
    }
}