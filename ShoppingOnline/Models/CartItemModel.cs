namespace ShoppingOnline.Models
{
	public class CartItemModel
	{
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
        public decimal? DiscountPrice { get; set; }  // Giá khuyến mãi (nullable)
        public int DiscountPercentage { get; set; } // Phần trăm giảm giá
        public string Image { get; set; }
        public string ColorName { get; set; } // Tên màu

        public decimal Total
        {
            get { return Quantity * Price; }
        }

        public decimal TotalWithDiscount
        {
            get
            {
                return DiscountPrice.HasValue ?
                    Quantity * (Price - (Price * (DiscountPrice.Value / 100))) :
                    Total;
            }
        }

        public CartItemModel()
        {

        }

        public CartItemModel(ProductModel product)
        {
            ProductId = product.Id;
            ProductName = product.Name;
            Price = product.Price;
            Quantity = 1;
            Image = product.Image;
            DiscountPrice = product.DiscountPrice; // Gán giá khuyến mãi từ ProductModel
            DiscountPercentage = product.DiscountPrice.HasValue ? (int)((product.DiscountPrice.Value - product.Price) / product.DiscountPrice.Value * 100) : 0;
            ColorName = product.Color.Name; // Gán tên màu từ ProductModel
        }
    }
}
