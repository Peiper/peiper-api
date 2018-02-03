
using System.Collections.Generic;
using System.Linq;
using PeiperApi.Domain.Models.Deploy;
using Raven.Client.Documents;

namespace api.Repository
{
    public interface IDeployRepository
    {
        List<SiteBuild> GetSiteBuildData(int count);
        SiteBuild Get(string id);
        SiteBuild StoreSiteBuild(SiteBuild data);
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

        public SiteBuild Get(string id)
        {
            using (var session = _store.OpenSession())
            {
                return  session.Load<SiteBuild>(id);
            }
        }

        public SiteBuild StoreSiteBuild(SiteBuild data)
        {
            using (var session = _store.OpenSession())
            {
                session.Store(data);
                session.SaveChanges();

                return data;
            }
        }
    }
}
