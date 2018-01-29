using System;
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
                return _repository.CreateSiteBuild(new BuildData(data.hash, data.message));
            }

            return UpdateSiteBuild(data);
        }

        private BuildData UpdateSiteBuild(BuildData data)
        {
            var dbdata = _repository.Get(data.id);
            if (dbdata == null)
            {
                throw new ArgumentException("data not found");
            }

            dbdata.status = data.status;
            dbdata.updated = DateTime.Now;

            _repository.SaveChanges();
            return dbdata;
        }
    }
}
