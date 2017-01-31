
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
using System.Text;
using System.Web.Http;

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

        [HttpPut]
        [Route("UpdateStatus/{bookingId}/{statusId}")]
        public IActionResult UpdateStatus(Guid bookingId, int statusId)
        {
            try
            {
                Repo.UpdateStatus(bookingId, statusId);
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
        [HttpGet]
        [Route("FilterBookings")]
        public IEnumerable<ClientBookingModel> FilterBookings([FromQuery] string fromDate, [FromQuery] string toDate, [FromQuery] bool isCancelled)
        {
            // TODO: Get Restaurant Id from user
            var restaurantId = 1;
            return Repo.FilterBookings(restaurantId, fromDate, toDate, isCancelled);
        }

        [HttpGet]
        [Route("ExportToExcel")]
        public FileContentResult ExportToExcel()
        {
            var str = new StringBuilder();
            str.Append("<table border=`" + "1px" + "`b>");
            str.Append("<tr>");
            str.Append("<td><b><font face=Arial Narrow size=3>FName</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>LName</font></b></td>");
            str.Append("<td><b><font face=Arial Narrow size=3>Address</font></b></td>");
            str.Append("</tr>");  
            str.Append("<tr>");
            str.Append("<td><font face=Arial Narrow size=14px>Test1</font></td>");
            str.Append("<td><font face=Arial Narrow size=14px>test2</font></td>");
            str.Append("<td><font face=Arial Narrow size=14px>test3</font></td>");
            str.Append("</tr>");            
            str.Append("</table>");           
            byte[] temp = System.Text.Encoding.UTF8.GetBytes(str.ToString());
            return File(temp, "application/vnd.ms-excel", "Test.xls");
        }
    }
}