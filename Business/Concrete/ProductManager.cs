using Business.Abstract;
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
                return new ErrorResult("Ürün ismi en az 2 karakter olmalıdır");
            }
            _ProductDal.Add(product);
            return new SuccessResult("Ürün Eklendi");
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

        public Product GetByID(int productId)
        {
            return _ProductDal.Get(p => p.ProductId == productId);
        }

        public List<Product> GetByUnitePrice(decimal min, decimal max)
        {
            return _ProductDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max);
        }

        public List<ProductDetailDto> GetProductDetails()
        {
            return _ProductDal.GetProductDetails();
        }
    }
}
