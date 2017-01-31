using System.Collections.Generic;
using Api.Models;
using Api.ClientModels;
using System;

namespace Api.Data
{
    public interface IBookingsRepository
    {
        Guid AddBooking(ClientBookingModel booking);

        void UpdateBooking(ClientBookingModel booking);
        void UpdateStatus(Guid bookingId, int statusId);
        ClientBookingModel Get(Guid id);
        IList<ClientBookingModel> FilterBookings(int restaurantId, string fromDate, string toDate, bool isCancelled);
        void DeleteBooking(Guid id);
    }
}