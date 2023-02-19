using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository.IRepository
{
   public interface ICoverTypeRepository : IRepository<CoverType>
    {
            void Update(CoverType obj);
    }
}
