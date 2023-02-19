using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataAccess;
using WebApplication1.Models;
using WebApplication1.Repository.IRepository;

namespace WebApplication1.Repository
{
    public class OrderheaderRepository : Repository<Orderheader>, IOrderheaderRepository
    {
        private ApplicationDbContext _db;
        public OrderheaderRepository(ApplicationDbContext db) :base(db)
        {
            _db = db;
        }
        public void Update(Orderheader obj)
        {
            _db.orderheaders.Update(obj);
        }
        public void Updatestatus(int id, string OrderStatus, string? PaymentStatus = null)
        {
            var orderfromdb = _db.orderheaders.FirstOrDefault(u => u.Id == id);
            if(orderfromdb != null)
            {
                orderfromdb.OrderStatus = OrderStatus;
                if (PaymentStatus != null)
                {
                    orderfromdb.PaymentStatus = PaymentStatus;
                }
            }
        }
    }
}
