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

        [HttpGet]
        [Route("/sitebuilds/{count}")]
        public Response<List<BuildData>> GetSiteBuilds(int count)
        {
            var value = _repository.GetSiteBuildData(count);
            return new Response<List<BuildData>>(value);
        }

        [HttpPost]
        [Route("/sitebuilds/{id}")]
        public Response<BuildData> SaveSiteBuild(BuildData data)
        {
            var value = _repository.SaveSiteBuild(data);
            return new Response<BuildData>(value);
        }
    }
}