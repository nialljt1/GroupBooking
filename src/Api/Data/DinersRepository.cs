using Api.ClientModels;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Api.Data
{
    public class DinersRepository : IDinersRepository
    {
        private readonly AppContext _appContext;
        public DinersRepository(
            AppContext appContext)
        {
            _appContext = appContext;
        }

        public int AddDiner(ClientDinerModel dinerModel)
        {
            var diner = new Diner();
            diner.Forename = dinerModel.Forename;
            diner.Surname = dinerModel.Surname;
            diner.BookingId = dinerModel.BookingId;
            diner.AddedByForename = dinerModel.AddedByForename;
            diner.AddedBySurname = dinerModel.AddedBySurname;
            diner.AddedByEmailAddress = dinerModel.AddedByEmailAddress;
            diner.AddedAt = DateTimeOffset.Now;
            diner.LastUpdatedById = dinerModel.UserId;
            diner.LastUpdatedAt = DateTimeOffset.Now;
            _appContext.Diners.Add(diner);
            _appContext.SaveChanges();
            return diner.Id;
        }

        public void UpdateDiner(ClientDinerModel dinerModel)
        {
            var diner = _appContext.Diners.Find(dinerModel.Id);
            diner.Forename = dinerModel.Forename;
            diner.Surname = dinerModel.Surname;
            diner.LastUpdatedById = dinerModel.UserId;
            diner.LastUpdatedAt = DateTimeOffset.Now;
            _appContext.SaveChanges();
        }

        public void DeleteDiner(int id)
        {
            var diner = _appContext.Diners.Find(id);
            _appContext.Diners.Remove(diner);
            _appContext.SaveChanges();
        }

        public IList<ClientDinerModel> GetDinersForBooking(int bookingId)
        {
            var dinerModels = new List<ClientDinerModel>();

            var menuSections = _appContext.Bookings
                .Where(b => b.Id == bookingId)
                .Select(b => b.Menu)
                .SelectMany(m => m.MenuSections)
                .OrderBy(s => s.DisplayOrder)
                .Select(s => new { s.Id, s.Name })
                .ToList();

            var dinerMenuItems = _appContext.DinerMenuItems
            .Where(d => d.Diner.BookingId == bookingId)
            .Select(s => new ClientMenuItemModel
            {
                MenuItemId = s.MenuItemId,
                DinerId = s.DinerId,
                Note = s.Note,
                Number = s.MenuItem.Number,
                Name = s.MenuItem.Name,
                Description = s.MenuItem.Description,
                DisplayOrder = s.MenuItem.DisplayOrder,
                MenuSectionId = s.MenuItem.MenuSectionId            
            })
            .ToList();

            var diners = _appContext.Diners.Where(d => d.BookingId == bookingId)
            .Select(d => new ClientDinerModel
            {
                Id = d.Id,
                Forename = d.Forename,
                Surname = d.Surname,
                AddedByEmailAddress = d.AddedByEmailAddress,
                AddedByForename = d.AddedByForename,
                AddedBySurname = d.AddedBySurname,
                BookingId = bookingId
            })
            .OrderBy(d => d.Surname)
            .ToList();

            foreach (var diner in diners)
            {
                foreach (var menuSection in menuSections)
                {                   
                    var menuItem = dinerMenuItems
                        .Where(i => i.DinerId == diner.Id)
                        .FirstOrDefault(i => i.MenuSectionId == menuSection.Id);

                    if (menuItem != null)
                    {
                        var clientDinerMenuItemModel = new ClientDinerMenuItemModel();
                        clientDinerMenuItemModel.MenuSectionId = menuSection.Id;
                        clientDinerMenuItemModel.MenuSectionName = menuSection.Name;
                        clientDinerMenuItemModel.MenuItemId = menuItem.MenuItemId;
                        clientDinerMenuItemModel.DinerId = diner.Id;
                        clientDinerMenuItemModel.Name = menuItem.Name;
                        clientDinerMenuItemModel.Description = menuItem.Description;
                        clientDinerMenuItemModel.DisplayOrder = menuItem.DisplayOrder;
                        clientDinerMenuItemModel.DinerMenuItemNote = menuItem.Note;
                        diner.MenuItems.Add(clientDinerMenuItemModel);
                    }
                }

                dinerModels.Add(diner);
            }

            return dinerModels;
        }
    }
}