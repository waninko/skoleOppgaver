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
            var first = db.Products.First();
            //SLETTE
            // db.Products.Remove(first);
            first.ProductName += "**";  // <-- Endre
            db.SaveChanges();  //<-- husk å  lagre til db!




            //LEGGE INN NYE ENTRIES I DB//
            /*var entity = new Products()
            {
               ProductName = "TestProdukt"
            };
            db.Products.Add(entity);
            db.SaveChanges();*/



            return; //bare for å unngå å kjøre koden under
            var products = db.Products
                .Include(p => p.Category)
                .ThenInclude(category => category.Products)
                .Include(p => p.Supplier)
                //.First(); Lese ut ett(det første) produktet
                .Take(10); //Lese ut flere linjer - må legges inn i en foreach

            foreach (var product in products)
            {
                Console.WriteLine("Produkt: " + product.ProductName);
                Console.WriteLine("Kategori: " + product.Category.CategoryName);
                Console.WriteLine("Annet produkt i samme Kategori: " + product.Category.Products.Skip(3).First().ProductName);
            }

        }
    }
}
