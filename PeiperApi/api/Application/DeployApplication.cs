using System.Collections.Generic;
using api.Repository;
using PeiperApi.Domain.Models.Deploy;

namespace api.Application
{
    public interface IDeployApplication
    {
        List<BuildData> GetSiteBuildData(int count);
        BuildData SaveSiteBuild(BuildData data);
    }
    public class DeployApplication : IDeployApplication
    {
        private readonly IDeployRepository _repository;

        public DeployApplication(IDeployRepository repository)
        {
            _repository = repository;
        }
        public List<BuildData> GetSiteBuildData(int count)
        {
            return _repository.GetSiteBuildData(count);
        }

        public BuildData SaveSiteBuild(BuildData data)
        {
            if (data.id == 0)
            {
                return _repository.CreateSiteBuild(data);
            }

            return _repository.UpdateSiteBuild(data);
        }
    }
}
