using Api.ClientModels;
using Api.Data;
using Exceptionless;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    ////[Authorize]
    public class DinerMenuController : ControllerBase
    {
        public IDinerMenuItemsRepository Repo { get; set; }

        public DinerMenuController([FromServices] IDinerMenuItemsRepository repo)
        {
            Repo = repo;
        }

        // Post
        [HttpPost]
        [Route("Post")]
        public IActionResult Post([FromBody] ClientDinerMenuItemModel dinerMenuItemModel)
        {
            try
            {
                Repo.AddDinerMenuItem(dinerMenuItemModel);
                return Ok();

            }
            catch (Exception ex)
            {
                ex.ToExceptionless().Submit();
                return BadRequest();
            }
        }

        [HttpDelete]
        [Route("Delete/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                Repo.DeleteDinerMenuItem(id);
                return Ok();

            }
            catch (Exception ex)
            {
                ex.ToExceptionless().Submit();
                return BadRequest();
            }
        }
    }
}