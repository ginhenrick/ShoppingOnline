using System.ComponentModel.DataAnnotations;

namespace ShoppingOnline.Models
{
    public class BrandModel
    {
        [Key]
        public int Id { get; set; }
		[Required, MinLength(4, ErrorMessage = "Yêu cầu nhập tên Thương hiệu")]
		public string Name { get; set; }
		[Required, MinLength(4, ErrorMessage = "Yêu cầu nhập mô tả Danh mục")]
		public string Description { get; set; }
        public string Slug { get; set; }
        public int Status { get; set; }
    }
}
