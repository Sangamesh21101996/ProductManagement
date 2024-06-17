using Microsoft.EntityFrameworkCore;
using ProductManagement.Models.Category;

namespace ProductManagement.Data.ApplicationDb.SqlServer
{
    public class ApplicationDbContext : DbContext
    {
       

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<CategoryEntity> CategoriesEntity { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CategoryEntity>().HasData(

                new CategoryEntity() { CategoryId=1,  CategoryName = "Action", DisplayOrder = 1 },
                new CategoryEntity() { CategoryId=2,  CategoryName = "SciFi", DisplayOrder = 2 },
                new CategoryEntity() {CategoryId = 3, CategoryName = "History", DisplayOrder = 3 }
                );
        }
    }
}
