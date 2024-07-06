using Microsoft.AspNetCore.Mvc;

namespace ShoppingOnline.Controllers
{
    public class CategoryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
