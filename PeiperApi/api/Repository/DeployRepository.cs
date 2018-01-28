using System;
using System.Collections.Generic;
using System.Linq;
using PeiperApi.Domain.Models.Deploy;

namespace api.Repository
{
    public interface IDeployRepository
    {
        List<BuildData> GetSiteBuildData(int count);
        BuildData Get(int id);
        BuildData CreateSiteBuild(BuildData data);
        void SaveChanges();
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
            return _context.SiteBuildData.OrderByDescending(bd => bd.created).Take(count).ToList();
        }

        public BuildData Get(int id)
        {
            return _context.SiteBuildData.First(sb => sb.id == id);
        }

        public BuildData CreateSiteBuild(BuildData data)
        {
            _context.SiteBuildData.Add(data);
            _context.SaveChanges();
            return data;
        }

        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
