using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingOnline.Models;
using ShoppingOnline.Models.ViewModels;
using ShoppingOnline.Repository;
using System.Diagnostics;

namespace ShoppingOnline.Controllers
{
    public class HomeController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DataContext context)
        {
            _logger = logger;
            _dataContext = context;
        }

        //public IActionResult Index()
        //{
        //    var products = _dataContext.Products.Include("Category").Include("Brand").ToList();
        //    return View(products);
        //}

        public async Task<IActionResult> Index()
        {
            var categories = await _dataContext.Categories
               .Where(c => c.Status == 1)
               .ToListAsync();

            List<CategoryProductsViewModel> viewModel = new List<CategoryProductsViewModel>();

            foreach (var category in categories)
            {
                var products = await _dataContext.Products
                    .Include(p => p.Category)
                    .Include(p => p.Brand)
                    .Include(p => p.Color)
                    .Where(p => p.Category.Id == category.Id && p.Status == 1)
                    .OrderByDescending(p => p.Id)
                    .Take(4)
                    .Select(p => new ProductViewModel
                    {
                        Id = p.Id,
                        Name = p.Name,
                        Price = p.Price,
                        DiscountPrice = p.DiscountPrice,
                        Image = p.Image,
                        DiscountPercentage = p.DiscountPrice.HasValue ? (int)((p.DiscountPrice.Value - p.Price) / p.DiscountPrice.Value * 100) : 0,
                        ColorName = p.Color.Name
                    })
                    .ToListAsync();

                var categoryViewModel = new CategoryProductsViewModel
                {
                    Category = category,
                    Products = products
                };

                viewModel.Add(categoryViewModel);
            }

            return View(viewModel);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statuscode)
        {
            if(statuscode == 404)
            {
                return View("NotFound");
            } else
            {
				return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
			}
        }
    }
}
