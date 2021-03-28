using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestApi.Models;

namespace TestApi.Data.Abstractions
{
    public interface ITestItemRepository: IRepository<TestItem>
    {
        Task<List<TestItem>> GetTopTestItems();
    }
}
