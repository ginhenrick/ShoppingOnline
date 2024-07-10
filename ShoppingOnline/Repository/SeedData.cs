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
				CategoryModel Mac = new CategoryModel { Name = "Mac", Slug = "mac", Description = "Mac", Status = 1 };
				CategoryModel iPad = new CategoryModel { Name = "iPad", Slug = "ipad", Description = "iPad", Status = 1 };
				CategoryModel iPhone = new CategoryModel { Name = "iPhone", Slug = "iphone", Description = "iPhone", Status = 1 };
				BrandModel Apple = new BrandModel { Name = "Apple", Slug = "apple", Description = "Apple is large Brand in the worlds", Status = 1 };
				//BrandModel sony = new BrandModel { Name = "Samsung", Slug = "samsung", Description = "Samsung is large Brand in the worlds", Status = 1 };
				_context.Products.AddRange(
					new ProductModel { Name = "Macbook Pro M3", Slug = "macbook", Description = "macbook pro m3 16GB RAM 512GB SSD" , Image = "1.jpg", Category = Mac, Brand = Apple, Price = 1770},
					new ProductModel { Name = "Macbook Air M3", Slug = "macbook", Description = "macbook air m3 8GB RAM 256GB SSD", Image = "2.jpg", Category = Mac, Brand = Apple, Price =  1219},
					new ProductModel { Name = "iPad Pro M4", Slug = "ipad", Description = "ipad pro m4 512GB Bộ nhớ trong", Image = "Ipad Pro M4.jpg", Category = iPad, Brand = Apple, Price = 1089 },
					new ProductModel { Name = "iPhone 15 Plus", Slug = "iphone", Description = "iphone 15 plus 256GB", Image = "iPhone 15 Plus.jpg", Category = iPhone, Brand = Apple, Price = 889 }
				);
				_context.SaveChanges();
			}
		} 
	}
}
