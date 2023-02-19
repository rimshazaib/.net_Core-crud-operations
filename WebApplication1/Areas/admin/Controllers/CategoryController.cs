using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataAccess;
using WebApplication1.Models;
using WebApplication1.Repository.IRepository;


namespace WebApplication1.Controllers
{
[Area("admin")]
    public class CategoryController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public CategoryController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        //Get
        public IActionResult Index()
        {
            IEnumerable<Category> var = unitOfWork.Category.Getall();
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
                unitOfWork.Category.Add(obj);
                unitOfWork.save();
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
            var obj = unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
           // var obj = db.Categories.Find(id);
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
                unitOfWork.Category.Update(obj);
                unitOfWork.save();
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
            var obj = unitOfWork.Category.GetFirstOrDefault(u => u.Id == id);
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
            //change
            unitOfWork.Category.Remove(obj);
            unitOfWork.save();
            TempData["success"] = "Category has been Deleted succesfully";
            return RedirectToAction("Index");
        }
    }
}
