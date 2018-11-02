using System;
using System.Linq;
using EntityFrameworkTest.Models;
using Microsoft.EntityFrameworkCore;

namespace EntityFrameworkTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var db = new NorthwindContext();
            var product = db.Products
                .Include(p=> p.Category)
                .ThenInclude(category => category.Products)
                .Include(p => p.Supplier)
                .First();
            Console.WriteLine("Produkt: " + product.ProductName);
            Console.WriteLine("Kategori: " + product.Category.CategoryName);
            Console.WriteLine("Annet produkt i samme Kategori: " + product.Category.Products.Skip(4).First().ProductName);

        }
    }
}
