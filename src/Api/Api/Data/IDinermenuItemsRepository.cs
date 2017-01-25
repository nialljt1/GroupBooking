using Api.ClientModels;
using System.Collections.Generic;

namespace Api.Data
{
    public interface IDinerMenuItemsRepository
    {
        void AddDinerMenuItem(ClientDinerMenuItemModel dinerMenuItemModel);
        void DeleteDinerMenuItem(int id);
    }
}