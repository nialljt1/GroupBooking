
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
using Exceptionless;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    ////[Authorize]
    public class BookingsController : ControllerBase
    {
        public IBookingsRepository Repo { get; set; }

        public BookingsController([FromServices] IBookingsRepository repo)
        {
            Repo = repo;
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClientBookingModel booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var bookingId = Repo.AddBooking(booking);   
                return Ok(bookingId);

            }
            catch (Exception ex)
            {
                ex.ToExceptionless().Submit();
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("Update")]
        public IActionResult Update([FromBody] ClientBookingModel booking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                Repo.UpdateBooking(booking);
                return Ok();

            }
            catch (Exception ex)
            {
                ex.ToExceptionless().Submit();
                return BadRequest();
            }
        }

        // GET api/bookings/2
        [HttpGet()]
        [Route("GetBookingById/{id}")]
        public ClientBookingModel GetBookingById(int id)
        {
            return Repo.GetBookingById(id);
        }


        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Repo.DeleteBooking(id);
                return Ok();

            }
            catch (Exception ex)
            {
                ex.ToExceptionless().Submit();
                return BadRequest();
            }
        }

        // GET GetBookings/1
        [HttpPost]
        [Route("FilterBookings/{restaurantId}", Name = "FilterBookings")]
        public IEnumerable<ClientBookingModel> FilterBookings(int restaurantId, [FromBody] FilterCriteria filterCriteria)
        {
            return Repo.FilterBookings(restaurantId, filterCriteria);
        }
    }
}