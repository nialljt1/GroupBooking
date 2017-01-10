﻿using Api.ClientModels;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

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

        public void AddDinerMenuItem(int dinerId, int menuItemId)
        {
            var dinerMenuItem = new DinerMenuItem();
            dinerMenuItem.DinerId = dinerId;
            dinerMenuItem.MenuItemId = menuItemId;
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