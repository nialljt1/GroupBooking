using System.Collections.Generic;
using Api.Models;
using Api.ClientModels;

namespace Api.Data
{
    public interface IBookingsRepository
    {
        int AddBooking(ClientBookingModel booking);

        void UpdateBooking(ClientBookingModel booking);
        ClientBookingModel Get(int id);
        IList<ClientBookingModel> FilterBookings(int restaurantId, FilterCriteria filterCriteria);
        void DeleteBooking(int id);
    }
}