using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingOnline.Models;
using ShoppingOnline.Repository;

namespace ShoppingOnline.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class CategoryController : Controller
	{
		private readonly DataContext _dataContext;
		public CategoryController(DataContext context)
		{
			_dataContext = context;
		}
		public async Task<IActionResult> Index()
		{
			return View(await _dataContext.Categories.OrderByDescending(p => p.Id).ToListAsync());
		}

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CategoryModel category)
        {
            if (ModelState.IsValid)
            {
                //code thêm dữ liệu
                category.Slug = category.Name.Replace(" ", "-");
                category.Description = category.Description.Replace("<p>", "").Replace("</p>", "").Replace("<br>", "\n");
                var slug = await _dataContext.Categories.FirstOrDefaultAsync(p => p.Slug == category.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Category exists already");
                    return View(category);
                }

                _dataContext.Add(category);
                await _dataContext.SaveChangesAsync();
                TempData["success"] = "Add successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Model đang có một vài vấn đề";
                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                string errorMessage = string.Join("\n", errors);
                return BadRequest(errorMessage);
            }
            return View(category);
        }

        public async Task<IActionResult> Edit(int Id)
        {
            CategoryModel category = await _dataContext.Categories.FindAsync(Id);
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(CategoryModel category)
        {
            var existed_categories = _dataContext.Categories.Find(category.Id);

            if (ModelState.IsValid)
            {
                //code thêm dữ liệu
                category.Slug = category.Name.Replace(" ", "-");
                category.Description = category.Description.Replace("<p>", "").Replace("</p>", "").Replace("<br>", "\n");
                var slug = await _dataContext.Categories.FirstOrDefaultAsync(p => p.Slug == category.Slug);

                if (slug != null)
                {
                    ModelState.AddModelError("", "Category exists already");
                    return View(existed_categories);
                }

                // Kiểm tra thay đổi
                if (existed_categories.Name == category.Name &&
                    existed_categories.Description == category.Description &&
                    existed_categories.Status == category.Status)
                {
                    TempData["info"] = "Không có thay đổi nào được thực hiện.";
                    return RedirectToAction("Index");
                }

                // Cập nhật nếu có thay đổi
                existed_categories.Name = category.Name;
                existed_categories.Description = category.Description;
                existed_categories.Status = category.Status;

                _dataContext.Update(existed_categories);
                await _dataContext.SaveChangesAsync();
                TempData["success"] = "Update successfully";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["error"] = "Model đang có một vài vấn đề";
                List<string> errors = new List<string>();
                foreach (var value in ModelState.Values)
                {
                    foreach (var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                string errorMessage = string.Join("\n", errors);
                return BadRequest(errorMessage);
            }
            return View(existed_categories);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            CategoryModel category = await _dataContext.Categories.FindAsync(Id);
            if (category == null)
            {
                return NotFound();
            }
            _dataContext.Categories.Remove(category);
            await _dataContext.SaveChangesAsync();
            TempData["success"] = "Deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
