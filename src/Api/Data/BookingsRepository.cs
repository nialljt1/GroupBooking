using System;
using System.Collections.Generic;
using System.Linq;
using Api.Models;
using Api.ClientModels;

namespace Api.Data
{
    public class BookingsRepository : IBookingsRepository
    {
        private readonly AppContext _appContext;
        public BookingsRepository(
            AppContext appContext)
        {
            _appContext = appContext;
        }

        public Guid AddBooking(ClientBookingModel clientBooking)
        {
            var booking = new Booking();
            booking.Id = new Guid();
            booking.OrganiserForename = clientBooking.FirstName;
            booking.OrganiserSurname = clientBooking.Surname;
            booking.OrganiserTelephoneNumber = clientBooking.TelephoneNumber;
            booking.OrganiserEmailAddress = clientBooking.EmailAddress;
            booking.StartingAt = clientBooking.StartingAt;
            booking.CutOffDate = clientBooking.CutOffDate;
            booking.NumberOfDiners = clientBooking.NumberOfDiners;
            // TODO: remove hardcoding of CreatedById and LastUpdatedById
            booking.CreatedById = "0d20e665-2859-418e-ae12-bece795627df";
            booking.LastUpdatedById = "0d20e665-2859-418e-ae12-bece795627df";
            booking.LastUpdatedAt = DateTimeOffset.Now;
            booking.CreatedAt = DateTimeOffset.Now;
            // TODO: remove hardcoding of menu id
            booking.MenuId = clientBooking.MenuId;
            booking.MenuId = 1;
            _appContext.Bookings.Add(booking);
            _appContext.SaveChanges();
            return booking.Id;
        }

        public void UpdateBooking(ClientBookingModel clientBooking)
        {
            var booking = _appContext.Bookings.Find(clientBooking.Id);
            booking.OrganiserForename = clientBooking.FirstName;
            booking.OrganiserSurname = clientBooking.Surname;
            booking.OrganiserTelephoneNumber = clientBooking.TelephoneNumber;
            booking.OrganiserEmailAddress = clientBooking.EmailAddress;
            booking.StartingAt = clientBooking.StartingAt;
            booking.CutOffDate = clientBooking.CutOffDate;
            booking.NumberOfDiners = clientBooking.NumberOfDiners;
            booking.CreatedById = "0d20e665-2859-418e-ae12-bece795627df";
            booking.LastUpdatedById = "0d20e665-2859-418e-ae12-bece795627df";
            booking.LastUpdatedAt = DateTimeOffset.Now;
            booking.CreatedAt = DateTimeOffset.Now;
            _appContext.SaveChanges();
        }

        public void UpdateStatus(Guid bookingId, int statusId)
        {
            var booking = _appContext.Bookings.Find(bookingId);
            booking.StatusId = statusId;
            _appContext.SaveChanges();
        }

        public IList<ClientBookingModel> FilterBookings(int restaurantId, FilterCriteria filterCriteria)
        {
            var bookings = _appContext.Bookings
                .Where(b => b.Menu.RestaurantId == restaurantId);

            if (filterCriteria.FromDate != null)
            {
                DateTime fromDateAsDate;
                if (DateTime.TryParse(filterCriteria.FromDate, out fromDateAsDate))
                {
                    bookings = bookings.Where(b => b.StartingAt <= fromDateAsDate);
                }                
            }

            if (filterCriteria.ToDate != null)
            {
                DateTime toDateAsDate;
                if (DateTime.TryParse(filterCriteria.ToDate, out toDateAsDate))
                {
                    bookings = bookings.Where(b => b.StartingAt <= toDateAsDate.AddDays(1));
                }
            }

            bookings = bookings.Where(b => b.IsCancelled == filterCriteria.isCancelled); 

            return bookings
                .Select(b => new ClientBookingModel
                {
                    Id  = b.Id,
                    FirstName = b.OrganiserForename,
                    Surname = b.OrganiserSurname,
                    TelephoneNumber = b.OrganiserTelephoneNumber,
                    EmailAddress = b.OrganiserEmailAddress,
                    StartingAt = b.StartingAt,
                    CutOffDate = b.CutOffDate,
                    NumberOfDiners = b.NumberOfDiners,
                    MenuId = b.MenuId,
                    Menu = b.Menu.Name
                })
                .OrderByDescending(b => b.StartingAt)
                .ToList();
        }

        public ClientBookingModel Get(Guid id)
        {
            var booking = _appContext.Bookings.Find(id);
            var menuName = _appContext.Menus.Find(booking.MenuId).Name;
            return new ClientBookingModel
            {
                Id = booking.Id,
                FirstName = booking.OrganiserForename,
                Surname = booking.OrganiserSurname,
                TelephoneNumber = booking.OrganiserTelephoneNumber,
                EmailAddress = booking.OrganiserEmailAddress,
                StartingAt = booking.StartingAt,
                CutOffDate = booking.CutOffDate,
                NumberOfDiners = booking.NumberOfDiners,
                Menu = menuName
            };            
        }

        public void DeleteBooking(Guid id)
        {
            var booking = _appContext.Bookings.Find(id);
            _appContext.Bookings.Remove(booking);
            _appContext.SaveChanges();
        }
    }
}