using Microsoft.AspNetCore.Mvc;

namespace ShoppingOnline.Controllers
{
	public class CheckoutController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
