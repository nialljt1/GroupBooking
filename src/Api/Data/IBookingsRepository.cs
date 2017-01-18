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
        ClientBookingModel Get(Guid id);
        IList<ClientBookingModel> FilterBookings(int restaurantId, FilterCriteria filterCriteria);
        void DeleteBooking(Guid id);
    }
}