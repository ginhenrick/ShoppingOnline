using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShoppingOnline.Models;
using ShoppingOnline.Repository;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ShoppingOnline.Areas.Admin.Controllers
{
    [Area("Admin")]
    //[Route("Admin/Product")]
    //[Authorize]
    public class ProductController : Controller
    {
        private readonly DataContext _dataContext;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductController(DataContext context, IWebHostEnvironment webHostEnvironment)
        {
            _dataContext = context;
            _webHostEnvironment = webHostEnvironment;
        }

        //[Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
           return View(await _dataContext.Products
               .OrderByDescending(p => p.Id)
               .Include(p => p.Category)
               .Include(p => p.Brand)
               .Include(p => p.Color)
               .ToListAsync());
        }

		//[Route("Create")]
	
        public IActionResult Create()
        {
            ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name");
            ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Name");
            return View();
        }

		[HttpPost]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> Create(ProductModel product)
        {
            ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", product.CategoryID);
            ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Name", product.BrandID);

            if(ModelState.IsValid)
            {
                //code thêm dữ liệu
                product.Slug = product.Name.Replace(" ", "-");
                product.Description = product.Description.Replace("<p>", "").Replace("</p>", "").Replace("<br>", "\n");
                product.Price = decimal.Parse(product.Price.ToString().Replace(",", "."));
                var slug = await _dataContext.Products.FirstOrDefaultAsync(p => p.Slug == product.Slug);
                if(slug != null)
                {
                    ModelState.AddModelError("", "Product exists already");
                    return View(product);
                }
                if(product.ImageUpload != null)
                    {
                        string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/products");
                        string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
                        string filePath = Path.Combine(uploadDir, imageName);

                        FileStream fs = new FileStream(filePath, FileMode.Create);
                        await product.ImageUpload.CopyToAsync(fs);
                        fs.Close();
                        product.Image = imageName;
                }
                
                _dataContext.Add(product);
                await _dataContext.SaveChangesAsync();
                TempData["success"] = "Add successfully";
                return RedirectToAction("Index");
            } else
            {
                TempData["error"] = "Model đang có một vài vấn đề";
                List<string> errors = new List<string>();
                foreach(var value in ModelState.Values)
                {
                    foreach(var error in value.Errors)
                    {
                        errors.Add(error.ErrorMessage);
                    }
                }
                string errorMessage = string.Join("\n", errors);
                return BadRequest(errorMessage);
            }
                
           
            return View(product);
        }
        public async Task<IActionResult> Edit(int Id)
        {
            ProductModel product = await _dataContext.Products.FindAsync(Id);
            ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", product.CategoryID);
            ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Name", product.BrandID);
            return View(product);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ProductModel product)
        {
            ViewBag.Categories = new SelectList(_dataContext.Categories, "Id", "Name", product.CategoryID);
            ViewBag.Brands = new SelectList(_dataContext.Brands, "Id", "Name", product.BrandID);
            var existed_product = _dataContext.Products.Find(product.Id);
            
            if (ModelState.IsValid)
            {
                product.Slug = product.Name.Replace(" ", "-");
                product.Description = product.Description.Replace("<p>", "").Replace("</p>", "").Replace("<br>", "\n");
                if (product.ImageUpload != null)
                {
                    
                    //upload new image
                    string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/products");
                    string imageName = Guid.NewGuid().ToString() + "_" + product.ImageUpload.FileName;
                    string filePath = Path.Combine(uploadDir, imageName);

                    //delete old picture
                    string oldFileImage = Path.Combine(uploadDir, existed_product.Image);

                    try
                    {
                        if (System.IO.File.Exists(oldFileImage))
                        {
                            System.IO.File.Delete(oldFileImage);
                        }
                    }
                    catch (Exception ex)
                    {
                        ModelState.AddModelError("", "An error occured while deleting the product image");
                    } 

                    FileStream fs = new FileStream(filePath, FileMode.Create);
                    await product.ImageUpload.CopyToAsync(fs);
                    fs.Close();
                    existed_product.Image = imageName;
                }

                existed_product.Name = product.Name;
                existed_product.Description = product.Description;
                existed_product.Price = product.Price;
                existed_product.CategoryID = product.CategoryID;
                existed_product.BrandID = product.BrandID;

                _dataContext.Update(existed_product);
                await _dataContext.SaveChangesAsync();
                TempData["success"] = "Updated successfully";
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


            return View(product);
        }
        public async Task<IActionResult> Delete(int Id)
        {
            ProductModel product = await _dataContext.Products.FindAsync(Id);
            if (product == null)
            {
                return NotFound();
            }
            string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images/products");
            string oldFileImage = Path.Combine(uploadDir, product.Image);

            try
            {
                if (System.IO.File.Exists(oldFileImage))
                {
                    System.IO.File.Delete(oldFileImage);
                }
            } catch (Exception ex) 
            {
                ModelState.AddModelError("", "An error occured while deleting the product image");
            }

            
            _dataContext.Products.Remove(product);
            await _dataContext.SaveChangesAsync();
            TempData["error"] = "Deleted successfully";
            return RedirectToAction("Index");
        }
    }
}
