
using System.Collections.Generic;
using System.Linq;
using PeiperApi.Domain.Models.Deploy;
using Raven.Client.Documents;

namespace api.Repository
{
    public interface IDeployRepository
    {
        List<SiteBuild> GetSiteBuildData(int count);
        List<ApiBuild> GetApiBuildData(int count);
    }

    public class DeployRepository : IDeployRepository
    {
        private readonly IDocumentStore _store;
        public DeployRepository(IDocumentStoreHolder store)
        {
            _store = store.StoreDeploy;
        }

        public List<SiteBuild> GetSiteBuildData(int count)
        {
            using (var session = _store.OpenSession())
            {
               return session.Query<SiteBuild>().ToList().OrderByDescending(bd => bd.Created).Take(count).ToList();
            }
        }

        public List<ApiBuild> GetApiBuildData(int count)
        {
            using (var session = _store.OpenSession())
            {
                return session.Query<ApiBuild>().ToList().OrderByDescending(bd => bd.Created).Take(count).ToList();
            }
        }
    }
}
