﻿using Business.Abstract;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _ProductDal;

        public ProductManager(IProductDal productDal)
        {
            _ProductDal = productDal;
        }

        public List<Product> GetAll()
        {
            // if-else kodları
            // Yetkilemeler
            return _ProductDal.GetAll();
        }

        public List<Product> GetAllByCategory(int id)
        {
            return _ProductDal.GetAll(p => p.CategoryId == id);
        }

        public List<Product> GetByUnitePrice(decimal min, decimal max)
        {
            return _ProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }
    }
}