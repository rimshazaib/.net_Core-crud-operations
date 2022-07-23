using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Data;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext db;
        public CategoryController(ApplicationDbContext db)
        {
            this.db = db;
        }
        //Get
        public IActionResult Index()
        {
            IEnumerable<Category> var =db.Categories;
            return View(var);
        }
        public IActionResult Create()
        {
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Category obj)
        {
            if (obj.name == obj.displayorder.ToString())
            {
                ModelState.AddModelError("name", "The displayorder cannot exacly match withbthe category name");
            }
            if(ModelState.IsValid)
            {
                db.Categories.Add(obj);
                db.SaveChanges();
                TempData["success"] = "Category has been added succesfully";
                return RedirectToAction("Index");
            }
            return View(obj);
        }
        public IActionResult Edit( int ? id)
        {
            if(id==null || id==0)
            {
                return NotFound();
            }
            var obj = db.Categories.Find(id);
            if(obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Category obj)
        {
            if (obj.name == obj.displayorder.ToString())
            {
                ModelState.AddModelError("name", "The displayorder cannot exacly match withbthe category name");
            }
            if (ModelState.IsValid)
            {
                db.Categories.Update(obj);
                db.SaveChanges();
                TempData["success"] = "Category has been Edit succesfully";
                return RedirectToAction("Index");
            }
            return View(obj);


        }
        public IActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var obj = db.Categories.Find(id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Category obj)
        {
            db.Categories.Remove(obj);
            db.SaveChanges();
            TempData["success"] = "Category has been Deleted succesfully";
            return RedirectToAction("Index");
        }
    }
}
