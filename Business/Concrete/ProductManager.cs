﻿using Business.Abstract;
using Business.BussnessAspects.Autofac;
using Business.CCS;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Bussines;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class ProductManager : IProductService
    {
        IProductDal _productDal;
        ICategoryService _categoryService;

        public ProductManager(IProductDal productDal,ICategoryService categoryService)
        {
            _productDal = productDal;
            _categoryService = categoryService;
        }
        //Claim  --> yetkileri böyle adlandırıyoruz (product.add,admin)
       // [SecuredOperation("product.add,admin")]
        [ValidationAspect(typeof(ProductValidator))] // Attribute metoda anlam katmak isteyen yapılar
        [CacheRemoveAspect("IProductService.Get")] // Cache deki keyinde "IProductService.Get" geçen bütün verileri siler
        public IResult Add(Product product)
        {
            //iş Kodları -- business codes
            //  ValidationTool.Validate(new ProductValidator(), product); --> yukarıya ValidationAspect yaparak bunu taşımış olduk
          
            IResult result = BussinesRules.Run(
                CheckIfProductExist(product.ProductName),               // Aynı isimde ürün eklenemez
                CheckIfProductCountCategoryCorrect(product.CategoryId),  // Bir Kategoriye belli sayıda ürün eklenmeli burada örn:15
                CheckIfCategoryLimitExceded()  // Kategori sayısı 15 i aştıysa yeni ürün eklenemez
            );

            if (result != null)
            {
                return result;
            }
            _productDal.Add(product);
            return new SuccessResult(Messages.ProductAdded);


        }

        [CacheAspect] // key value => key cache ismi 
        public IDataResult<List<Product>> GetAll()
        {
            // if-else kodları
            // Yetkilemeler

            if (DateTime.Now.Hour == 05)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(), Messages.ProductsListed);
        }

        public IDataResult<List<Product>> GetAllByCategory(int id)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.CategoryId == id),Messages.ProductsListed);
        }

        [CacheAspect]
        public IDataResult<Product> GetByID(int productId)
        {
            return new SuccessDataResult<Product>(_productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitePrice(decimal min, decimal max)
        {
            return new SuccessDataResult<List<Product>>(_productDal.GetAll(p => p.UnitPrice >= min && p.UnitPrice <= max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>>(_productDal.GetProductDetails());
        }

        [ValidationAspect(typeof(ProductValidator))]
        [CacheRemoveAspect("IProductService.Get")]
        public IResult Update(Product product)
        {
            if (CheckIfProductCountCategoryCorrect(product.CategoryId).Success)
            {
                _productDal.Add(product);
                return new SuccessResult(Messages.ProductAdded);
            }

            return new ErrorResult();
        }

        private IResult CheckIfProductExist(string productName)
        {
            var result = _productDal.GetAll(p => p.ProductName == productName).Any();
            if (result)
            {
                return new ErrorResult(Messages.ProductNameAlreadyExists);
            }
            return new SuccessResult();
        }
        private IResult CheckIfProductCountCategoryCorrect(int categoryId)
        {
            var result = _productDal.GetAll(p => p.CategoryId == categoryId).Count;
            if (result >= 10)
            {
                return new ErrorResult(Messages.ProductCounOfCategoryError);
            }
            return new SuccessResult();
        }
        private IResult CheckIfCategoryLimitExceded()
        {

            var result = _categoryService.GetAll().Data.Count;
            if (result >= 15)
            {
                return new ErrorResult(Messages.CategoryLimitExceded);
            }
            return new SuccessResult();
        }
        [TransactionScopeAspect]
        public IResult AddTransactionalTest(Product product)
        {
            throw new NotImplementedException();
        }
    }
}
