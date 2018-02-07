using System;
using System.Collections.Generic;
using api.Repository;
using PeiperApi.Domain.Models.Deploy;

namespace api.Application
{
    public interface IDeployApplication
    {
        List<SiteBuild> GetSiteBuildData(int count);
        List<ApiBuild> GetApiBuildData(int count);
    }
    public class DeployApplication : IDeployApplication
    {
        private readonly IDeployRepository _repository;

        public DeployApplication(IDeployRepository repository)
        {
            _repository = repository;
        }
        public List<SiteBuild> GetSiteBuildData(int count)
        {
            return _repository.GetSiteBuildData(count);
        }

        public List<ApiBuild> GetApiBuildData(int count)
        {
            return _repository.GetApiBuildData(count);
        }
    }
}
