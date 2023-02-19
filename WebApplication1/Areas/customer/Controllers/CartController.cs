using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataAccess;
using WebApplication1.Models;
using WebApplication1.Models.ViewModel;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Areas.customer.Controllers
{
    [Area("customer")]
    public class CartController : Controller
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly ApplicationDbContext _db;
        public  CartVM CartVM;
        public CartController(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public IActionResult Index()
        {
            CartVM = new CartVM()
            {
                CartList = unitOfWork.shoppingCart.Getall(includeProperties: ("product")),
                orderheader=new()
             };
            foreach(var cart in CartVM.CartList)
            {
                cart.price = priceperquantity(cart.count, cart.product.Price, cart.product.Price50, cart.product.Price100);
                CartVM.orderheader.OrderTotal += (cart.count * cart.price);
            }
            return View(CartVM);
        }
        public IActionResult Summary()
        {
            CartVM = new CartVM()
            {
                CartList = unitOfWork.shoppingCart.Getall(includeProperties: ("product")),
                orderheader = new()
            };
            CartVM.orderheader.Name = "Rimsha";
            CartVM.orderheader.PhoneNumber = "03026494112";
            CartVM.orderheader.StreetAddress = "Uet lahore";
            CartVM.orderheader.PostalCode = "50400";
            CartVM.orderheader.State = "punjab";
            CartVM.orderheader.City = "Lahore";



            foreach (var cart in CartVM.CartList)
            {
                cart.price = priceperquantity(cart.count, cart.product.Price, cart.product.Price50, cart.product.Price100);
                CartVM.orderheader.OrderTotal += (cart.count * cart.price);
            }
            return View(CartVM);
        }
        private double priceperquantity(double count,double price, double price50, double price100)
        {
            if (count <= 50)
            {
                return price;
            }
            else
            {
                if (count <= 100)
                {
                    return price50;
                }
                else 
                    return price100;
            }
        }
        public IActionResult plus(int cartid)
        {
            var cart = unitOfWork.shoppingCart.GetFirstOrDefault(u => u.Id == cartid);
            unitOfWork.shoppingCart.incrementcount(cart, 1);
            unitOfWork.save();
            return RedirectToAction("Index");
        }
        public IActionResult minus(int cartid)
        {
            var cart = unitOfWork.shoppingCart.GetFirstOrDefault(u => u.Id == cartid);
            if(cart.count<=1)
            {
                unitOfWork.shoppingCart.Remove(cart);
            }
            else
            {
                unitOfWork.shoppingCart.decrementcount(cart, 1);
            }
           
            unitOfWork.save();
            return RedirectToAction("Index");
        }
        public IActionResult remove(int cartid)
        {
            var cart = unitOfWork.shoppingCart.GetFirstOrDefault(u => u.Id == cartid);
            unitOfWork.shoppingCart.Remove(cart);
            unitOfWork.save();
            return RedirectToAction("Index");
        }
    }
}
