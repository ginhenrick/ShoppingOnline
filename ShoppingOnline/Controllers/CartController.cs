using Microsoft.AspNetCore.Mvc;

namespace ShoppingOnline.Controllers
{
    public class CartController : Controller
    {
		public IActionResult Index()
		{
			return View();
		}
	}
}
