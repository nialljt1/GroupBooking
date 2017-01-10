using Api.Data;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Api.Controllers
{
    [Route("api/v1/[controller]")]
    ////[Authorize]
    public class MenuController : ControllerBase
    {
        public IMenuRepository Repo { get; set; }

        public MenuController([FromServices] IMenuRepository repo)
        {
            Repo = repo;
        }

        // GET GetMenuSections/1
        [HttpGet]
        [Route("GetMenuSections/{menuId}")]
        public IEnumerable<ClientModels.ClientMenuSectionModel> GetMenuSections(int menuId)
        {
            return Repo.GetMenuSections(menuId);
        }
    }
}