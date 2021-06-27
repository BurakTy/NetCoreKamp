using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
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

        public IResult Add(Product product)
        {
            //iş Kodları -- business codes

            if (product.ProductName.Length < 2)
            {
                return new ErrorResult(Messages.ProductNameInvalid);
            }
            _ProductDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            // if-else kodları
            // Yetkilemeler
            return new DataResult<List<Product>>(_ProductDal.GetAll(),true,"Ürünler Listlendi");
        }

        public IDataResult<List<Product>> GetAllByCategory(int id)
        {
            return new DataResult<List<Product>>(_ProductDal.GetAll(p => p.CategoryId == id),true);
        }

        public IDataResult<Product> GetByID(int productId)
        {
            return new DataResult<Product>(_ProductDal.Get(p => p.ProductId == productId),true);
        }

        public IDataResult<List<Product>> GetByUnitePrice(decimal min, decimal max)
        {
            return new DataResult<List<Product>>(_ProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max),true);
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new DataResult<List<ProductDetailDto>>(_ProductDal.GetProductDetails(),true);
        }
    }
}
