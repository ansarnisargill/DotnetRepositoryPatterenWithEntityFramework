using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Context;
using TestApi.Data.Abstractions;
using TestApi.Models;

namespace TestApi.Data.Implementations
{
    public class TestItemRepository : Repository<TestItem>,ITestItemRepository
    {
        public TestItemRepository(DatabaseContext dbContext)
        {
            context = dbContext;
        }

        public Task<List<TestItem>> GetTopTestItems()
        {
            throw new NotImplementedException();
        }
    }
}
