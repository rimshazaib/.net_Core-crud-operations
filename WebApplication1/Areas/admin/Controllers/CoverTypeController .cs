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
    public class CoverTypeController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        public CoverTypeController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        //Get
        public IActionResult Index()
        {
            IEnumerable<CoverType> var = unitOfWork.CoverType.Getall();
            return View(var);
        }
        public IActionResult Create()
        {
            return View();
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CoverType obj)
        {
           
            if(ModelState.IsValid)
            {
                unitOfWork.CoverType.Add(obj);
                unitOfWork.save();
                TempData["success"] = "CoverType has been added succesfully";
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
            var obj = unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if(obj==null)
            {
                return NotFound();
            }
            return View(obj);
        }
        //post
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(CoverType obj)
        {
            
            if (ModelState.IsValid)
            {
                unitOfWork.CoverType.Update(obj);
                unitOfWork.save();
                TempData["success"] = "CoverType has been Edit succesfully";
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
            var obj = unitOfWork.CoverType.GetFirstOrDefault(u => u.Id == id);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(CoverType obj)
        {
            //change
            unitOfWork.CoverType.Remove(obj);
            unitOfWork.save();
            TempData["success"] = "CoverType has been Deleted succesfully";
            return RedirectToAction("Index");
        }
    }
}
