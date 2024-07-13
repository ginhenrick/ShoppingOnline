using System.ComponentModel.DataAnnotations;

namespace ShoppingOnline.Repository.Validation
{
    public class FileExtensionAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if(value is IFormFile file)
            {
                var extension = Path.GetExtension(file.FileName);
                string[] extensions = { "jpg", "png", "jpeg", "gif" };

                bool result = extensions.Any(x => extension.EndsWith(x));

                if(!result)
                {
                    return new ValidationResult("Allowed extensions are jpg, png, jpeg, or gif");
                }
            }
            return ValidationResult.Success;
        }
    }
}
