using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataAccess;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private ApplicationDbContext _db;
        public UnitOfWork(ApplicationDbContext db)
        {
            _db = db;
            Category = new CategoryRepository(_db);
            CoverType = new CoverTypeRepository(_db);
            Product= new ProductRepository(_db);
            shoppingCart = new ShoppingCartRepository(_db);
            orderDetail = new OrderDetailRepository(_db);
            orderheader = new OrderheaderRepository(_db);
        }
        public ICategoryRepository Category { get; private set; }
        public ICoverTypeRepository CoverType { get; private set; }
        public IProductRepository Product { get; private set; }
        public IShoppingCartRepository shoppingCart { get; private set; }
        public IOrderDetailRepository orderDetail { get; private set; }
        public IOrderheaderRepository orderheader { get; private set; }
        public void save()
        {
            _db.SaveChanges();
        }
    }
}
