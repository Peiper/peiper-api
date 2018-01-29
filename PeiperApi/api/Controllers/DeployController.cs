using System.Collections.Generic;
using api.Application;
using api.Repository;
using Microsoft.AspNetCore.Mvc;
using PeiperApi.Domain.Models;
using PeiperApi.Domain.Models.Deploy;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class DeployController : Controller
    {
        private readonly IDeployApplication _repository;

        public DeployController(IDeployApplication repository)
        {
            _repository = repository;
        }

        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Response<List<BuildData>>), Description = "GetSiteBuilds")]
        [HttpGet]
        [Route("sitebuilds/{count}")]
        public IActionResult GetSiteBuilds(int count)
        {
            if(count == 0){
                return BadRequest();
            }
            var value = _repository.GetSiteBuildData(count);
            return Ok(new Response<List<BuildData>>(value));
        }

        [SwaggerResponse((int)HttpStatusCode.OK, Type = typeof(Response<BuildData>), Description = "SaveSiteBuild")]
        [HttpPost]
        [Route("sitebuilds")]
        public IActionResult SaveSiteBuild([FromBody] BuildData data)
        {
            if(data == null){
                return BadRequest();
            }
            var value = _repository.SaveSiteBuild(data);
            return Ok(new Response<BuildData>(value));
        }
    }
}
