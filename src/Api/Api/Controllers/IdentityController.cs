// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;

namespace Api.Controllers
{
    [Route("[controller]")]
    [Authorize]
    public class IdentityController : ApiController
    {
        ////[HttpGet]
        ////public IHttpActionResult Get()
        ////{
        ////    return new System.Web.Mvc.JsonResult(from c in User.Claims select new { c.Type, c.Value });
        ////}
    }
}