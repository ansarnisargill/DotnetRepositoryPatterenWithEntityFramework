using Microsoft.EntityFrameworkCore;
using TestApi.Models;

namespace TestApi.Context
{

    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options)
            : base(options)
        {
        }

        public DbSet<TestItem> TestItems { get; set; }
    }

}
