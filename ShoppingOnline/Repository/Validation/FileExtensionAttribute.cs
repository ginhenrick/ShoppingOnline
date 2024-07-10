using System.ComponentModel.DataAnnotations;

namespace ShoppingOnline.Repository.Validation
{
    public class FileExtensionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName); //123.jpg
                string[] extensions = { "jpg", "png", "jpeg" };
                bool result = extension.Any(x => extension.EndsWith(x));

                if (!result)
                {
                    return new ValidationResult("Allowed extension are jpg or png or jpeg");
                }
                
            }
            return ValidationResult.Success;
            
        }
    }
}

