using System.Collections.Generic;
using Api.Models;
using Api.ClientModels;
using System;

namespace Api.Data
{
    public interface IDinersRepository
    {
        int AddDiner(ClientDinerModel diner);
        void UpdateDiner(ClientDinerModel diner);
        void DeleteDiner(int id);
        IList<ClientDinerModel> GetDinersForBooking(Guid bookingId);
    }
}