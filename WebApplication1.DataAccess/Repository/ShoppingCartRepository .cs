using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataAccess;
using WebApplication1.Models;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Repository
{
    public class ShoppingCartRepository : Repository<ShoppingCart>, IShoppingCartRepository
    {
        private ApplicationDbContext _db;
        public ShoppingCartRepository(ApplicationDbContext db) : base(db)
        {
            _db = db;

        }
        public int incrementcount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.count += count;
            return shoppingCart.count;
        }
        public int decrementcount(ShoppingCart shoppingCart, int count)
        {
            shoppingCart.count -= count;
            return shoppingCart.count;

        }
    }
}
