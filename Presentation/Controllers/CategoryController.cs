using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation.Data;

namespace Presentation.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDBContext _dbContext;
        public CategoryController(ApplicationDBContext dbContext)
        {
            _dbContext = dbContext;
            
        }
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var cats = await _dbContext.Categories.ToListAsync();
            return View(cats);
        }

    }
}
