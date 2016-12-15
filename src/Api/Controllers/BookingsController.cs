using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Api.Data;
using Api.Models;
using System;
using System.Globalization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Authorization;
using Api.ClientModels;
using System.Linq;

namespace Api.Controllers
{
    [Route("[controller]")]
    ////[Authorize]
    public class BookingsController : ControllerBase
    {
        public IBookingsRepository Repo { get; set; }

        public BookingsController([FromServices] IBookingsRepository repo)
        {
            Repo = repo;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClientBooking booking)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                var bookingId = Repo.AddBooking(booking);
                var url = Url.RouteUrl("GetBookingByIdRoute", new { id = bookingId }, Request.Scheme,
                    Request.Host.ToUriComponent());
                // TODO: Need to handle navigating to edit page after adding
                return Ok(bookingId);

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("Update", Name = "UpdateBooking")]
        public IActionResult Update([FromBody] ClientBooking booking)
        {
            if (!ModelState.IsValid) return BadRequest();

            try
            {
                Repo.UpdateBooking(booking);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        // GET api/bookings/2
        [HttpGet()]
        [Route("GetBookingById/{id}", Name = "GetBookingById")]
        public ClientBooking GetBookingById(int id)
        {
            return Repo.GetBookingById(id);
        }

        // GET GetBookings/1
        [HttpPost]
        [Route("FilterBookings/{restaurantId}", Name = "FilterBookings")]
        public IEnumerable<ClientBooking> FilterBookings(int restaurantId, [FromBody] FilterCriteria filterCriteria)
        {
            return Repo.FilterBookings(restaurantId, filterCriteria);
        }
    }
}