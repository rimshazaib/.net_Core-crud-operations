using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataAccess;
using WebApplication1.Models;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Repository
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private ApplicationDbContext _db;
        public ProductRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }
        public void Update(Product obj)
        {
            var objfromdb = _db.Products.FirstOrDefault(u => u.Id == obj.Id);
            if(objfromdb != null)
            {
                objfromdb.Title = obj.Title;
                objfromdb.ISBN = obj.ISBN;
                objfromdb.Price = obj.Price;
                objfromdb.Price50 = obj.Price50;
                objfromdb.Price100 = obj.Price100;
                objfromdb.Listprice = obj.Listprice;
                objfromdb.Title = obj.Title;
                objfromdb.Discription = obj.Discription;
                objfromdb.Author = obj.Author;
                objfromdb.CoverTypeId = obj.CoverTypeId;
                objfromdb.CategoryId = obj.CategoryId;
                if(obj.ImgUrl != null)
                {
                    objfromdb.ImgUrl = obj.ImgUrl;
                }


            }
        }
    }
}
