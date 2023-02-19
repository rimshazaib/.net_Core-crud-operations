﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;

namespace WebApplication1.Repository.IRepository
{
   public interface IProductRepository : IRepository<Product>
    {
            void Update(Product obj);
    }
}
