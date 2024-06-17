using Microsoft.AspNetCore.Mvc;
using ProductManagement.Data.ApplicationDb.SqlServer;

namespace ProductManagement.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ILogger<CategoryController> _logger;
        private readonly ApplicationDbContext _dbcontext;
        public CategoryController(ILogger<CategoryController> logger, ApplicationDbContext dbContext)
        {
             _logger = logger;
            _dbcontext= dbContext;
        }

        public IActionResult Index()
        {
            var getCategoryList = _dbcontext.CategoriesEntity.ToList();

            return View(getCategoryList);
        }
    }
}
