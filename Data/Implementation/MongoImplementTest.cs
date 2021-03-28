using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Data.Abstractions;
using TestApi.Models;

namespace TestApi.Data.Implementation
{
    public class MongoImplementTest : ITestItemRepository
    {
        public Task<TestItem> Add(TestItem entity)
        {
            throw new NotImplementedException();
        }

        public Task<TestItem> Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<TestItem> Get(int id)
        {
            throw new NotImplementedException();
        }

        public Task<List<TestItem>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<List<TestItem>> GetTopTestItems()
        {
            throw new NotImplementedException();
        }

        public Task<TestItem> Update(TestItem entity)
        {
            throw new NotImplementedException();
        }
    }
}
