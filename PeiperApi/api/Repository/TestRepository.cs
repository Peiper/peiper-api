using System.Collections.Generic;
using System.Linq;

namespace api.Repository
{
    public interface ITestRepository
    {
        List<Test> GetAll();
    }
    public class TestRepository : ITestRepository
    {
        private readonly DbPsqlContext _context;
        public TestRepository(DbPsqlContext context)
        {
            _context = context;
        }

        public List<Test> GetAll()
        {
            return _context.TestData.Where(t => t.Var1 != "").ToList();
        }
    }
}
