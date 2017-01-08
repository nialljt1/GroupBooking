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
            diner.CreatedById = dinerModel.UserId;
            diner.LastUpdatedById = dinerModel.UserId;
            diner.CreatedAt = DateTimeOffset.Now;
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
            var diners = _appContext.Diners.Where(d => d.BookingId == bookingId)
                .Select(d => new ClientDinerModel
                {
                    Id = d.Id,
                    Forename = d.Forename,
                    Surname = d.Surname
                })
                .ToList();

            var booking = _appContext.Bookings.Find(bookingId);
            var menuSectionIds = _appContext.MenuSections
                .Where(d => d.MenuId == booking.MenuId)
                .OrderBy(s => s.DisplayOrder)
                .Select(s => s.Id)
                .ToList();

            var dinerMenuItems = _appContext.DinerMenuItems
            .Where(d => d.Diner.BookingId == bookingId)
            .Select(s => new { s.MenuItem.Number, s.MenuItem.Name, s.MenuItem.Description, s.MenuItem.DisplayOrder, s.MenuItem.MenuSectionId })
            .ToList();

            // review and commit what you've done
            // before doing any of the below need to create api methods for adding and deleting menu items
            // TODO: Create model for menu items
            // amend diner model to contain a list of menu sections
            // amend menu sections to contain a list of menu items
            // cycle through each diner
            // cycle through menu sections
            // include items for each model

            var menuItems = _appContext.Diners.Where(d => d.BookingId == bookingId)
            .Select(d => new ClientDinerModel
            {
                Id = d.Id,
                Forename = d.Forename,
                Surname = d.Surname
            })
            .ToList();

            var dinerModels = new List<ClientDinerModel>();
            return dinerModels;
        }
    }
}