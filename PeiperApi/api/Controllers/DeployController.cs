using System.Collections.Generic;
using api.Models;
using api.Repository;
using Microsoft.AspNetCore.Mvc;
using PeiperApi.Domain.Models;
using PeiperApi.Domain.Models.Deploy;

namespace api.Controllers
{
    [Route("api/[controller]")]
    public class DeployController : Controller
    {
        private readonly IDeployRepository _repository;

        public DeployController(IDeployRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        [Route("/sitebuilds/{count}")]
        public Response<List<BuildData>> GetSiteBuilds(int count)
        {
            var value = _repository.GetSiteBuildData(count);
            return new Response<List<BuildData>>(value);
        }
    }
}