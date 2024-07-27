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
				// Categories
				CategoryModel iPhone = new CategoryModel { Name = "iPhone", Slug = "iphone", Description = "iPhone", Status = 1 };
				CategoryModel iPad = new CategoryModel { Name = "iPad", Slug = "ipad", Description = "iPad", Status = 1 };
				CategoryModel Mac = new CategoryModel { Name = "Mac", Slug = "mac", Description = "Mac", Status = 1 };
				CategoryModel Watch = new CategoryModel { Name = "Watch", Slug = "watch", Description = "Watch", Status = 1 };
				CategoryModel Accessories = new CategoryModel { Name = "Phụ kiện", Slug = "phu-kien", Description = "Phụ kiện", Status = 1 };

				// Brands
				BrandModel Apple = new BrandModel { Name = "Apple", Slug = "apple", Description = "Apple is a leading technology company", Status = 1 };

				// Colors
				ColorProductModel Midnight = new ColorProductModel { Name = "Midnight", HexCode = "#000000" };
				ColorProductModel Starlight = new ColorProductModel { Name = "Starlight", HexCode = "#F9F6EF" };
				ColorProductModel Pink = new ColorProductModel { Name = "Pink", HexCode = "#FFC0CB" };
				ColorProductModel Red = new ColorProductModel { Name = "Red", HexCode = "#FF0000" };
				ColorProductModel Blue = new ColorProductModel { Name = "Blue", HexCode = "#0000FF" };
				ColorProductModel AlpineGreen = new ColorProductModel { Name = "Alpine Green", HexCode = "#006F57" };
				ColorProductModel Black = new ColorProductModel { Name = "Black", HexCode = "#000000" };
				ColorProductModel Yellow = new ColorProductModel { Name = "Yellow", HexCode = "#FFFF00" };
				ColorProductModel Green = new ColorProductModel { Name = "Green", HexCode = "#008000" };
				ColorProductModel TitanBlack = new ColorProductModel { Name = "Titan Black", HexCode = "#2F4F4F" };
				ColorProductModel TitanWhite = new ColorProductModel { Name = "Titan White", HexCode = "#FFFFFF" };
				ColorProductModel TitanBlue = new ColorProductModel { Name = "Titan Blue", HexCode = "#4169E1" };
				ColorProductModel TitanNatural = new ColorProductModel { Name = "Titan Natural", HexCode = "#D2B48C" };
				ColorProductModel SpaceGrey = new ColorProductModel { Name = "Space Grey", HexCode = "#808080" };
				ColorProductModel Silver = new ColorProductModel { Name = "Silver", HexCode = "#C0C0C0" };
				ColorProductModel Purple = new ColorProductModel { Name = "Purple", HexCode = "#800080" };
				ColorProductModel SpaceBlack = new ColorProductModel { Name = "Space Black", HexCode = "#000000" };

				// Add Colors to the database
				_context.ColorProductModels.AddRange(
					Midnight, Starlight, Pink, Red, Blue, AlpineGreen,
					Black, Yellow, Green, TitanBlack, TitanWhite, TitanBlue,
					TitanNatural, SpaceGrey, Silver, Purple, SpaceBlack
				);

				// Add Products to the database
				_context.Products.AddRange(
					// iPhone
					new ProductModel { Name = "iPhone 13", Slug = "iphone-13", Description = "Released in September 2021", Image = "iphone 13.png", Category = iPhone, Brand = Apple, Price = 584, DiscountPrice = 1067, ROM = "128GB", Color = Midnight },
					new ProductModel { Name = "iPhone 15", Slug = "iphone-15", Description = "Released in September 2023", Image = "iphone 15.png", Category = iPhone, Brand = Apple, Price = 836, DiscountPrice = 1067, ROM = "128GB", Color = Black },
					new ProductModel { Name = "iPhone 15 Plus", Slug = "iphone-15-plus", Description = "Released in September 2023", Image = "iphone 15 plus.png", Category = iPhone, Brand = Apple, Price = 965, DiscountPrice = 1195, ROM = "128GB", Color = Pink },
					new ProductModel { Name = "iPhone 15 Pro Max", Slug = "iphone-15-pro-max", Description = "Released in September 2023", Image = "iphone 15 pro max.png", Category = iPhone, Brand = Apple, Price = 1251, DiscountPrice = 1622, ROM = "256GB", Color = TitanBlack },
					// iPad
					new ProductModel { Name = "iPad gen 9 10.2 inch WiFi", Slug = "ipad-gen-9", Description = "Released in September 2021", Image = "ipad gen 9.png", Category = iPad, Brand = Apple, Price = 303, DiscountPrice = 427, ROM = "64GB", Color = SpaceGrey },
					new ProductModel { Name = "iPad Gen 10 th 10.9 inch WiFi", Slug = "ipad-gen-10", Description = "Released in October 2022", Image = "ipad gen 10.png", Category = iPad, Brand = Apple, Price = 414, DiscountPrice = 555, ROM = "64GB", Color = Blue },
					new ProductModel { Name = "iPad Pro M4 11 inch Wi-Fi", Slug = "ipad-pro-m4", Description = "Released in May 2023", Image = "ipad pro m4.png", Category = iPad, Brand = Apple, Price = 1183, DiscountPrice = 1239, ROM = "256GB", Color = Silver },
					new ProductModel { Name = "iPad Air M2 13 inch Wi-Fi", Slug = "ipad-air-m2", Description = "Released in March 2022", Image = "ipad air m2.png", Category = iPad, Brand = Apple, Price = 940, ROM = "128GB", Color = Blue },
					// Mac
					new ProductModel { Name = "MacBook Air M1 2020 (8GB RAM | 256GB SSD)", Slug = "macbook-air-m1-2020", Description = "Released in November 2020", Image = "Macbook Air M1.png", Category = Mac, Brand = Apple, Price = 18590000 / 23200, DiscountPrice = 28990000 / 23200, ROM = "256GB", RAM = "8GB", Color = SpaceGrey },
					new ProductModel { Name = "iMac M1 2021 24 inch (8 Core GPU/8GB/512GB)", Slug = "imac-m1-2021", Description = "Released in April 2021", Image = "iMac M1 2021.png", Category = Mac, Brand = Apple, Price = 32990000 / 23200, DiscountPrice = 45990000 / 23200, ROM = "512GB", RAM = "8GB", Color = Green },
					new ProductModel { Name = "MacBook Pro 16 M1 Pro (16 Core/16GB/1TB)", Slug = "macbook-pro-16-m1-pro", Description = "Released in October 2021", Image = "Macbook Pro 16 M1.png", Category = Mac, Brand = Apple, Price = 49990000 / 23200, DiscountPrice = 73990000 / 23200, ROM = "1TB", RAM = "16GB", Color = SpaceGrey },
					new ProductModel { Name = "MacBook Air M2 2022 (8GB RAM | 256GB SSD)", Slug = "macbook-air-m2-2022", Description = "Released in July 2022", Image = "Macbook Air M2.png", Category = Mac, Brand = Apple, Price = 23690000 / 23200, DiscountPrice = 32990000 / 23200, ROM = "256GB", RAM = "8GB", Color = SpaceGrey },
					// Watch
					new ProductModel { Name = "Apple Watch SE Nhôm 2022 GPS", Slug = "apple-watch-se-2022", Description = "Released in September 2022", Image = "Apple Watch SE.png", Category = Watch, Brand = Apple, Price = 5890000 / 23200, DiscountPrice = 8990000 / 23200, ManHinh = "40mm", LoaiDay = "Sport Band", Color = Silver },
					new ProductModel { Name = "Apple Watch Series 9 Nhôm (GPS) 41mm | Sport Band", Slug = "apple-watch-series-9", Description = "Released in September 2023", Image = "Apple Watch Series 9.png", Category = Watch, Brand = Apple, Price = 9290000 / 23200, DiscountPrice = 11990000 / 23200, ManHinh = "41mm", LoaiDay = "Sport Band - S/M", Color = Silver },
					new ProductModel { Name = "Apple Watch Ultra 2 GPS + Cellular 49mm Ocean Band", Slug = "apple-watch-ultra-2", Description = "Released in September 2023", Image = "Apple Watch Ultra 2.png", Category = Watch, Brand = Apple, Price = 20890000 / 23200, DiscountPrice = 23990000 / 23200, ManHinh = "49mm", LoaiDay = "Ocean Band", Color = Blue },
					new ProductModel { Name = "Apple Watch SE 2023 GPS Sport Band size S/M", Slug = "apple-watch-se-2023", Description = "Released in September 2023", Image = "Apple Watch SE 2023.png", Category = Watch, Brand = Apple, Price = 5890000 / 23200, DiscountPrice = 8990000 / 23200, ManHinh = "40mm", LoaiDay = "Sport Band - S/M", Color = Midnight },
					// Accessories
					new ProductModel { Name = "AirPods Pro 2", Slug = "airpods-pro-2", Description = "Released in September 2022", Image = "AirPods Pro 2.png", Category = Accessories, Brand = Apple, Price = 4990000 / 23200, DiscountPrice = 6790000 / 23200, ColorId = null },
					new ProductModel { Name = "Sạc 20W USB-C Power Adapter", Slug = "sac-20w-usb-c", Description = "Released in 2020", Image = "Sạc 20W USB-C Power Adapter.png", Category = Accessories, Brand = Apple, Price = 520000 / 23200, DiscountPrice = 690000 / 23200 },
					new ProductModel { Name = "Magic Mouse 2", Slug = "magic-mouse-2", Description = "Released in 2015", Image = "Magic Mouse 2.png", Category = Accessories, Brand = Apple, Price = 1590000 / 23200, DiscountPrice = 2990000 / 23200, Color = Silver },
					new ProductModel { Name = "Apple Pencil Pro", Slug = "apple-pencil-pro", Description = "Released in 2018", Image = "Apple Pencil Pro.png", Category = Accessories, Brand = Apple, Price = 3490000 / 23200 }
				);

				_context.SaveChanges();
			}
		}
	}
}