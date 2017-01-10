using Api.ClientModels;
using System.Collections.Generic;

namespace Api.Data
{
    public interface IDinerMenuItemsRepository
    {
        void AddDinerMenuItem(int dinerId, int menuItemId);
        void DeleteDinerMenuItem(int id);
    }
}