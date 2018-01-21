using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Repository
{
    public interface ITestRepository
    {
        Task<List<Test>> GetAll();
    }
    public class TestRepository : ITestRepository
    {
        private readonly DbPsqlContext _context;
        public TestRepository(DbPsqlContext context)
        {
            _context = context;
        }

        public async Task<List<Test>> GetAll()
        {
            return await _context.TestData.ToListAsync();
        }
    }
}
