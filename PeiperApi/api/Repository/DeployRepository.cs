using System.Collections.Generic;
using System.Linq;
using PeiperApi.Domain.Models.Deploy;

namespace api.Repository
{
    public interface IDeployRepository
    {
        List<BuildData> GetSiteBuildData(int count);
    }
    public class DeployRepository : IDeployRepository
    {
        private readonly DbPsqlContext _context;
        public DeployRepository(DbPsqlContext context)
        {
            _context = context;
        }

        public List<BuildData> GetSiteBuildData(int count)
        {
            return _context.SiteBuildData.Take(count).ToList();
        }
    }
}
