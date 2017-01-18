
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
        public IActionResult Put([FromBody] ClientBookingModel booking)
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
        [Route("{id}")]
        public ClientBookingModel Get(Guid id)
        {
            return Repo.Get(id);
        }


        [HttpDelete]
        [Route("{id}")]
        public IActionResult Delete(Guid id)
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
        [Route("FilterBookings/{restaurantId}")]
        public IEnumerable<ClientBookingModel> FilterBookings(int restaurantId, [FromBody] FilterCriteria filterCriteria)
        {
            return Repo.FilterBookings(restaurantId, filterCriteria);
        }
    }
}