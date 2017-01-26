using Api.ClientModels;
using Api.CORS;
using Api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api/v1/Diner")]
    ////[Authorize]
    [MyCorsPolicy]
    public class DinerController : ApiController
    {
        private readonly AppContext _appContext;

        public DinerController()
            : this(new AppContext())
        {
        }

        public DinerController(
            AppContext appContext)
        {
            _appContext = appContext;
        }

        // Post
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post([FromBody] ClientDinerModel dinerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var diner = new Diner();
                diner.Forename = dinerModel.Forename;
                diner.Surname = dinerModel.Surname;
                diner.BookingId = dinerModel.BookingId;
                diner.AddedByEmailAddress = dinerModel.AddedByEmailAddress;
                diner.AddedAt = DateTimeOffset.Now;
                diner.LastUpdatedById = dinerModel.UpdatedByUserId;
                diner.LastUpdatedAt = DateTimeOffset.Now;
                _appContext.Diners.Add(diner);
                _appContext.SaveChanges();
                return Ok(diner.Id);
            }
            catch (Exception ex)
            {
                ////ex.ToExceptionless().Submit();
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("")]
        public IHttpActionResult Put([FromBody] ClientDinerModel dinerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var diner = _appContext.Diners.Find(dinerModel.Id);
                diner.Forename = dinerModel.Forename;
                diner.Surname = dinerModel.Surname;
                diner.LastUpdatedById = dinerModel.UpdatedByUserId;
                diner.LastUpdatedAt = DateTimeOffset.Now;
                _appContext.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {
                ////ex.ToExceptionless().Submit();
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public IHttpActionResult Delete(int id)
        {
            try
            {
                var diner = _appContext.Diners.Find(id);
                _appContext.Diners.Remove(diner);
                _appContext.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {
                ////ex.ToExceptionless().Submit();
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetDinersForBooking/{bookingId}")]
        public IEnumerable<ClientDinerModel> GetDinersForBooking(Guid bookingId)
        {
            try
            {
                var dinerModels = new List<ClientDinerModel>();

                var menuSections = _appContext.Bookings
                    .Where(b => b.Id == bookingId)
                    .Select(b => b.Menu)
                    .SelectMany(m => m.MenuSections)
                    .OrderBy(s => s.DisplayOrder)
                    .Select(s => new { s.Id, s.Name })
                    .ToList();

                var dinerMenuItems = _appContext.DinerMenuItems
                .Where(d => d.Diner.BookingId == bookingId)
                .Select(s => new ClientDinerMenuItemModel
                {
                    MenuItemId = s.MenuItemId,
                    DinerId = s.DinerId,
                    DinerMenuItemNote = s.Note,
                    Name = s.MenuItem.Name,
                    Description = s.MenuItem.Description,
                    DisplayOrder = s.MenuItem.DisplayOrder,
                    MenuSectionId = s.MenuItem.MenuSectionId
                })
                .ToList();

                var diners = _appContext.Diners.Where(d => d.BookingId == bookingId)
                .Select(d => new ClientDinerModel
                {
                    Id = d.Id,
                    Forename = d.Forename,
                    Surname = d.Surname,
                    AddedByEmailAddress = d.AddedByEmailAddress,
                    BookingId = bookingId
                })
                .OrderBy(d => d.Surname)
                .ToList();

                foreach (var diner in diners)
                {
                    foreach (var menuSection in menuSections)
                    {
                        var menuItem = dinerMenuItems
                            .Where(i => i.DinerId == diner.Id)
                            .FirstOrDefault(i => i.MenuSectionId == menuSection.Id);

                        if (menuItem != null)
                        {
                            var clientDinerMenuItemModel = new ClientDinerMenuItemModel();
                            clientDinerMenuItemModel.MenuSectionId = menuSection.Id;
                            clientDinerMenuItemModel.MenuSectionName = menuSection.Name;
                            clientDinerMenuItemModel.MenuItemId = menuItem.MenuItemId;
                            clientDinerMenuItemModel.DinerId = diner.Id;
                            clientDinerMenuItemModel.Name = menuItem.Name;
                            clientDinerMenuItemModel.Description = menuItem.Description;
                            clientDinerMenuItemModel.DisplayOrder = menuItem.DisplayOrder;
                            clientDinerMenuItemModel.DinerMenuItemNote = menuItem.DinerMenuItemNote;
                            diner.MenuItems.Add(clientDinerMenuItemModel);
                        }
                    }

                    dinerModels.Add(diner);
                }

                return dinerModels;
            }
            catch (Exception ex)
            {
                ////ex.ToExceptionless().Submit();
                return new List<ClientDinerModel>();
            }
        }
    }
}