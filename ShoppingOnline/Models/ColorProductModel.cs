using System.ComponentModel.DataAnnotations;

namespace ShoppingOnline.Models
{
	public class ColorProductModel
	{
        [Key]
        public int Id { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập tên màu")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Yêu cầu nhập mã màu")]
        public string HexCode { get; set; }
    }
}
