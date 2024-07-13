using Microsoft.AspNetCore.Identity;

namespace ShoppingOnline.Models
{
	public class AppUserModel : IdentityUser
	{
		public string Occupation {  get; set; }
	}
}
