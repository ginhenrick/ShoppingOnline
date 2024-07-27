using System.ComponentModel.DataAnnotations;

namespace ShoppingOnline.Models
{
	public class CategoryModel
    {
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage="Yêu cầu nhập tên Danh mục")]
        public string Name { get; set; }

		[Required(ErrorMessage = "Yêu cầu nhập mô tả Danh mục")]
		public string Description { get; set; }
		
		public string Slug { get; set; }
        public int Status { get; set; }

		public string? LoaiDay { get; set; } // Loại dây của đồng hồ
		public int? ManHinh { get; set; } // Kích thước màn hình
	}
}
