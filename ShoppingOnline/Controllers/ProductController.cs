using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.Repository;

namespace ShoppingOnline.Controllers
{
    public class ProductController : Controller
    {
		private readonly DataContext _dataContext;
		public ProductController(DataContext context)
		{
			_dataContext = context;
		}
		public IActionResult Index()
        {
            return View(); 
        }

		public async Task<IActionResult> Details (int Id)
        {
			if (Id == null) return RedirectToAction("Index");
			var productsById = _dataContext.Products.Where(c => c.Id == Id).FirstOrDefault();
			return View(productsById);
        }
	}
}
