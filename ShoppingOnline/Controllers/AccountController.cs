using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ShoppingOnline.Models;

namespace ShoppingOnline.Controllers
{
	public class AccountController : Controller
	{
		private UserManager<AppUserModel> _userManage;
		private SignInManager<AppUserModel> _signInManager;
		public AccountController(SignInManager<AppUserModel> signInManager, UserManager<AppUserModel> userMange)
		{
			_signInManager = signInManager;
			_userManage = userMange;
		}
		public IActionResult Index()
		{
			return View();
		}

		public async Task<IActionResult> Login()
		{
			return View();
		}

		public async Task<IActionResult> Create(UserModel user)
		{
			if(ModelState.IsValid)
			{
				AppUserModel newUser = new AppUserModel { UserName = user.Username, Email = user.Email };
				IdentityResult result = await _userManage.CreateAsync(newUser);
				if (result.Succeeded)
				{
					return Redirect("/admin/products");
				}
				foreach (IdentityError error in result.Errors)
				{
					ModelState.AddModelError("", error.Description);
				}
				
			}

			return View(user);
		}
	}
}
