﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using T_shirt.Data.Models;

namespace T_shirt.Data.Models.Models
{
    public interface IStoreRepository
    {
        IQueryable<Product> Products { get; }
        void SaveProduct(Product p);
        void CreateProduct(Product p);
        void DeleteProduct(Product p);
    }
}
