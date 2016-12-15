using System.Collections.Generic;
using Api.Models;
using Api.ClientModels;

namespace Api.Data
{
    public interface IBookingsRepository
    {
        int AddBooking(ClientBooking booking);

        void UpdateBooking(ClientBooking booking);
        ClientBooking GetBookingById(int id);
        IList<ClientBooking> FilterBookings(int restaurantId, FilterCriteria filterCriteria);
    }
}