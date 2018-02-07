using System.Collections.Generic;
using System.Net;
using api.Application;
using api.Repository;
using Microsoft.AspNetCore.Mvc;
using PeiperApi.Domain.Models;
using PeiperApi.Domain.Models.Deploy;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class DeployController : Controller
    {
        private readonly IDeployApplication _application;

        public DeployController(IDeployApplication application)
        {
            _application = application;
        }

        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Response<List<BuildData>>), Description = "GetSiteBuilds")]
        [HttpGet]
        [Route("sitebuilds/{count}")]
        public IActionResult GetSiteBuilds(int count)
        {
            if(count == 0){
                return BadRequest();
            }
            var value = _application.GetSiteBuildData(count);
            return Ok(new Response<List<SiteBuild>>(value));
        }
        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Response<List<BuildData>>), Description = "GetApiBuilds")]
        [HttpGet]
        [Route("apibuilds/{count}")]
        public IActionResult GetApiBuilds(int count)
        {
            if (count == 0)
            {
                return BadRequest();
            }
            var value = _application.GetApiBuildData(count);
            return Ok(new Response<List<ApiBuild>>(value));
        }
    }
}
