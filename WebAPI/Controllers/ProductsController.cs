using Business.Abstract;
using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        // loose coupled -- gevşek bağlılık
        //naming convertion  _ ile isimlendirme
        // Ioc  (Inversion Of Control) Container
        IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public List<Product> Get()
        {
            //// Dependency chain --  bunu yukarı taşıyarak bundan kurtulduk
            //IProductService productService = new ProductManager( new EfProductDal());
            var result=_productService.GetAll();

            return result.Data;
        }
    }
}
