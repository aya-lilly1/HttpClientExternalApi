using HttpClientExternalApi.Models;
using Microsoft.EntityFrameworkCore;

namespace HttpClientExternalApi.Data
{
    public class ApplicationDbContext :DbContext
    {

        public ApplicationDbContext(DbContextOptions options)
           : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }
      
    }
}
