using ShoppingOnline.Repository.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingOnline.Models
{
    public class ProductModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập tên Sản phẩm")]
        [MinLength(4, ErrorMessage = "Yêu cầu nhập tên Sản phẩm ít nhất 4 ký tự")]
        public string Name { get; set; }
        public string Slug { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập mô tả Sản phẩm")]
        [MinLength(4, ErrorMessage = "Yêu cầu nhập mô tả Sản phẩm ít nhất 4 ký tự")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Yêu cầu nhập giá Sản phẩm")]
        [Column(TypeName = "decimal(18,0)")] // Định dạng decimal
        [DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]  // Hiển thị  'N0' (không chữ số thập phân)
        public decimal Price { get; set; }

		// Giá khuyến mãi (thêm trường mới)
		[Column(TypeName = "decimal(18,0)")] // Định dạng decimal
		[DisplayFormat(DataFormatString = "{0:N0}", ApplyFormatInEditMode = true)]  // Hiển thị  'N0' (không chữ số thập phân)
		public decimal? DiscountPrice { get; set; } // Dùng kiểu nullable decimal


		[Required(ErrorMessage = "Yêu cầu chọn 1 thương hiệu")]
        [Range(1, int.MaxValue, ErrorMessage = "Yêu cầu chọn 1 thương hiệu")]
        public int BrandID { get; set; }

        [Required(ErrorMessage = "Yêu cầu chọn 1 danh mục")]
        [Range(1, int.MaxValue, ErrorMessage = "Yêu cầu chọn 1 danh mục")]
        public int CategoryID { get; set; }

        public CategoryModel Category { get; set; }

        public BrandModel Brand { get; set; }

        //[Required(ErrorMessage = "Yêu cầu chọn hình ảnh")]
        public string Image { get; set; } 
        [NotMapped]
        [FileExtension]
        //[Required(ErrorMessage = "Yêu cầu tải lên hình ảnh")]
        public IFormFile? ImageUpload { get; set; }

        public int Status { get; set; }

		// Dung lượng ROM
		//[Required(ErrorMessage = "Yêu cầu nhập bộ nhớ trong")]
		public string? ROM { get; set; }

		// Dung lượng RAM
		public string RAM { get; set; }

        // Màu sắc
        //[Required(ErrorMessage = "Yêu cầu chọn 1 màu sắc")]
        public int? ColorId { get; set; } 
            
        public ColorProductModel Color { get; set; } // Thêm thuộc tính Color

        public int? Stock { get; set; } // Số lượng tồn kho

		public string? LoaiDay { get; set; } // Loại dây của đồng hồ
		public string? ManHinh { get; set; } // Kích thước màn hình
	}
    }

