namespace ShoppingOnline.Models.ViewModels
{
	public class ProductViewModel
	{
		public int Id { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }
		public string Image { get; set; }
		public decimal Price { get; set; }
		public decimal? DiscountPrice { get; set; }
		public string ROM { get; set; }
		public string ColorName { get; set; }
		public int DiscountPercentage { get; set; }
	}
}
