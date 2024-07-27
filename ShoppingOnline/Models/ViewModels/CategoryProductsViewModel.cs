using ShoppingOnline.Models;

namespace ShoppingOnline.Models.ViewModels
{
	public class CategoryProductsViewModel
	{
		public CategoryModel Category { get; set; }
		public List<ProductViewModel> Products { get; set; }
	}
}
