using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Controllers
{
    [Area("customer")]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IUnitOfWork _unitOfWork;
        public HomeController(ILogger<HomeController> logger, IUnitOfWork unitOfWork)
        {
            _logger = logger;
            _unitOfWork = unitOfWork;
        }

        public IActionResult Index()
        {
            IEnumerable<Product> productlist = _unitOfWork.Product.Getall(includeProperties:"Category,CoverType") ;
             return View(productlist);
        }
        public IActionResult Details(int PId)
        {
            ShoppingCart cartobj = new ShoppingCart()
            {
                count = 1,
                PId = PId,
                product = _unitOfWork.Product.GetFirstOrDefault(u => u.Id == PId, includeProperties: "Category,CoverType"),
            };
      
            return View(cartobj);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Details(ShoppingCart shoppingcart)
        {
            ShoppingCart cartfromdb = _unitOfWork.shoppingCart.GetFirstOrDefault(
                u => u.PId == shoppingcart.PId);
            if(cartfromdb == null)
            {
                _unitOfWork.shoppingCart.Add(shoppingcart);
            }
            else
            {
                _unitOfWork.shoppingCart.incrementcount(cartfromdb, shoppingcart.count);
            }

            _unitOfWork.save();
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
