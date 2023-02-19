using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataAccess;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;
using WebApplication1.Repository.IRepository;


namespace WebApplication1.Controllers
{
[Area("admin")]
    public class ProductController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ApplicationDbContext _db;
        private readonly IWebHostEnvironment webHostEnvironment;
        public ProductController(IUnitOfWork unitOfWork, IWebHostEnvironment webHostEnvironment, ApplicationDbContext _db)
        {
            this._db = _db;
            this.unitOfWork = unitOfWork;
            this.webHostEnvironment = webHostEnvironment;
        }
        //Get
        public IActionResult Index()
        {
            var neww_var= _db.Products.Include(u => u.Category);
            //IEnumerable<Product> var = unitOfWork.Product.Getall();
            return View(neww_var.ToList());
        }
        
        public IActionResult Upsert( int ? id)
        {
           
            Product product= new Product();
            IEnumerable<SelectListItem> categorylist = unitOfWork.Category.Getall().Select(u => new SelectListItem
            {
                Text = u.name,
                Value = u.Id.ToString()
            });
            IEnumerable<SelectListItem> covertypelist = unitOfWork.CoverType.Getall().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
    
            if(id == null ||id== 0)
            {
               ViewBag.categorylist = categorylist;
               ViewData["covertypelist"] = covertypelist;
                return View(product);
            }
            else
            {
                ViewBag.categorylist = categorylist;
                ViewData["covertypelist"] = covertypelist;
                product = unitOfWork.Product.GetFirstOrDefault(u=>u.Id==id);
                return View(product);
            }
            
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(Product obj,IFormFile  file)
        {
           
            
            if (ModelState.IsValid)
            {
                string wwwrootpath = webHostEnvironment.WebRootPath;
                if (file != null)
                {
                    string filename = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(wwwrootpath, @"Images/Product");
                    var extensions = Path.GetExtension(file.FileName);
                    if(obj.ImgUrl != null)
                    {
                        var oldimgpath = Path.Combine(wwwrootpath, obj.ImgUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(oldimgpath))
                        {
                            System.IO.File.Delete(oldimgpath);
                        }
                    }
                    using (var filestreams = new FileStream(Path.Combine(uploads, filename + extensions), FileMode.Create))
                    {
                        file.CopyTo(filestreams);
                    }
                    obj.ImgUrl = @"\Images\Product\" + filename + extensions;

                }
                if (obj.Id == 0)
                {
                    unitOfWork.Product.Add(obj);
                }
                else
                {
                    unitOfWork.Product.Update(obj);
                }
                unitOfWork.save();
                TempData["success"] = "Product created succesfully";
                return RedirectToAction("Index");
            }
            return View(obj);


        }
        public IActionResult Delete(int? id)
        {
            Product product = new Product();
            IEnumerable<SelectListItem> categorylist = unitOfWork.Category.Getall().Select(u => new SelectListItem
            {
                Text = u.name,
                Value = u.Id.ToString()
            });
            IEnumerable<SelectListItem> covertypelist = unitOfWork.CoverType.Getall().Select(u => new SelectListItem
            {
                Text = u.Name,
                Value = u.Id.ToString()
            });
            product = unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
            //var obj = unitOfWork.Product.GetFirstOrDefault(u => u.Id == id);
            if (id == null || id == 0)
            {

                return NotFound();
            }
         
            if (product == null)
            {
                return NotFound();
            }
            ViewBag.categorylist = categorylist;
            ViewData["covertypelist"] = covertypelist;
            return View(product);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Product obj)
        {
            //change
            //var oldimgpath = Path.Combine(webHostEnvironment.WebRootPath, obj.ImgUrl.TrimStart('\\'));
            //if (System.IO.File.Exists(oldimgpath))
            //{
            //    System.IO.File.Delete(oldimgpath);
            //}
            unitOfWork.Product.Remove(obj);
            unitOfWork.save();
            TempData["success"] = "Product has been Deleted succesfully";
            return RedirectToAction("Index");
        }
        #region API CALLS
        [HttpGet]
        public IActionResult GetAll()
        {
            var productList = unitOfWork.Product.Getall(includeProperties: "Category,CoverType");
            return Json(new { data = productList });
        }
        #endregion
    }

}
