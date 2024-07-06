using Microsoft.EntityFrameworkCore;
using ShoppingOnline.Models;

namespace ShoppingOnline.Repository
{
	public class SeedData
	{
		public static void SeedingData(DataContext _context)
		{
			_context.Database.Migrate();
			if (!_context.Products.Any())
			{
				CategoryModel apple = new CategoryModel { Name = "Apple", Slug = "apple", Description = "Apple is large Brand in the worlds", Status = 1 };
				CategoryModel samsung = new CategoryModel { Name = "Samsung", Slug = "samsung", Description = "Samsung is large Brand in the worlds", Status = 1 };
				BrandModel dell = new BrandModel { Name = "Apple", Slug = "apple", Description = "Apple is large Brand in the worlds", Status = 1 };
				BrandModel sony = new BrandModel { Name = "Samsung", Slug = "samsung", Description = "Samsung is large Brand in the worlds", Status = 1 };
				_context.Products.AddRange(
					new ProductModel { Name = "Macbook", Slug = "macbook", Description = "macbook" , Image = "1.jpg", Category = apple, Brand = sony, Price = 1200},
					new ProductModel { Name = "MAC", Slug = "mac", Description = "MAC", Image = "1.jpg", Category = samsung, Brand = dell, Price = 1200 }
				);
				_context.SaveChanges();
			}
		} 
	}
}
