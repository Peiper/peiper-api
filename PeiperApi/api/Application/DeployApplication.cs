using System;
using System.Collections.Generic;
using api.Repository;
using PeiperApi.Domain.Models.Deploy;

namespace api.Application
{
    public interface IDeployApplication
    {
        List<SiteBuild> GetSiteBuildData(int count);
        SiteBuild SaveSiteBuild(SiteBuild data);
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

        public SiteBuild SaveSiteBuild(SiteBuild data)
        {
            if (data.Id == "")
            {
                return _repository.StoreSiteBuild(new SiteBuild(data.Hash, data.Message));
            }

            return UpdateSiteBuild(data);
        }

        private SiteBuild UpdateSiteBuild(SiteBuild data)
        {
            var dbdata = _repository.Get(data.Id);
            if (dbdata == null)
            {
                throw new ArgumentException("data not found");
            }

            dbdata.Status = data.Status;
            dbdata.Updated = DateTime.Now;

            return _repository.StoreSiteBuild(data);
        }
    }
}
