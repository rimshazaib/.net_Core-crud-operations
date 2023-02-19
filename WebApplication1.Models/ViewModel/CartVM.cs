using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebApplication1.Models.ViewModel
{
    public class CartVM
    {
        public IEnumerable<ShoppingCart> CartList { get; set; }
        public Orderheader orderheader { get; set; }

    }
}
