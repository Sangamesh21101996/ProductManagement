using Microsoft.AspNetCore.Mvc;
using ProductManagement.Data.ApplicationDb.SqlServer;
using ProductManagement.Models.Category;

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

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CategoryEntity ctgy)
        {
            //we can custome validation using ModelState

            if(ctgy.CategoryName.Any(char.IsDigit))
            {
                ModelState.AddModelError("CategoryName", "Name must not contain Digits");
            }
            //If All validation are satisfied then go for db save
            if (ModelState.IsValid)
            {
                _dbcontext.CategoriesEntity.Add(ctgy);
                _dbcontext.SaveChanges();
                //We can Add Temp Data this will remain in temp memory and will lost after rendering 
                TempData["success"] = "Category Created Successfully";
                return RedirectToAction("Index");
            }

            //retrun the empty view 
            return View();

        }

        [HttpGet]
        public IActionResult Edit(int ctgId)
        {
            if(ctgId == 0)
            {
                //We can pass here Not found view 
                return NotFound();
            }

            var getCategory = _dbcontext.CategoriesEntity.SingleOrDefault(ctg=> ctg.CategoryId == ctgId);
            if (getCategory == null)
            {
                //We can pass view or error view 
                return NotFound();
            }

            return View(getCategory);

        }

        [HttpPost]
        public IActionResult Edit(CategoryEntity ctg)
        {
            //we can custome validation using ModelState

            if (ctg.CategoryName.Any(char.IsDigit))
            {
                ModelState.AddModelError("CategoryName", "Name must not contain Digits");
            }
            //If All validation are satisfied then go for db save
            if (ModelState.IsValid)
            {
                _dbcontext.CategoriesEntity.Update(ctg);
                _dbcontext.SaveChanges();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToAction("Index");
            }

            //retrun the empty view 
            return View();

        }

        [HttpGet]
        public IActionResult Delete(int ctgId)
        {
            if (ctgId == 0)
            {
                //We can pass here Not found view 
                return NotFound();
            }

            var getCategory = _dbcontext.CategoriesEntity.SingleOrDefault(ctg => ctg.CategoryId == ctgId);
            if (getCategory == null)
            {
                //We can pass view or error view 
                return NotFound();
            }

            return View(getCategory);
        }

        [HttpPost,ActionName("Delete")]
        public IActionResult Remove(CategoryEntity ctg)
        {
            if(ctg==null)
            {
                return NotFound();
            }

            _dbcontext.CategoriesEntity.Remove(ctg);
            _dbcontext.SaveChanges();
            TempData["success"] = "Category Deleted Successfully";
            return RedirectToAction("Index");
        }
    }
}
