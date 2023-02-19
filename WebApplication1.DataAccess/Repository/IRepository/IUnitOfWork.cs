using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Repository.IRepository
{
    public interface IUnitOfWork
    {
        ICategoryRepository Category { get;  }
        ICoverTypeRepository CoverType { get; }
        IProductRepository Product { get; }

        IShoppingCartRepository shoppingCart { get; }
        IOrderDetailRepository orderDetail { get; }
        IOrderheaderRepository orderheader { get; }
        void save();
    }
}
