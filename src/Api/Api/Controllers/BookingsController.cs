
using System.Collections.Generic;
using System;
using Api.ClientModels;
using System.Web.Http;
using System.Net.Http;
using System.Net;
using Api.Models;
using System.Linq;

namespace Api.Controllers
{
    [RoutePrefix("api/v1/Bookings")]
    ////[Authorize]
    public class BookingsController: ApiController
    {
        private readonly AppContext _appContext;

        public BookingsController()
            : this(new AppContext())
        {
        }

        public BookingsController(
            AppContext appContext)
        {
            _appContext = appContext;
        }

        [HttpPost]
        [Route("")]
        public IHttpActionResult Post([FromBody] ClientBookingModel clientBooking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
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
                return Ok(booking.Id);

            }
            catch (Exception ex)
            {
                ////ex.ToExceptionless().Submit();
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult Put([FromBody] ClientBookingModel clientBooking)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
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
                return Ok();

            }
            catch (Exception ex)
            {
                ////ex.ToExceptionless().Submit();
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("UpdateStatus/{bookingId}/{statusId}")]
        public IHttpActionResult UpdateStatus(Guid bookingId, int statusId)
        {
            try
            {
                var booking = _appContext.Bookings.Find(bookingId);
                booking.StatusId = statusId;
                _appContext.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {
                ////ex.ToExceptionless().Submit();
                return BadRequest();
            }
        }

        // GET api/bookings/2
        [HttpGet]
        [Route("{id}")]
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

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(Guid id)
        {
            try
            {
                var booking = _appContext.Bookings.Find(id);
                _appContext.Bookings.Remove(booking);
                _appContext.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {
                ////ex.ToExceptionless().Submit();
                return BadRequest();
            }
        }

        // GET GetBookings/1
        [HttpPost]
        [Route("FilterBookings/{restaurantId}")]
        public IEnumerable<ClientBookingModel> FilterBookings(int restaurantId, [FromBody] FilterCriteria filterCriteria)
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
                    Id = b.Id,
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

        [HttpGet]
        [Route("ExportToExcel")]
        public HttpResponseMessage ExportToExcel()
        {
            ////var str = new StringBuilder();
            ////str.Append("<table border=`" + "1px" + "`b>");
            ////str.Append("<tr>");
            ////str.Append("<td><b><font face=Arial Narrow size=3>FName</font></b></td>");
            ////str.Append("<td><b><font face=Arial Narrow size=3>LName</font></b></td>");
            ////str.Append("<td><b><font face=Arial Narrow size=3>Address</font></b></td>");
            ////str.Append("</tr>");  
            ////str.Append("<tr>");
            ////str.Append("<td><font face=Arial Narrow size=14px>Test1</font></td>");
            ////str.Append("<td><font face=Arial Narrow size=14px>test2</font></td>");
            ////str.Append("<td><font face=Arial Narrow size=14px>test3</font></td>");
            ////str.Append("</tr>");
            
            ////str.Append("</table>");           
            ////byte[] temp = System.Text.Encoding.UTF8.GetBytes(str.ToString());
            ////return File(temp, "application/vnd.ms-excel", "Test.xls");

            ////var reportStream = GenerateExcelReport(scheduleId);
            var result = Request.CreateResponse(HttpStatusCode.OK);

            ////result.Content = new StreamContent(reportStream);
            ////result.Content.Headers.ContentType = new MediaTypeHeaderValue("application/octet-stream");
            ////result.Content.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
            ////{
            ////    FileName = "Schedule Report.xlsx"
            ////};

            return result;
        }
    }
}