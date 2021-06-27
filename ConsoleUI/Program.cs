using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //ProducTest();
            // IoC 

            CategoryTest();
        }

        private static void CategoryTest()
        {
            CategoryManager categoryManager = new CategoryManager(new EfCategoryDal());

            foreach (var item in categoryManager.GetAll())
            {
                Console.WriteLine(item.CategoryName);
            }
        }

        private static void ProducTest()
        {
            ProductManager productManager = new ProductManager(new EfProductDal());

            foreach (var item in productManager.GetByUnitePrice(70, 100))
            {
                Console.WriteLine(item.ProductName);
            }

        }
       
    }
}
