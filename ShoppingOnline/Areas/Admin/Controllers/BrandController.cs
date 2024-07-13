using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ShoppingOnline.Models;
using ShoppingOnline.Repository;

namespace ShoppingOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class BrandController : Controller
    {
        private readonly DataContext _dataContext;
        public BrandController(DataContext context)
        {
            _dataContext = context;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _dataContext.Brands.OrderByDescending(p => p.Id).ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(BrandModel brand)
        {
            if (ModelState.IsValid)
            {
                //code thêm dữ liệu
                brand.Slug = brand.Name.Replace(" ", "-");
                brand.Description = brand.Description.Replace("<p>", "").Replace("</p>", "").Replace("<br>", "\n");
                var slug = await _dataContext.Brands.FirstOrDefaultAsync(p => p.Slug == brand.Slug);
                if (slug != null)
                {
                    ModelState.AddModelError("", "Brand exists already");
                    return View(brand);
                }

                _dataContext.Add(brand);
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
            return View(brand);
        }

        public async Task<IActionResult> Edit(int Id)
        {
            BrandModel brand = await _dataContext.Brands.FindAsync(Id);
            return View(brand);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(BrandModel brand)
        {
            var existed_brand = _dataContext.Brands.Find(brand.Id);

            if (ModelState.IsValid)
            {
                //code thêm dữ liệu
                existed_brand.Slug = brand.Name.Replace(" ", "-");
                existed_brand.Description = brand.Description.Replace("<p>", "").Replace("</p>", "").Replace("<br>", "\n");
                var slug = await _dataContext.Brands.FirstOrDefaultAsync(p => p.Slug == brand.Slug);

                if (slug != null)
                {
                    ModelState.AddModelError("", "Brand exists already");
                    return View(existed_brand);
                }

                // Kiểm tra thay đổi
                if (existed_brand.Name == brand.Name &&
                    existed_brand.Description == brand.Description &&
                    existed_brand.Status == brand.Status)
                {
                    TempData["info"] = "Không có thay đổi nào được thực hiện.";
                    return RedirectToAction("Index");
                }

                // Cập nhật nếu có thay đổi
                existed_brand.Name = brand.Name;
                existed_brand.Description = brand.Description;
                existed_brand.Status = brand.Status;

                _dataContext.Update(existed_brand);
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
            return View(existed_brand);
        }

        public async Task<IActionResult> Delete(int Id)
        {
            BrandModel brand = await _dataContext.Brands.FindAsync(Id);
            if (brand == null)
            {
                return NotFound();
            }
            _dataContext.Brands.Remove(brand);
            await _dataContext.SaveChangesAsync();
            TempData["success"] = "Deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
