using Api.ClientModels;
using Api.Data;
using Exceptionless;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    ////[Authorize]
    public class DinerController : ControllerBase
    {
        public IDinersRepository Repo { get; set; }

        public DinerController([FromServices] IDinersRepository repo)
        {
            Repo = repo;
        }

        // Post
        [HttpPost]
        [Route("Post", Name = "Post")]
        public IActionResult Post([FromBody] ClientDinerModel dinerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var dinerId = Repo.AddDiner(dinerModel);
                return Ok(dinerId);

            }
            catch (Exception ex)
            {
                ex.ToExceptionless().Submit();
                return BadRequest();
            }
        }

        [HttpPut]
        [Route("Put", Name = "Put")]
        public IActionResult Put([FromBody] ClientDinerModel dinerModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                Repo.UpdateDiner(dinerModel);
                return Ok();

            }
            catch (Exception ex)
            {
                ex.ToExceptionless().Submit();
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("Delete/{id}", Name = "Delete")]
        public IActionResult Delete(int id)
        {
            try
            {
                Repo.DeleteDiner(id);
                return Ok();

            }
            catch (Exception ex)
            {
                ex.ToExceptionless().Submit();
                return BadRequest();
            }
        }

        [HttpGet]
        [Route("GetDinersForBooking/{bookingId}")]
        public IEnumerable<ClientDinerModel> GetDinersForBooking(int bookingId)
        {
            try
            {
                return Repo.GetDinersForBooking(bookingId);

            }
            catch (Exception ex)
            {
                ex.ToExceptionless().Submit();
                return new List<ClientDinerModel>();
            }
        }
    }
}