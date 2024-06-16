using Microsoft.EntityFrameworkCore;

namespace ProductManagement.Data.ApplicationDb.SqlServer
{
    public class ApplicationDbContext : DbContext
    {
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }
    }
}
