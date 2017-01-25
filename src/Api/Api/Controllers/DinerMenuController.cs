using Api.ClientModels;
using Api.Data;
using Api.Models;
using System;
using System.Web.Http;

namespace Api.Controllers
{
    [RoutePrefix("api/v1/DinerMenu")]
    ////[Authorize]
    public class DinerMenuController : ApiController
    {
        private readonly AppContext _appContext;
        public DinerMenuController()
            : this(new AppContext())
        {
        }

        public DinerMenuController(
            AppContext appContext)
        {
            _appContext = appContext;
        }

        // Post
        [HttpPost]
        [Route("")]
        public IHttpActionResult Post([FromBody] ClientDinerMenuItemModel dinerMenuItemModel)
        {
            try
            {
                var dinerMenuItem = new DinerMenuItem();
                dinerMenuItem.DinerId = dinerMenuItemModel.DinerId;
                dinerMenuItem.MenuItemId = dinerMenuItemModel.MenuItemId;
                dinerMenuItem.Note = dinerMenuItemModel.DinerMenuItemNote;
                _appContext.DinerMenuItems.Add(dinerMenuItem);
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
                var dinerMenuItem = _appContext.DinerMenuItems.Find(id);
                _appContext.DinerMenuItems.Remove(dinerMenuItem);
                _appContext.SaveChanges();
                return Ok();

            }
            catch (Exception ex)
            {
                ////ex.ToExceptionless().Submit();
                return BadRequest();
            }
        }
    }
}